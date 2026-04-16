using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    void Start()
    {
        ScoreManager.Instance.HighScoreUpdate(finalScoreText, highScoreText);
    }
}
