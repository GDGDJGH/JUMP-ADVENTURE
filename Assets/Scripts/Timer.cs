using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeLimit = 5f;
    float timerValue;
    bool isCounting = false;
    public TextMeshProUGUI timerText;

    private void Update()
    {
        UpdateTimer();
        
    }

    void UpdateTimer() {
        timerValue -= Time.deltaTime;
        if (isCounting)
        {
            if (timerValue <= 0)
            {
                isCounting = false;
                Debug.Log("Jsi mrtvý píèo");
                FindObjectOfType<PlayerMovement>().OtherDie();
            }
        }
        else {
            if (timerValue <= 0)
            {
                isCounting = true;
                timerValue = timeLimit;
                
            }

        }
        timerText.text = timerValue.ToString("0");



    }
}
