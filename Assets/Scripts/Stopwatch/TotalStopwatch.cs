using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TotalStopwatch : MonoBehaviour
{
    public Text StopwatchText;
    bool StopwatchActive = false;
    public float PCGTime, OPLTime, CurrentTime;

    void Start()
    {
        PCGTime = GameObject.Find("PCG").GetComponent<PCGStopwatch>().CurrentTime;
        OPLTime = GameObject.Find("OPL").GetComponent<OPLStopwatch>().CurrentTime;
    }

    void FixedUpdate()
    {
        CurrentTime = OPLTime + PCGTime;
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        StopwatchText.text = time.ToString(@"mm\:ss\:ffffff");
    }
}
