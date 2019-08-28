using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private int totalScore;

    public void SetScore(int score, bool finalOrc)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();

        if (!finalOrc && score < 0)
            scoreText.color = Color.red;
        else
            scoreText.color = Color.white;


        if (finalOrc)
        {
            scoreText.color = Color.white;
            scoreText.text = "Final Score: " + totalScore.ToString();
        }
    }
}
