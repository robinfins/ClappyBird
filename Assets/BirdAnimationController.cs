using UnityEngine;

public class BirdAnimationController : MonoBehaviour
{
    public Sprite flapSprite1;  // First sprite (bird with wings up)
    public Sprite flapSprite2;  // Second sprite (bird with wings down)
    private SpriteRenderer spriteRenderer;
    private bool isFlapping = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = flapSprite1;  // Start with the first sprite
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartFlap();
        }
    }

    void StartFlap()
    {
        if (!isFlapping)
        {
            isFlapping = true;
            // Switch to second sprite when flapping
            spriteRenderer.sprite = flapSprite2;
            Invoke("EndFlap", 0.1f);  // Switch back after 0.1 second
        }
    }

    void EndFlap()
    {
        // Switch back to first sprite after the flap
        spriteRenderer.sprite = flapSprite1;
        isFlapping = false;
    }
}