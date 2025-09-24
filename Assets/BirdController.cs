using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public float flapForce = 5f;  // The force applied when the bird "flaps"
    private Rigidbody2D rb;
    private bool isGameOver = false;
    public float tiltSmooth = 5f;  // How fast the bird tilts
    public float maxTiltAngle = 30f;  // Max tilt angle

    // UI References for Game Over screen
    public GameObject gameOverCanvas;  // Assign this in the Inspector
    public Text currentScoreText;
    public Text highScoreText;

    // Reference to the in-game ScoreText
    public GameObject scoreTextUI;  // Assign this in the Inspector

    // Audio references
    public AudioClip flapSound;  // Assign this in the Inspector
    public AudioClip collisionSound;  // Assign this in the Inspector
    public AudioClip scoreSound;  // Assign this in the Inspector
    private AudioSource audioSource;  // Reference to the AudioSource

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  // Get the AudioSource component
        gameOverCanvas.SetActive(false);  // Hide the game over screen initially
    }

    void Update()
    {
        // Allow the bird to flap only if the game is not over
        if (!isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * flapForce;
            PlayFlapSound();  // Play flap sound when jumping
        }

        // Tilt the bird based on its vertical velocity
        float tiltAngle = Mathf.Lerp(-maxTiltAngle, maxTiltAngle, (rb.linearVelocity.y + 5f) / 10f); 
        tiltAngle = Mathf.Clamp(tiltAngle, -maxTiltAngle, maxTiltAngle);

        // Smoothly rotate the bird
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, tiltAngle), tiltSmooth * Time.deltaTime);

        // Restart game on Space press when game over
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Game over logic when bird hits something
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            PlayCollisionSound();  // Play collision sound
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        rb.linearVelocity = Vector2.zero;  // Stop the bird's movement
        rb.simulated = false;  // Disable further physics on the bird

        // Hide the in-game score text
        scoreTextUI.SetActive(false);

        // Show the Game Over screen
        gameOverCanvas.SetActive(true);

        // Update current score and high score on the Game Over screen
        ScoreManager.instance.CheckHighScore();
        currentScoreText.text = "Score: " + ScoreManager.instance.GetCurrentScore();
        highScoreText.text = "High Score: " + ScoreManager.instance.GetHighScore();
    }

    void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to play the flap sound
    void PlayFlapSound()
    {
        if (flapSound != null)
        {
            audioSource.PlayOneShot(flapSound);
        }
    }

    // Method to play the collision sound
    void PlayCollisionSound()
    {
        if (collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    // You can also add a method for playing the score sound when the bird scores:
    public void PlayScoreSound()
    {
        if (scoreSound != null)
        {
            audioSource.PlayOneShot(scoreSound);
        }
    }
}
