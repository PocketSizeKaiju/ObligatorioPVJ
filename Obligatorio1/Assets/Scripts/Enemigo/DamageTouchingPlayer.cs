using UnityEngine;

public class DamageTouchingPlayer : MonoBehaviour
{
    [SerializeField] private int damageAmount;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. FILTRO POR TAG: Solo si el objeto se llama "Player"
        if (!collision.CompareTag("Player")) return;

        // 2. FILTRO POR LAYER: Solo si está en la capa del cuerpo, no del láser
        // Reemplaza "Player" por el nombre exacto de tu Layer de personaje
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return;

        // 3. OBTENER COMPONENTE
        if (collision.TryGetComponent(out PlayerLife playerLife))
        {
            playerLife.TakeDamage(damageAmount);
            Debug.Log("Me chocó el cuerpo del jugador, quito vida.");
        }
    }
}
