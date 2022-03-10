using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float Health;
    private float MaxHealth = 100f;

    Text info_Heart;
    public GameObject GameOverUI;

    private int level;

    // Start is called before the first frame update
    void Start()
    {
        info_Heart = GameObject.Find("UIHealth").GetComponent<Text>();
        Health = MaxHealth;
        Health = PlayerPrefs.GetFloat("Health");
        // Debug.Log(Health);
    }

    void Update()
    {
        level = GameObject.FindGameObjectWithTag("Finish").GetComponent<finisher>().GameLevel;
        info_Heart.text = "Health : " + Health.ToString();
        // PlayerPrefs.SetFloat("Health", Health);
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
            GameOverUI.SetActive(true);
            Debug.Log(level);
        }
        // Debug.Log("Health = " + Health);
    }
}
