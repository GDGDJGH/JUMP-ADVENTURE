using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class CoinPickUpManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreManager score;

    void Update()
    {
        scoreText.text = score.GetScore().ToString();
    }

    public void resetScore()
    {
        score.SetScore();
    }
}
