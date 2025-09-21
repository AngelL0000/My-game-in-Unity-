using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    private float maxWidth;
    public Camera cam;
    public GameObject ball;
    public float timeLeft;
    public Text timerText;
    public GameObject gameOverText;
    public GameObject restartButton;

    private Renderer ballRenderer;

    // Start is called before the first frame update
    void Start()
    {
       
        ballRenderer = ball.GetComponent<Renderer>();


        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = ballRenderer.bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth / 2;
        UpdateTimerText();
        StartCoroutine (Spawn());

    }
     void FixedUpdate()
    {
        timeLeft -= Time.fixedDeltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        timerText.text = "Time Left: " + Mathf.RoundToInt(timeLeft).ToString();
    }
     void UpdateTimerText()
    {
        timerText.text = "Time Left: " + Mathf.RoundToInt(timeLeft).ToString();
    }


    //Coroutine
    // A coroutine is like a function that has the ability to pause execution and return control to unity, but 
    //then to contine where it left off on the following frame.
    // A coroutine can be thought of as a function that is executed in intervals
    //put another ways it is a special type of function used in unity to stop the execution until sometime 
    //or certain condition is met and condition is met and continues from where it had left off.
    //with coroutines you don't have to poll for values every frame.

    IEnumerator Spawn()
    {
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 camUpperRightCorner = cam.ScreenToWorldPoint(upperCorner);

        yield return new WaitForSeconds(0.2f);

        while (timeLeft>0)
        {
            Vector3 spawnPosition = new Vector3(
          Random.Range(-maxWidth, maxWidth),
          camUpperRightCorner.y + 1.0f,
          0.0f);


          Quaternion spawnRotation= Quaternion.identity;
            Instantiate (ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.1f));
        
        
        
        }
        yield return new WaitForSeconds(1.0f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds (1.0f);
        restartButton.SetActive(true);


        
    }




}
