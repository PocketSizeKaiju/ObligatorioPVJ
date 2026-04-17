using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * Vector3.left;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}