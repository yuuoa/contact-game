using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool isSettings = false;
    public GameObject SettingsUI;
    public GameObject MainMenuUI;
    public int LevelAdder = -1000000;

    void Awake()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().UpdateLevel(+LevelAdder);
    }
    void Start()
    {
        PlayerPrefs.DeleteKey("LevelNow");
        SettingsUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene("LevelMain");
    }

    public void Settings()
    {
        isSettings = true;
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void Back()
    {
        isSettings = false;
        MainMenuUI.SetActive(true);
        SettingsUI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
