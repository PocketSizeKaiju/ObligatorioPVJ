using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip sound;
    public bool playOnAwake;


    private AudioSource source;
    private readonly float lowPitchRange = Settings.Instance.lowPitchRange;
    private readonly float highPitchRange = Settings.Instance.highPitchRange;
    private readonly float velToVol = Settings.Instance.velToVol;
    private readonly float velocityClipSplit = Settings.Instance.velocityClipSplit;


    void Awake()
    {
        source = GetComponent<AudioSource>();
        if (playOnAwake) PlayOnAwake();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        source.pitch = Random.Range(lowPitchRange, highPitchRange);
        float speed = 1f;

        if (collision.attachedRigidbody != null)
            speed = collision.attachedRigidbody.linearVelocity.magnitude;

        float hitVol = speed * velToVol;

        source.PlayOneShot(sound, hitVol);
    }

    void PlayOnAwake()
    {
        source.pitch = Random.Range(lowPitchRange, highPitchRange);
        source.PlayOneShot(sound, velToVol);
    }
}
