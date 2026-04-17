using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TMP_Text timeText;
    public AudioSource audioSource;
    public AudioClip sound;

    private bool hasWon = false;


    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = -1;
                timerIsRunning = false;
                Time.timeScale = 0.4f;

                if (!hasWon)
                {
                    hasWon = true;
                    ScoreManager.Instance?.AddPoints(1000);
                    StartCoroutine(PlaySoundAndLoadScene());
                }
            }
            DisplayTime(timeRemaining);
        }
    }

    IEnumerator PlaySoundAndLoadScene()
    {
        audioSource.PlayOneShot(sound, 1f);
        yield return new WaitForSeconds(sound.length - 4);
        SceneManager.LoadScene("GameWinScene");
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}