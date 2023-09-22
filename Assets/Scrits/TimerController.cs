using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    private float timeElapsed = 0;
    private bool timeIsRunning = false;
    public TMP_Text timeText;

    

    void Start()
    {
        timeIsRunning = true;
    }

    void Update()
    {
        if (timeIsRunning)
        {
           timeElapsed += Time.deltaTime;
           DisplayTime();
        }
    }

    void DisplayTime()
    {
        float minutes = getMinutes(timeElapsed);
        float seconds = getSeconds(timeElapsed);
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
