using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScreen : MonoBehaviour
{
    public GameObject _gameObject;

    void Start()
    {
        _gameObject.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            _gameObject.SetActive(!_gameObject.activeSelf);
            Time.timeScale = _gameObject.activeSelf ? 0f : 1f;
        }
    }
}
