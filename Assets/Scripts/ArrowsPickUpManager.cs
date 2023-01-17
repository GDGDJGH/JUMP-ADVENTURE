using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ArrowsPickUpManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI arrowText;
    [SerializeField] ArrowsSO arrows;
 

    void Update()
    {
        arrowText.text = arrows.GetArrows().ToString();
        
    }

    public void resetArrows()
    {
        
            arrows.SetArrows();    
    }

    public void updateArrows() {
        arrows.ArrowShooted();
    }

    public int GetArrows() {
        return arrows.GetArrows();
    }
}
