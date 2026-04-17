using System.Collections;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private float _coinSpawnInterval = 2f;
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
            yield return new WaitForSeconds(_coinSpawnInterval);
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