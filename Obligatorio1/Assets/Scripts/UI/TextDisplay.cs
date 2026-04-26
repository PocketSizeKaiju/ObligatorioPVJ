using UnityEngine;
using TMPro; 
using System.Collections;

public class TextDisplay : MonoBehaviour
{
    public TextMeshProUGUI textLabel;
    public string fullText;        
    public float delay = 0.05f;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip typingClip; 

    [Header("Settings")]
    public GameObject nextButton;

    void OnEnable() 
    {
        if (nextButton != null) nextButton.SetActive(false);
        
        // Iniciamos la escritura
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        textLabel.text = ""; 

        // 1. Si tenemos audio, lo configuramos y le damos Play
        if (audioSource != null && typingClip != null)
        {
            audioSource.clip = typingClip;
            audioSource.loop = true; // Para que no se corte si el texto es largo
            audioSource.Play();
        }

        foreach (char letter in fullText.ToCharArray())
        {
            textLabel.text += letter; 
            yield return new WaitForSeconds(delay); 
        }

        // 2. Cuando termina de escribir, apagamos el sonido
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        if (nextButton != null)
        {
            nextButton.SetActive(true);
        }
    }
}