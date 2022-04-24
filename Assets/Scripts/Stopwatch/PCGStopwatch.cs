using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PCGStopwatch : MonoBehaviour
{
    public Text StopwatchText;
    public float CurrentTime = 0;
    bool StopwatchActive = false;

    void FixedUpdate()
    {
        if (StopwatchActive == true)
        {
            CurrentTime = CurrentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        StopwatchText.text = ("PCG Time: " + time.ToString(@"mm\:ss\:ffffff"));
    }

    public void StopwatchStart()
    {
        StopwatchActive = true;
    }

    public void StopwatchStop()
    {
        StopwatchActive = false;
    }
}