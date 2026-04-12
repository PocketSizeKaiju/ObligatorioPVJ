using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameObject _enemyPrefab;
    private GameObject _enemyBloodPrefab;
    public Sprite[] _horseSprites;

    private float _createEnemyInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
        if (_enemyPrefab == null)
        {
            throw new UnityException("Couldn't load Enemy prefab from Resources!");
        }

        _enemyBloodPrefab = Resources.Load<GameObject>("Prefabs/EnemyBlood");

        for (int i = 0; i < Settings.Instance.StartingEnemyCount; i++)
        {
            CreateEnemy();
        }

        _createEnemyInterval = Settings.Instance.BaseCreateEnemyInterval;
        StartCoroutine(CreateEnemiesCoroutine());
    }

    private IEnumerator CreateEnemiesCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_createEnemyInterval);
            CreateEnemy();
        }
    }


    private void CreateEnemy()
    {
        GameObject newEnemy = Instantiate(_enemyPrefab);
        newEnemy = CreateHorseEnemy(newEnemy);

        newEnemy.GetComponent<EnemyDeath>().Init(this);
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
            y: Random.Range(-5, -0.5f));

        return newEnemy;
    }
}
