using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;
    public GameObject scoresGroup;
    void Start()
    {
        Time.timeScale = 1.0f;
        ScoreManager.Instance.HighScoreUpdate(finalScoreText);
        AddScoreBoardScores();
    }

    public void AddScoreBoardScores()
    {
        string saved = PlayerPrefs.GetString("HighScores", "");

        if (!string.IsNullOrEmpty(saved))
        {
            string[] split = saved.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                string score = split[i];
                TMP_Text scoreText = Instantiate(highScoreText, scoresGroup.transform, false);
                scoreText.text = $"{i + 1}: {score}";
            }
        }
    }
}
