using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public event Action<int> ScoreChanged;

    public int CurrentScore { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddPoints(int points)
    {
        if (points <= 0)
        {
            return;
        }

        CurrentScore += points;
        ScoreChanged?.Invoke(CurrentScore);
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        ScoreChanged?.Invoke(CurrentScore);
    }

    public void HighScoreUpdate(TMP_Text finalScoreText, TMP_Text highScoreText)
    {
        int currentScore = CurrentScore;

        string saved = PlayerPrefs.GetString("HighScores", "");
        List<int> scores = new List<int>();

        if (!string.IsNullOrEmpty(saved))
        {
            string[] split = saved.Split(',');
            foreach (string s in split)
            {
                scores.Add(int.Parse(s));
            }
        }

        scores.Add(currentScore);
        scores.Sort((a, b) => b.CompareTo(a));

        if (scores.Count > 3)
            scores = scores.GetRange(0, 3);

        string result = string.Join(",", scores);
        PlayerPrefs.SetString("HighScores", result);
        PlayerPrefs.Save();

        finalScoreText.text = currentScore.ToString();
        highScoreText.text = scores[0].ToString(); 
    }
}