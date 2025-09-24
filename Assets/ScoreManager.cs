using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    private int score = 0;
    private int highScore = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Load the saved high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public int GetCurrentScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void CheckHighScore()
    {
        // If the current score is higher than the saved high score, update it
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);  // Save the new high score
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore();
            BirdController birdController = other.GetComponent<BirdController>();
            if (birdController != null)
            {
                birdController.PlayScoreSound();  // Play score sound
            }
        }
    }
}
