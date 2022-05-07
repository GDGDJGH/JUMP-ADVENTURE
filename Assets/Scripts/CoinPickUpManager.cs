using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class CoinPickUpManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreManager score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.GetScore().ToString();
    }

    public void resetScore()
    {
        score.SetScore();
    }
}
