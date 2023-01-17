using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ScoreManager : ScriptableObject

   
{

    [SerializeField] int score = 0;

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
      
    }

    public int GetScore() {
        return score;
    }

    public void SetScore() {
        score = 0;
    }

    
}
