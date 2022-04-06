using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finisher : MonoBehaviour
{

    private Scene scene;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Sword"))
        {
            scene = SceneManager.GetActiveScene();

            if (scene.name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (scene.name == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }
            else if (scene.name == "Level3")
            {
                SceneManager.LoadScene("BossLevel");
            }
        }
    }
}
