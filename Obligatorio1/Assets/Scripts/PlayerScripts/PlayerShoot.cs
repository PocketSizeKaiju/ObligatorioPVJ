using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShoot : MonoBehaviour
{
    private GameObject _shotPrefab;
    private float _shootingInterval;
    private Vector3 _mousePosition;

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
        Vector3 mousePos = Mouse.current.position.ReadValue();
        float distance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        mousePos.z = distance;
        _mousePosition = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = _mousePosition - transform.position;

        GameObject shotObject = Instantiate(original: _shotPrefab, position: transform.position, rotation: Quaternion.identity);
        shotObject.GetComponent<PlayerShot>().Init(direction);
    }
}