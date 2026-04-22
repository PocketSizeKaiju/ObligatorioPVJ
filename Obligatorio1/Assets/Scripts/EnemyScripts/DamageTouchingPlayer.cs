using UnityEngine;
using System.Collections;

public class DamageTouchingPlayer : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private bool _destroyOnImpact;
    [SerializeField] public AudioClip sound;
    private PlaySound soundPlayer;
    private void Awake()
    {
        soundPlayer = GetComponent<PlaySound>();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent(out PlayerLife playerLife))
            {
                playerLife.TakeDamage(damageAmount);
                if (soundPlayer != null && sound != null)
                    soundPlayer.PlaySpecific(sound);

                if (_destroyOnImpact)
                {
                    StartCoroutine(PlaySoundAndDestroy());
                }
            }
        }
    }

    IEnumerator PlaySoundAndDestroy()
    {
        yield return new WaitForSeconds(sound.length);
        Destroy(gameObject);
    }
}
