using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterTime : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI counterText;

    [SerializeField]
    private float timeRemaining = 10;

    private bool timerIsRunning = false;

    private float timerfloat;
    private float timer = 0;
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;
        }

        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (!(Time.timeScale == 0))
            counterText.text = string.Format("{0:00}", seconds);
        else counterText.text = "";
    }

    public void setStatusCounter(bool a)
    {
        counterText.enabled = a;
    }

    public bool getStatusCounter()
    {
        return timerIsRunning;
    }

    public float getTimeRemain()
    {
        return timeRemaining;
    }


}
