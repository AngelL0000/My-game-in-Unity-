using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    private float maxWidth;
    public Camera cam;
    private Rigidbody2D rb2d;
    private Renderer hatRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        hatRenderer = GetComponent<Renderer>();

        if (cam == null)
        {
            cam = Camera.main;
        }

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float hatWidth = hatRenderer.bounds.extents.x;
        maxWidth = targetWidth.x - hatWidth / 2;
    }

    void FixedUpdate()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, transform.position.y, 0.0f);

        float clampedX = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(clampedX, targetPosition.y, targetPosition.z);

        rb2d.MovePosition(targetPosition);

        // Flip left or right depending on mouse movement
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }
    }
}
