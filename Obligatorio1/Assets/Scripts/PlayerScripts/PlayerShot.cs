using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private Vector2 _direction;

    public void Init(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    void Update()
    {
        Vector3 velocity = _direction * Settings.Instance.PlayerShotSpeed;
        transform.position += velocity * Time.deltaTime;
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
        if (collision.GetComponent<EnemyChase>() != null)
        {
            Destroy(gameObject);
        }
    }
}
