using System.Collections;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    private GameObject[] _enemiesPrefab;
    private GameObject[] _obstaclesPrefab;
    private GameObject _enemyBloodPrefab;
    public Sprite[] _horseSprites;

    private float _createEnemyInterval;

    void Start()
    {
        _enemiesPrefab = Resources.LoadAll<GameObject>("Prefabs/Enemies").OrderBy(go => go.name).ToArray() ?? throw new UnityException("Couldn't load Enemy prefab from Resources!");
        _obstaclesPrefab = Resources.LoadAll<GameObject>("Prefabs/Obstacles").OrderBy(go => go.name).ToArray() ?? throw new UnityException("Couldn't load Obstacles prefab from Resources!");
        _enemyBloodPrefab = Resources.Load<GameObject>("Prefabs/EnemyBlood");
        Debug.Log(_enemiesPrefab.Length);

        for (int i = 0; i < Settings.Instance.StartingEnemyCount; i++)
        {
            CreateEnemy();
        }

        _createEnemyInterval = Settings.Instance.BaseCreateEnemyInterval;
        StartCoroutine(CreateEnemiesCoroutine());
        StartCoroutine(CreateObstaclesCoroutine());
    }

    private IEnumerator CreateEnemiesCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            CreateObstacle();
        }
    }
    private IEnumerator CreateObstaclesCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_createEnemyInterval);
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {

        int percentage = Random.Range(0, 10);
        GameObject newEnemy;
        if (percentage <= 6)
        {
            if (percentage <= 2)
            {
                if (percentage >= 2)
                {
                    Debug.Log("Creating burger");
                    newEnemy = Instantiate(_enemiesPrefab[3]);
                    newEnemy = CreateBurgerEnemy(newEnemy);
                }
                else
                {
                    Debug.Log("Creating piggy");
                    newEnemy = Instantiate(_enemiesPrefab[2]);
                    newEnemy = CreatePigEnemy(newEnemy);
                }
            }
            else
            {
                Debug.Log("Creating horse");
                newEnemy = Instantiate(_enemiesPrefab[0]);
                newEnemy = CreateHorseEnemy(newEnemy);
            }
        }
        else
        {
            Debug.Log("Creating crow");
            newEnemy = Instantiate(_enemiesPrefab[1]);
            newEnemy = CreateCrowEnemy(newEnemy);
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

    void Update()
    {
        _createEnemyInterval -= Time.deltaTime * Settings.Instance.CreateEnemyIntervalDecreasePerSecond;

        if (_createEnemyInterval < Settings.Instance.MinCreateEnemyInterval)
        {
            _createEnemyInterval = Settings.Instance.MinCreateEnemyInterval;
        }
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
