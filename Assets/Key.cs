using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool KeyAcquired;
    // Start is called before the first frame update
    void Start()
    {
        KeyAcquired = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Sword"))
        {
            KeyAcquired = true;
        }
    }
}
