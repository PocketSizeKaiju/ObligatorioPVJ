using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private Transform _playerTransform;
    public float _enemySpeed = Settings.Instance.EnemySpeed;
    private bool _shouldChase;

    void Start()
    {
        _playerTransform = GameObject.FindAnyObjectByType<PlayerMovement>().transform ?? throw new UnityException();
    }

    void Update()
    {
        Vector2 playerPosition = _playerTransform.position;
        Vector2 myPosition = transform.position;
        Vector2 direction;

        if (_shouldChase)
        {
            direction = playerPosition - myPosition;
        }
        else
        {
            direction = Vector2.left;
        }
        Vector3 velocity = direction.normalized * _enemySpeed;
        transform.position += velocity * Time.deltaTime;
    }

    public void UpdateChasing(bool shouldChase)
    {
        _shouldChase = shouldChase;
    }
}
