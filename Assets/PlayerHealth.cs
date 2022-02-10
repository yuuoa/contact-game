using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float Health = 100f;
    private float MaxHealth = 100f;

    Text info_Heart;


    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        //Health = PlayerPrefs.GetFloat("Health");
        Debug.Log(Health);
        info_Heart = GameObject.Find("UIHealth").GetComponent<Text>();
    }

    void Update()
    {
        info_Heart.text = "Health : " + Health.ToString();
        //PlayerPrefs.SetFloat("Health", Health);
    }

    // Update is called once per frame
    public void UpdateHealth(float mod)
    {
        Health += mod;

        if (Health > MaxHealth)
            Health = MaxHealth;
        else if (Health <= 0f) 
        {
            Health = 0f;
            Destroy(gameObject);
            finisher.ResetScene();
        }
        Debug.Log("Health = " + Health);

    }
}
