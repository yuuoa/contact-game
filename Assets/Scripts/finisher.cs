using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finisher : MonoBehaviour
{

    public int GameLevel;

    private float health;

    // Start is called before the first frame update
    void Start()
    {
        GameLevel = PlayerPrefs.GetInt("GameLevel");
        Debug.Log("level " + GameLevel);
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Health;
        if (GameLevel == 0)
        {
            health = 100f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetLevel()
    {
        GameLevel = 0;
        PlayerPrefs.SetInt("GameLevel", GameLevel);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameLevel += 1;
        PlayerPrefs.SetInt("GameLevel", GameLevel);
        if (collision.CompareTag("Player") || collision.CompareTag("Sword"))
        {
            
            ResetScene();
        }
    }
}
