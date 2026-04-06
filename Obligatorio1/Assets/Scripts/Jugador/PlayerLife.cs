using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int maxLife;
    [SerializeField] private int actualLife;

    private void Awake()
    {
        actualLife = maxLife;
    }

    public void TakeDamage(int damage)
    {
        int temporalLife = actualLife - damage;

        temporalLife = Mathf.Clamp(temporalLife, 0, maxLife);

        actualLife = temporalLife;

        if(actualLife <= 0)
        {
            DestroyPlayer();
        }
    }

    private void DestroyPlayer()
    {
        // Por ahora, destruimos el objeto del jugador.
        Destroy(gameObject);
    }

    public void Heal(int healAmount)
    {
        int temporalLife = actualLife + healAmount;

        temporalLife = Mathf.Clamp(temporalLife, 0, maxLife);

        actualLife = temporalLife;
    }
    public int GetActualLife()
    {
        return actualLife;
    }
    public int GetMaxLife()
    {
        return maxLife;
    }
}
