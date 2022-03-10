using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPause = false;
    public GameObject PauseMenuUI;
    
    private int level;

    void Update()
    {
        level = GameObject.FindGameObjectWithTag("Finish").GetComponent<finisher>().GameLevel;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            
            {
                Resume();
            }
            else
            {
                Pause();
            }
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
        SceneManager.LoadScene("MainMenu");
        level = 0;
        PlayerPrefs.SetInt("GameLevel", level);
    }

    public void Retry()
    {
        finisher.ResetScene();
    }
}
