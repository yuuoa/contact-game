using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Scene scene;
    public float Health;
    private float MaxHealth = 100f;
    Text info_Heart;
    public GameObject GameOverUI;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            Health = MaxHealth;
        }
        else if (scene.name == "Level2" || scene.name == "Level3")
        {
            Health = PlayerPrefs.GetFloat("Health");
        }
        info_Heart = GameObject.Find("UIHealth").GetComponent<Text>();
    }

    void Update()
    {
        info_Heart.text = "Health : " + Health.ToString();
        PlayerPrefs.SetFloat("Health", Health);
    }
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
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            scene = SceneManager.GetActiveScene();

            if (scene.name == "Level1" || scene.name == "Level2")
            {
                PlayerPrefs.SetFloat("Health", Health);
            }
        }
    }
}
