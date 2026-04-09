using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 100;

    private EnemyManager _enemyManager;

    public void Init(EnemyManager enemyManager)
    {
        _enemyManager = enemyManager;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerShot>() == null)
        {
            return;
        }

        ScoreManager.Instance?.AddPoints(_scoreValue);

        _enemyManager.CreateEnemyBlood(transform.position);
        Destroy(gameObject);
    }

    void Update()
    {
        if (transform.position.x > 12
            || transform.position.x < -10
            || transform.position.y > 8
            || transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
}
