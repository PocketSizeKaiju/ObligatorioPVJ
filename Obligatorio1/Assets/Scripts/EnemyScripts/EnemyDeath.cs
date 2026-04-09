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

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddPoints(_scoreValue);
        }

        _enemyManager.CreateEnemyBlood(transform.position);
        Destroy(gameObject);
    }
}
