using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStatus : MonoBehaviour
{
    public GameObject IsAcquired;
    public GameObject IsNotAcquired;
    public GameObject KeyObject;
    void Update()
    {
        KeyObject = GameObject.FindWithTag("Key");
        if(KeyObject == null)
        {
            IsNotAcquired.SetActive(false);
            IsAcquired.SetActive(true);
        }
        else if(KeyObject != null)
        {
            IsNotAcquired.SetActive(true); 
            IsAcquired.SetActive(false);
        }
    }
}