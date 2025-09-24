using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy the pipe when it's off-screen to save memory
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}