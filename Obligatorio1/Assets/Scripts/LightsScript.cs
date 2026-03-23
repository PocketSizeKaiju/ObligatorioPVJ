using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightsScript : MonoBehaviour
{
    private void Update()
    {
        GetComponent<BoxCollider2D>().enabled = Keyboard.current.ctrlKey.IsPressed();
    }
}
