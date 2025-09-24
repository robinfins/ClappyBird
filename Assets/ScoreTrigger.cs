using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore();  // Call AddScore when the bird passes
        }
        
        // Get the BirdController and play the score sound
        BirdController birdController = other.GetComponent<BirdController>();
        if (birdController != null)
        {
            birdController.PlayScoreSound();  // Play the score sound here
        }
    }
}