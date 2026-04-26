using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _scoreValue = 100;
    [SerializeField] private int _health = 0;
    [SerializeField] private bool _summonOnHit;
    [SerializeField] private GameObject _enemyToSummon;
    [SerializeField] private GameObject _coinToSummon;

    private EnemyManager _enemyManager;
    private const string flashRedAnim = "FlashRed";

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
        if (_animator) _animator.SetTrigger(flashRedAnim);

        if (_health > 0)
        {
            if (_summonOnHit)
            {
                int percentage = Random.Range(0, 10);

                if (percentage >= 8)
                {
                    Debug.Log("Summon enemy");
                    SummonEnemy();
                }
                else if (percentage >= 2)
                {
                    Debug.Log("Summon good");
                    SummonCoin();
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

    private void SummonCoin()
    {
        GameObject newEnemy = Instantiate(_coinToSummon);
        newEnemy.transform.position = transform.position + new Vector3(-2, -2, -2);
    }
}
