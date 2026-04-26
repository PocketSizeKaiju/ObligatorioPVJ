using UnityEngine;

public class DamageTouchingPlayer : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private bool _destroyOnImpact;
    [SerializeField] private AudioClip sound;

    private PlaySound _sfxPlayer;
    private bool _alreadyHit;

    private void Start()
    {
        GameObject sfxPlayerObject = GameObject.Find("SFXPlayer");

        if (sfxPlayerObject != null)
        {
            _sfxPlayer = sfxPlayerObject.GetComponent<PlaySound>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_alreadyHit)
        {
            return;
        }

        Transform playerRoot = collision.transform.root;

        if (!playerRoot.CompareTag("Player"))
        {
            return;
        }

        _alreadyHit = true;

        PlayerLife playerLife = playerRoot.GetComponent<PlayerLife>();
        if (playerLife != null && playerLife.isActiveAndEnabled)
        {
            playerLife.TakeDamage(damageAmount);
        }

        if (_sfxPlayer != null && sound != null)
        {
            _sfxPlayer.PlaySpecific(sound);
        }

        if (_destroyOnImpact)
        {
            Destroy(transform.root.gameObject);
        }
    }
}