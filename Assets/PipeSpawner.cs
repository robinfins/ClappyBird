using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipeUpPrefab;   // Bottom-facing pipe
    public GameObject pipeDownPrefab; // Top-facing pipe
    public float spawnRate = 2f;      // How often pipes spawn
    public float pipeHeightOffset = 2f; // Max random vertical offset
    public float gapSize = 3f;        // The gap between the top and bottom pipes
    
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipes();
            timer = 0f;  // Reset timer
        }
    }

    void SpawnPipes()
    {
        // Random vertical offset for the gap
        float randomOffset = Random.Range(-pipeHeightOffset, pipeHeightOffset);

        // Position of the bottom pipe
        Vector3 pipeUpPosition = new Vector3(transform.position.x, transform.position.y + randomOffset, 0);
        
        // Position of the top pipe (rotated and above the bottom pipe)
        Vector3 pipeDownPosition = new Vector3(transform.position.x, transform.position.y + randomOffset + gapSize, 0);

        // Spawn the bottom pipe (facing up)
        Instantiate(pipeUpPrefab, pipeUpPosition, Quaternion.identity);

        // Spawn the top pipe (rotated 180 degrees to face down)
        Instantiate(pipeDownPrefab, pipeDownPosition, Quaternion.Euler(0, 0, 180));
    }
}