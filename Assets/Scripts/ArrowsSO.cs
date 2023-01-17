using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Arrows", menuName = "ScriptableObjects/ArrowsSO", order = 1)]
public class ArrowsSO : ScriptableObject
{
    [SerializeField] int arrows = 0;



   

    public void AddToArrows(int arrowsToAdd)
    {
        arrows += arrowsToAdd;

    }

    public void ArrowShooted() {
        arrows--;
    }

    public int GetArrows()
    {
        return arrows;
    }

    public void SetArrows()
    {
        arrows = 0;
    }
}
