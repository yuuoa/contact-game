using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{
    private float HealAmount = 10f;
    private float health;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Health;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(+HealAmount);
            PlayerPrefs.SetFloat("Health", health);
            Destroy(gameObject);
        }
    }
}
