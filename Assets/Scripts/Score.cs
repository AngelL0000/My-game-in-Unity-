using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public int ballValue;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score =0;
        updateScore();
        
    }

    void updateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        score += ballValue;
        updateScore() ;
    }

}
