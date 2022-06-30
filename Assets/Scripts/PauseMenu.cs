using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private float health;
    private int NowLevel;
    public static bool isPause = false;
    public GameObject PauseMenuUI;
    void Start()
    {
        NowLevel = GameObject.Find("LevelManager").GetComponent<LevelManager>().LevelNow;
        health = GameObject.Find("Player").GetComponent<HealthManager>().Health;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
                Resume();
            else
                Pause();
        }
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void MainMenu()
    {
        NowLevel = 1;
        PlayerPrefs.SetInt("LevelNow", NowLevel);
        PauseMenuUI.SetActive(false);
        isPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log(NowLevel);
    }

    public void Retry()
    {
        DungeonLadder.ResetScene();
        health = 100f;
        PlayerPrefs.SetFloat("Health", health);
    }
}
