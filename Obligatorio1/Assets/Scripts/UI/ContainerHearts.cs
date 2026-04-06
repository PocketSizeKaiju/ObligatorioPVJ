using UnityEngine;
using UnityEngine.InputSystem; // 1. Necesario para detectar el teclado

public class ContainerHearts : MonoBehaviour
{
    [SerializeField] private HeartsBarUI[] hearts;
    [SerializeField] private int actualLife;

    private void Update()
    {
        // 2. Cambiamos Input.GetKeyDown por la sintaxis del nuevo sistema
        if (Keyboard.current != null && Keyboard.current.tKey.wasPressedThisFrame)
        {
            ActivateHearts(actualLife);
        }
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
