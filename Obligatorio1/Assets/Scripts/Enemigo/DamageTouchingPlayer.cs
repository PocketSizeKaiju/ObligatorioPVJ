using UnityEngine;

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
        // Solo entramos aquí si el objeto tiene el Tag "Player"
        // Como el láser es "Untagged", el enemigo ignorará el choque del láser
        // y NO quita vida.
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent(out PlayerLife playerLife))
            {
                playerLife.TakeDamage(damageAmount);

                Debug.Log("soundPlayer: "+soundPlayer);
                Debug.Log("sound: "+sound);
                if (soundPlayer != null && sound != null)
                    soundPlayer.PlaySpecific(sound);

                if (_destroyOnImpact) Destroy(gameObject);
            }
        }
    }
}
