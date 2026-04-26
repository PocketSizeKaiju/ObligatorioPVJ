using System.Collections;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private float _baseMinSpawnTime = 2f;
    [SerializeField] private float _baseMaxSpawnTime = 6f;

    [SerializeField] private float _difficultyScale = 0.1f; 
    [SerializeField] private float _maxSpawnTimeCap = 15f;
    [SerializeField] private float _minY = -5f;
    [SerializeField] private float _maxY = -0.5f;

    private GameObject _coinPrefab;
    private Transform _playerTransform;

    private void Awake()
    {
        _coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");
    }

    private void Start()
    {
        _playerTransform = FindAnyObjectByType<PlayerMovement>().transform != null
            ? FindAnyObjectByType<PlayerMovement>().transform
            : throw new UnityException("Player not found!");
        StartCoroutine(CreateCoinsCoroutine());
    }

    private IEnumerator CreateCoinsCoroutine()
    {
        while (true)
        {

            float extraDelay = Time.deltaTime * _difficultyScale;

            float minTime = _baseMinSpawnTime + extraDelay;
            float maxTime = _baseMaxSpawnTime + extraDelay;

            minTime = Mathf.Min(minTime, _maxSpawnTimeCap);
            maxTime = Mathf.Min(maxTime, _maxSpawnTimeCap);

            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            CreateCoin();
        }
    }

    private void CreateCoin()
    {
        GameObject newCoin = Instantiate(_coinPrefab);

        newCoin.transform.position = new Vector2(
            x: 10f,
            y: Random.Range(_minY, _maxY)
        );
    }
}