using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    private Vector3 _mousePosition;
    
    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        _mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = _mousePosition;
    }
}
