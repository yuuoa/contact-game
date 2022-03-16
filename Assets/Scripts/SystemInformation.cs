using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class SystemInformation : MonoBehaviour
{
    void CreateText()
    {
        string Env;
        if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(SystemInfo.processorType, "ARM", CompareOptions.IgnoreCase) >= 0)
        {
            if (Environment.Is64BitProcess)
                Env = "ARM64";
            else
                Env = "ARM";
        }
        else
        {
            // Must be in the x86 family.
            if (Environment.Is64BitProcess)
                Env = "x86_64";
            else
                Env = "x86";
        }

        string path = Application.dataPath + "/SystemInformation.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText (path, "");
        }
        string content =
        "System Information \n\n" + 
        "Device: " + SystemInfo.deviceName + " " + SystemInfo.deviceModel + " (" + SystemInfo.deviceType + ") \n" + 
        "Processor: " + SystemInfo.processorType + " (" + Env + ") " + SystemInfo.processorCount + " core " + SystemInfo.processorFrequency + "MHz\n" +   
        "Memory: " + SystemInfo.systemMemorySize + "MB\n" + 
        "Graphics: " + SystemInfo.graphicsDeviceVendor + " " + SystemInfo.graphicsDeviceName + " (" + SystemInfo.graphicsDeviceType + ") @" + SystemInfo.graphicsMemorySize + "MB\n" + 
        "Operating System: " + SystemInfo.operatingSystem + "\n"
        ;

        File.WriteAllText (path, content);
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
