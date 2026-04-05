using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 LastNonZeroDirection => _lastNonZeroDirection;

    private float Speed => Settings.Instance.PlayerSpeed;

    private Vector2 _lastNonZeroDirection;

    // Update is called once per frame
    void Update()
    {
        UpdateKeyboardInput();
        UpdateMouseInput();
    }

    private void UpdateMouseInput()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("click");
        }
    }

    private void UpdateKeyboardInput()
    {
        Vector3 pos = transform.position;
        
        Vector3 direction = Vector2.zero;

        if (Keyboard.current.leftArrowKey.IsPressed() || Keyboard.current.aKey.IsPressed())
        {
            direction.x += -1;
        }
        if (Keyboard.current.rightArrowKey.IsPressed() || Keyboard.current.dKey.IsPressed())
        {
            direction.x += 1;
        }
        if (Keyboard.current.downArrowKey.IsPressed() || Keyboard.current.sKey.IsPressed())
        {
           direction.y += -1;
        }
        if (Keyboard.current.upArrowKey.IsPressed() || Keyboard.current.wKey.IsPressed())
        {
            direction.y += 1;
        }

        Vector3 velocity = direction.normalized * Speed;
        transform.position += velocity * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            _lastNonZeroDirection = direction;
        }

    }
}
