using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OPLStopwatch : MonoBehaviour
{
    public Text OPLStopwatchText;
    public float CurrentTime = 0;
    bool StopwatchActive = false;

    void Update()
    {
        if (StopwatchActive == true)
        {
            CurrentTime = CurrentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        OPLStopwatchText.text = ("OPL Time: " + time.ToString(@"mm\:ss\:ffffff"));
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