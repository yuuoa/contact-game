using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonLadder : MonoBehaviour
{
    public LevelManager levelManager;
    private Scene scene;
    private float health;
    public GameObject KeyRequiredDialog, KeyObject;

    void Start()
    {
        health = GameObject.Find("Player").GetComponent<HealthManager>().Health;
        KeyObject = GameObject.FindWithTag("Key");
    }

        public static void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (KeyObject == null)
            {
                KeyRequiredDialog.SetActive(false);
                levelManager.LevelFinish();
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