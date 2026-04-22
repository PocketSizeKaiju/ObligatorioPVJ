using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public Action<int> PlayerTookDamage;
    public Action<int> PlayerHealed;
    [SerializeField] private Animator animator;
    [SerializeField] private int maxLife;
    [SerializeField] private int actualLife;
    [SerializeField] private GameObject playerExplosion;

    private const string flashRedAnim = "FlashRed";
    private void Awake()
    {
        actualLife = maxLife;
    }

    public void TakeDamage(int damage)
    {
        int temporalLife = actualLife - damage;

        temporalLife = Mathf.Clamp(temporalLife, 0, maxLife);

        actualLife = temporalLife;

        animator.SetTrigger(flashRedAnim);
        
        PlayerTookDamage?.Invoke(actualLife);

        if (actualLife <= 0)
        {
            DestroyPlayer();
        }
    }

    private void DestroyPlayer()
    {
        // Por ahora, destruimos el objeto del jugador.
        CreatePlayerExplosion();
        Destroy(gameObject);
    }

    public void CreatePlayerExplosion()
    {
        GameObject boom = Instantiate(original: playerExplosion, position: transform.position, rotation: Quaternion.identity);
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
