using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finisher : MonoBehaviour
{
    public LevelManager levelManager;
    private Scene scene;
    private float health;
    public GameObject KeyRequiredDialog, KeyObject;
    // public Stopwatch stopwatch;

    void Start()
    {
        health = GameObject.Find("Player").GetComponent<HealthManager>().Health;
        KeyObject = GameObject.FindWithTag("Key");
    }

    public static void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // stopwatch.StopwatchReset();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (KeyObject == null)
            {
                KeyRequiredDialog.SetActive(false);
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
                else if (scene.name == "LevelMain")
                {
                    levelManager.LevelFinish();
                }
            }
            else if (KeyObject != null)
            {
                StartCoroutine(Timing());
            }
        }
    }

    public IEnumerator Timing()
    {
        KeyRequiredDialog.SetActive(true);
        yield return new WaitForSeconds(1f);
        KeyRequiredDialog.SetActive(false);
    }
}