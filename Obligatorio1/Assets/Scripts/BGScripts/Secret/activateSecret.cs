using UnityEngine;
using UnityEngine.InputSystem;

public class activateSecret : MonoBehaviour
{
    Key[] konamiCode;
    int currentKeyIndex = 0;

    void Start()
    {
        konamiCode = new Key[]
        {
            Key.UpArrow, Key.UpArrow,
            Key.DownArrow, Key.DownArrow,
            Key.LeftArrow, Key.RightArrow,
            Key.LeftArrow, Key.RightArrow,
            Key.B, Key.A
        };
    }

    void Update()
    {
        foreach (Key key in konamiCode)
        {
            if (Keyboard.current[key].wasPressedThisFrame)
            {
                CheckInput(key);
                break;
            }
        }
    }

    void CheckInput(Key pressedKey)
    {
        if (pressedKey == konamiCode[currentKeyIndex])
        {
            currentKeyIndex++;

            if (currentKeyIndex >= konamiCode.Length)
            {
                Settings.Instance.umapyoi = !Settings.Instance.umapyoi;
                currentKeyIndex = 0;
            }
        }
        else
        {
            currentKeyIndex = 0;
        }
    }
}