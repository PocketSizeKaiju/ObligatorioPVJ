using UnityEngine;
using UnityEngine.UI;

public class MusicStopStart : MonoBehaviour
{
    [Header("Icons")]
    [SerializeField] private Sprite _musicOnSprite;
    [SerializeField] private Sprite _musicOffSprite;

    private Image _buttonImage;
    private bool _isMuted = false;

    void Start()
    {
        _buttonImage = GetComponent<Image>();
    }

    public void ToggleAllMusic()
{
    _isMuted = !_isMuted;

    // Guardamos: 1 es silenciado, 0 es con sonido
    PlayerPrefs.SetInt("GlobalMute", _isMuted ? 1 : 0);
    PlayerPrefs.Save();

    ApplyMuteToCurrentObjects();
    UpdateIcon();
}

private void ApplyMuteToCurrentObjects()
{
    GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");
    foreach (GameObject obj in musicObjects)
    {
        obj.GetComponent<AudioSource>().mute = _isMuted;
    }
}

    void UpdateIcon()
    {
        if (_isMuted)
            _buttonImage.sprite = _musicOffSprite;
        else
            _buttonImage.sprite = _musicOnSprite;
    }
}