using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 25;
    [SerializeField] private AudioClip _pickupSound;
    [SerializeField] private bool _shouldHeal;
    [SerializeField] private int _healAmount;

    [SerializeField][Range(0f, 1f)] private float _pickupVolume = 1f;

    private PlaySound _soundPlayer;

    private void Awake()
    {
        _soundPlayer = GameObject.Find("SFXPlayer").GetComponent<PlaySound>();

        if (_soundPlayer == null)
        {
            Debug.LogWarning("SfxPlayer not found in scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        ScoreManager.Instance.AddPoints(_scoreValue);
        _soundPlayer.PlaySpecific(_pickupSound, _pickupVolume);

        if (collision.TryGetComponent(out PlayerLife playerLife) && _shouldHeal)
            playerLife.Heal(_healAmount);

        Destroy(gameObject);
    }
}