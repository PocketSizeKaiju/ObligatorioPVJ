using UnityEngine;

public class DamageTouchingPlayer : MonoBehaviour
{
    [SerializeField] private int damageAmount;

    void OnTriggerEnter2D(Collider2D collision)
{
    // Solo entramos aquí si el objeto tiene el Tag "Player"
    // Como el láser es "Untagged", el enemigo ignorará el choque del láser
    // y NO quita vida.
    if (collision.CompareTag("Player"))
    {
        if(collision.TryGetComponent(out PlayerLife playerLife))
        {
            playerLife.TakeDamage(damageAmount);
        }
    }
}
}
