using UnityEngine;

public class SyncMute : MonoBehaviour
{
    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        if (source != null)
        {
            // Si el valor guardado es 1, se pone en mute automáticamente
            source.mute = (PlayerPrefs.GetInt("GlobalMute", 0) == 1);
        }
    }
}