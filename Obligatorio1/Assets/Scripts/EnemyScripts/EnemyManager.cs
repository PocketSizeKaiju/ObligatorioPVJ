using System.Collections;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    private GameObject[] _enemiesPrefab;
    private GameObject[] _obstaclesPrefab;
    private GameObject _enemyBloodPrefab;
    public Sprite[] _horseSprites;

    private float _timeAlive = 0f;

    private float _createEnemyInterval;
    private float _nextBurstTime;

    void Start()
    {
        for (int i = 0; i < Settings.Instance.StartingEnemyCount; i++)
        {
            CreateEnemy();
        }

        StartCoroutine(CreateEnemiesCoroutine());
        StartCoroutine(CreateObstaclesCoroutine());
    }
    private void Awake()
    {
        _enemiesPrefab = Resources.LoadAll<GameObject>("Prefabs/Enemies").OrderBy(go => go.name).ToArray() ?? throw new UnityException("Couldn't load Enemy prefab from Resources!");
        _obstaclesPrefab = Resources.LoadAll<GameObject>("Prefabs/Obstacles").OrderBy(go => go.name).ToArray() ?? throw new UnityException("Couldn't load Obstacles prefab from Resources!");
        _enemyBloodPrefab = Resources.Load<GameObject>("Prefabs/EnemyBlood");

        _createEnemyInterval = Settings.Instance.BaseCreateEnemyInterval;
        _nextBurstTime = Settings.Instance.DifficultyBurstInterval;
    }

    private IEnumerator CreateEnemiesCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_createEnemyInterval);
            CreateEnemy();
        }
    }
    private IEnumerator CreateObstaclesCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Settings.Instance.ObstacleSpawnInterval);
            CreateObstacle();
        }
    }

    void Update()
    {
        _timeAlive += Time.deltaTime;

        _createEnemyInterval -= Time.deltaTime * Settings.Instance.CreateEnemyIntervalDecreasePerSecond;
        _createEnemyInterval = Mathf.Max(_createEnemyInterval, Settings.Instance.MinCreateEnemyInterval);

        if (_timeAlive >= _nextBurstTime)
        {
            _nextBurstTime += Settings.Instance.DifficultyBurstInterval;
            StartCoroutine(SpawnBurstCoroutine());
        }
    }

    private IEnumerator SpawnBurstCoroutine()
    {
        int burstCount = Settings.Instance.BaseBurstEnemyCount
            + Mathf.FloorToInt(_timeAlive / Settings.Instance.BurstCountIncreaseEverySeconds);

        burstCount = Mathf.Min(burstCount, Settings.Instance.MaxBurstEnemyCount);

        for (int i = 0; i < burstCount; i++)
        {
            CreateEnemy(forceDifficult: true);
            yield return new WaitForSeconds(Settings.Instance.BurstSpawnDelay);
        }
    }

    private float DifficultyFactor()
    {
        return Mathf.Clamp01(_timeAlive / Settings.Instance.DifficultyMaxRampTime);
    }

    private void CreateEnemy(bool forceDifficult = false)
    {
        float t = DifficultyFactor();

        float weightHorse = Mathf.Lerp(6f, 1f, t);
        float weightCrow = Mathf.Lerp(1f, 4f, t);
        float weightPig = Mathf.Lerp(2f, 1f, t);
        float weightBurger = Mathf.Lerp(0f, 4f, t);

        if (forceDifficult)
        {
            weightHorse *= 0.3f;
            weightPig *= 0.3f;
            weightCrow *= 2f;
            weightBurger *= 2f;
        }

        float total = weightHorse + weightCrow + weightPig + weightBurger;
        float roll = Random.Range(0f, total);

        GameObject newEnemy;

        if (roll < weightHorse)
        {
            Debug.Log("Creating horse");
            newEnemy = Instantiate(_enemiesPrefab[0]);
            newEnemy = CreateHorseEnemy(newEnemy);
        }
        else if (roll < weightHorse + weightCrow)
        {
            Debug.Log("Creating crow");
            newEnemy = Instantiate(_enemiesPrefab[1]);
            newEnemy = CreateCrowEnemy(newEnemy);
        }
        else if (roll < weightHorse + weightCrow + weightPig)
        {
            Debug.Log("Creating piggy");
            newEnemy = Instantiate(_enemiesPrefab[2]);
            newEnemy = CreatePigEnemy(newEnemy);
        }
        else
        {
            Debug.Log("Creating burger");
            newEnemy = Instantiate(_enemiesPrefab[3]);
            newEnemy = CreateBurgerEnemy(newEnemy);
        }

        newEnemy.GetComponent<EnemyDeath>().Init(this);
    }

    private void CreateObstacle()
    {
        int percentage = Random.Range(0, 10);
        GameObject newObstacle;
        if (percentage <= 6)
        {
            Debug.Log("Creating tree");
            newObstacle = Instantiate(_obstaclesPrefab[0]);
        }
        else
        {
            Debug.Log("Creating fence");
            newObstacle = Instantiate(_obstaclesPrefab[1]);
        }
        newObstacle.GetComponent<EnemyChase>().UpdateChasing(false);
        newObstacle.transform.position = new Vector2(
            x: 10,
            y: Random.Range(Settings.Instance.EnemyFloorBoundsMax, Settings.Instance.EnemyFloorBoundsMin));

        newObstacle.GetComponent<EnemyDeath>().Init(this);
    }

    public void CreateEnemyBlood(Vector2 position)
    {
        GameObject blood = Instantiate(original: _enemyBloodPrefab, position: position, rotation: Quaternion.identity);
    }

    private GameObject CreateHorseEnemy(GameObject newEnemy)
    {
        SpriteRenderer spriteR = newEnemy.GetComponent<SpriteRenderer>();
        int index = Random.Range(0, 6);
        newEnemy.GetComponent<EnemyChase>().UpdateChasing(index > 3);
        spriteR.sprite = _horseSprites[index];
        newEnemy.transform.position = new Vector2(
            x: 10,
            y: Random.Range(Settings.Instance.EnemyFloorBoundsMax, Settings.Instance.EnemyFloorBoundsMin));

        return newEnemy;
    }

    private GameObject CreatePigEnemy(GameObject newEnemy)
    {
        newEnemy.GetComponent<EnemyChase>().UpdateChasing(false);
        newEnemy.transform.position = new Vector2(
            x: 10,
            y: Random.Range(Settings.Instance.EnemyFloorBoundsMax, Settings.Instance.EnemyFloorBoundsMin));

        return newEnemy;
    }

    private GameObject CreateBurgerEnemy(GameObject newEnemy)
    {
        newEnemy.GetComponent<EnemyChase>().UpdateChasing(true);
        newEnemy.transform.position = new Vector2(
            x: 10,
            y: Random.Range(Settings.Instance.EnemyFloorBoundsMax, Settings.Instance.EnemyFloorBoundsMin));

        return newEnemy;
    }

    private GameObject CreateCrowEnemy(GameObject newEnemy)
    {
        newEnemy.GetComponent<EnemyChase>().UpdateChasing(true);
        newEnemy.transform.position = new Vector2(
            x: Random.Range(5, 10),
            y: Random.Range(Settings.Instance.EnemySkyBoundsMax, Settings.Instance.EnemySkyBoundsMin));

        return newEnemy;
    }
}
