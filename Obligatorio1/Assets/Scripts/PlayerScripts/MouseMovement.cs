using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    private Vector3 _mousePosition;
    private Vector2 _mousePositionUI;
    public Boolean _forUI;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (_forUI)
        {
            _mousePositionUI = Mouse.current.position.ReadValue();
            transform.position = _mousePositionUI;
        }
        else
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.nearClipPlane;
            _mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = _mousePosition;
        }
    }
}
