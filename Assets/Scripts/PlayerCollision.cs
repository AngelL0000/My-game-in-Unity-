using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameControllerScript gameController;

    private Rigidbody2D rb;
    private PlayerController playerController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.name.Contains("Ball"))
        {
            if (gameController != null)
            {
                gameController.timeLeft = 0;

                // Freeze falling and disable movement script
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0;
                if (playerController != null)
                {
                    playerController.enabled = false;
                }
            }
        }
    }
}
