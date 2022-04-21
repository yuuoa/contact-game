using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class SysDiagnostics : MonoBehaviour
{
    // private static PerformanceCounter cpuCounter;
    // private static PerformanceCounter ramCounter;

    protected PerformanceCounter cpuCounter, ramCounter;

    Text Diag;

    void Start()
    {
        Diag = GameObject.Find("Sys").GetComponent<Text>();

    ramCounter = new PerformanceCounter("Memory", "Available MBytes");
    cpuCounter = new PerformanceCounter();

    cpuCounter.CategoryName = "Processor";
    cpuCounter.CounterName = "% Processor Time";
    cpuCounter.InstanceName = "_Total";
        // cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        // ramCounter = new PerformanceCounter("Memory", "Available MBytes");
    }

    // Update is called once per frame
    void Update()
    {
        Diag.text = "CPU : " + getCurrentCpuUsage() + " RAM : " + getAvailableRAM();

        // print(getCurrentCpuUsage());
        // print(getAvailableRAM()); 
    }

//     public string getCurrentCpuUsage(){
//             cpuCounter.NextValue()+"%";
// }

// public string getAvailableRAM(){
//             ramCounter.NextValue()+"Mb";
// }

    public string getCurrentCpuUsage()
    {
        return cpuCounter.NextValue()+"%";
    }

    public string getAvailableRAM()
    {
        return ramCounter.NextValue()+"MB";
    } 
}
