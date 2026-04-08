using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private EnemyManager _enemyManager;

    public void Init(EnemyManager enemyManager)
    {
        _enemyManager = enemyManager;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerShot>())
        {
            GetComponent<Collider2D>().enabled = false;

            _enemyManager.CreateEnemyBlood(transform.position);
            Destroy(gameObject);
        }
    }
}
