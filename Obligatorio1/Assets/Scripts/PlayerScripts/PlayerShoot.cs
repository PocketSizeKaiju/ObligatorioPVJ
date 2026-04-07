using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShoot : MonoBehaviour
{
    private GameObject _shotPrefab;

    void Awake()
    {
        _shotPrefab = Resources.Load<GameObject>("Prefabs/PlayerShot");
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 mousePosition = new Vector2(
            x: Mouse.current.position.x.ReadValue(),
            y: Mouse.current.position.y.ReadValue()
        );
        GameObject shotObject = Instantiate(original: _shotPrefab, position: transform.position, rotation: Quaternion.identity);
        shotObject.GetComponent<PlayerShot>().Init(mousePosition);
    }


}