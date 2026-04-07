using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public Action<int> PlayerTookDamage;
    public Action<int> PlayerHealed;
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

        PlayerTookDamage?.Invoke(actualLife);

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

        PlayerHealed?.Invoke(actualLife);
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
