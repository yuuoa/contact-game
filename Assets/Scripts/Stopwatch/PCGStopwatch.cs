using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PCGStopwatch : MonoBehaviour
{
    public Text PCGStopwatchText;
    public float CurrentTime;
    bool StopwatchActive = false;

    void Start()
    {
        CurrentTime = 0;
    }

    void Update()
    {
        {
            if (StopwatchActive == true)
            {
                CurrentTime = CurrentTime + Time.deltaTime;
            }
            TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
            PCGStopwatchText.text = time.ToString(@"mm\:ss\:fff");
        }
    }

    public void StopwatchStart()
    {
        StopwatchActive = true;
    }

    public void StopwatchStop()
    {
        StopwatchActive = false;
    }

    public void StopwatchReset()
    {
        CurrentTime = 0;
        PCGStopwatchText.text = "00:00:000";
    }


    // private float elapsedRunningTime = 0f;
    // private float runningStartTime = 0f;
    // private float pauseStartTime = 0f;
    // private float elapsedPausedTime = 0f;
    // private float totalElapsedPausedTime = 0f;
    // private bool running = false;
    // private bool paused = false;
      
    // void FixedUpdate()
    // {
    //     if (running)
    //     {
    //         elapsedRunningTime = Time.time - runningStartTime - totalElapsedPausedTime;
    //     }
    //     else if (paused)
    //     {
    //         elapsedPausedTime = Time.time - pauseStartTime;
    //     }
    // }
    //    public void Begin()
    // {
    //     if (!running && !paused)
    //     {
    //         runningStartTime = Time.time;
    //         running = true;
    //     }
    // }
    //    public void Pause()
    // {
    //     if (running && !paused)
    //     {
    //         running = false;
    //         pauseStartTime = Time.time;
    //         paused = true;
    //     }
    // }

    // public void Unpause()
    // {
    //     if (!running && paused)
    //     {
    //         totalElapsedPausedTime += elapsedPausedTime;
    //         running = true;
    //         paused = false;
    //     }
    // }
  
    // public void Reset()
    // {
    //     elapsedRunningTime = 0f;
    //     runningStartTime = 0f;
    //     pauseStartTime = 0f;
    //     elapsedPausedTime = 0f;
    //     totalElapsedPausedTime = 0f;
    //     running = false;
    //     paused = false;
    // }

    // public int GetMinutes()
    // {
    //     return (int)(elapsedRunningTime / 60f);
    // }

    // public int GetSeconds()
    // {
    //     return (int)(elapsedRunningTime);
    // }

    // public float GetMilliseconds()
    // {
    //     return (float)(elapsedRunningTime - System.Math.Truncate(elapsedRunningTime));
    // }
    // public float GetRawElapsedTime()
    // {
    //     return elapsedRunningTime;
    // }
}
