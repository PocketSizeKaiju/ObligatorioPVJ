using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShoot : MonoBehaviour
{
    private GameObject _shotPrefab;
    private float _shootingInterval;

    void Awake()
    {
        _shotPrefab = Resources.Load<GameObject>("Prefabs/PlayerShot");
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && _shootingInterval > Settings.Instance.PlayerShootInterval)
        {
            Shoot();
            _shootingInterval = 0;
        }
        _shootingInterval += Time.deltaTime;
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