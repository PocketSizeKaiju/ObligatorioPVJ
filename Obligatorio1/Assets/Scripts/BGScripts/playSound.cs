using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip sound;
    public bool playOnAwake;


    private AudioSource source;
    private float lowPitchRange;
    private float highPitchRange;
    private float velToVol;
    private float velocityClipSplit;


    void Awake()
    {
        source = GetComponent<AudioSource>();

        lowPitchRange = Settings.Instance.lowPitchRange;
        highPitchRange = Settings.Instance.highPitchRange;
        velToVol = Settings.Instance.velToVol;
        velocityClipSplit = Settings.Instance.velocityClipSplit;

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
