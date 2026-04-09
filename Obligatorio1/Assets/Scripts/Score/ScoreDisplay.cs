using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        if (ScoreManager.Instance == null)
        {
            Debug.LogError("No ScoreManager in scene");
            enabled = false;
            return;
        }

        ScoreManager.Instance.ScoreChanged += UpdateScore;
        UpdateScore(ScoreManager.Instance.CurrentScore);
    }

    private void OnDestroy()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ScoreChanged -= UpdateScore;
        }
    }

    private void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }
}