using UnityEngine;

public class DamageTouchingPlayer : MonoBehaviour
{
    [SerializeField] private int damageAmount;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerLife playerLife))
        {
            playerLife.TakeDamage(damageAmount);
        }
    }
}
