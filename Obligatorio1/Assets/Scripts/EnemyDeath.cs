using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private EnemyManager _enemyManager;

    public void Init(EnemyManager enemyManager)
    {
        _enemyManager = enemyManager;
    }

    void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.GetComponent<PlayerShot>())
    {
        GetComponent<Collider2D>().enabled = false; // 🔥 clave

        _enemyManager.CreateEnemyBlood(transform.position);
        Destroy(gameObject);
    }
}
}
