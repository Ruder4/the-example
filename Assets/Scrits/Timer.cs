using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    // Time remaining in seconds
    private float timeRemaining = 180;

    private bool timeIsRunning = false;
    public TMP_Text timeText;



    void Start()
    {
        timeIsRunning = true;
    }

    void Update()
    {
        if (timeIsRunning == true)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime();
        }

        if (timeRemaining <= 1)
        {
            timeIsRunning = false;
        }
    }

    void DisplayTime()
    {
        float minutes = getMinutes(timeRemaining);
        float seconds = getSeconds(timeRemaining);
        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public float getMinutes(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        return minutes;
    }

    float getSeconds(float timeToDisplay)
    {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return seconds;
    }

}