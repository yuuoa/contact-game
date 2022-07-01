using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public GameObject IsAcquired, IsNotAcquired, KeyObject;
    void Update()
    {
        KeyObject = GameObject.FindWithTag("Key");
        if(KeyObject == null)
        {
            if(IsNotAcquired != null && IsAcquired == null)
            {
                IsNotAcquired.SetActive(false);
                IsAcquired.SetActive(true);
            }
        }
        else if(KeyObject != null)
        {
            if(IsNotAcquired == null && IsAcquired != null)
            {
                IsNotAcquired.SetActive(true); 
                IsAcquired.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<SFXManager>().Play("Key");
            Destroy(gameObject);
        }
    }
}
