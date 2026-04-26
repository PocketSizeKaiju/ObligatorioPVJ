using UnityEngine;
using UnityEngine.InputSystem; // 1. Necesario para detectar el teclado

public class ContainerHearts : MonoBehaviour
{
    [SerializeField] private HeartsBarUI[] hearts;
    private PlayerLife playerLife;

    private void Start()
    {
       playerLife = FindFirstObjectByType<PlayerLife>(); // 2. Obtener la vida actual del jugador al inicio 
       
       playerLife.PlayerTookDamage += ActivateHearts;
       playerLife.PlayerHealed += ActivateHearts;

       ActivateHearts(playerLife.GetActualLife()); // 3. Activar los corazones al inicio
    }

    void OnDisable()
    {
        playerLife.PlayerTookDamage -= ActivateHearts;
        playerLife.PlayerHealed -= ActivateHearts;
    }

    public void ActivateHearts(int actualLife)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < actualLife)
            {
                hearts[i].ActiveHeart();
            }
            else
            {
                hearts[i].DeactiveHeart();
            }
        }
    }
}
