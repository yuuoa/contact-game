using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OPLStopwatch : MonoBehaviour
{
    public Text OPLStopwatchText;
    public float CurrentTime1 = 0;
    bool StopwatchActive1 = false;

    void Update()
    {
        if (StopwatchActive1 == true)
        {
            CurrentTime1 = CurrentTime1 + Time.deltaTime;
        }
        TimeSpan time1 = TimeSpan.FromSeconds(CurrentTime1);
        OPLStopwatchText.text = ("OPL Time: " + time1.ToString(@"mm\:ss\:ffffff"));
    }

    public void StopwatchStart1()
    {
        StopwatchActive1 = true;
    }

    public void StopwatchStop1()
    {
        StopwatchActive1 = false;
    }
}