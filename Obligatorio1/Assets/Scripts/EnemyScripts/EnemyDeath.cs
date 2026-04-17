using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 100;
    [SerializeField] private int _health = 0;
    [SerializeField] private bool _summonOnHit;
    [SerializeField] private GameObject _enemyToSummon;

    private EnemyManager _enemyManager;

    public void Init(EnemyManager enemyManager)
    {
        _enemyManager = enemyManager;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.name + " health left: " + _health);
        if (collision.GetComponent<PlayerShot>() == null)
            return;

        _health--;

        if (_health > 0)
        {
            if (_summonOnHit)
            {
                int percentage = Random.Range(0, 10);

                if (percentage >= 8)
                {
                    Debug.Log("Summon enemy");
                    SummonEnemy();
                } else
                {
                    Debug.Log("Summon good");
                }
                _summonOnHit = false; //oh no?
            }
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

    private void SummonEnemy()
    {
        GameObject newEnemy = Instantiate(_enemyToSummon);
        newEnemy.GetComponent<EnemyChase>().UpdateChasing(true);
        newEnemy.transform.position = transform.position;
        newEnemy.GetComponent<EnemyDeath>().Init(_enemyManager);
    }
}
