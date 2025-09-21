using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxWidth;
    public Camera cam;
    private Rigidbody2D rb2d;
    private Renderer playerRenderer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<Renderer>();

        if (cam == null)
        {
            cam = Camera.main;
        }

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, Mathf.Abs(cam.transform.position.z));
        Vector3 targetWorldCorner = cam.ScreenToWorldPoint(upperCorner);
        float playerHalfWidth = playerRenderer.bounds.extents.x;

        maxWidth = targetWorldCorner.x - playerHalfWidth * 1.2f;
    }

    void FixedUpdate()
    {
        Vector3 rawMousePosition = Input.mousePosition;
        rawMousePosition.z = Mathf.Abs(cam.transform.position.z);

        Vector3 worldMousePosition = cam.ScreenToWorldPoint(rawMousePosition);

        float clampedX = Mathf.Clamp(worldMousePosition.x, -maxWidth, maxWidth);

        Vector2 targetPosition = new Vector2(clampedX, rb2d.position.y);
        rb2d.MovePosition(targetPosition);

        // -- FINAL SAFE FLIP CODE --
        Vector3 localScale = transform.localScale;

        if (Input.GetAxis("Mouse X") > 0.01f)
        {
            localScale.x = -Mathf.Abs(localScale.x); // Face left
        }
        else if (Input.GetAxis("Mouse X") < -0.01f)
        {
            localScale.x = Mathf.Abs(localScale.x); // Face right
        }
    }

}
