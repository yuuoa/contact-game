using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Scene scene;
    public int LevelNow;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "MainMenu")
        {
            LevelNow = 1;
            PlayerPrefs.SetInt("LevelNow", LevelNow);
        }
    }

    public void LevelFinish()
    {
        LevelNow = PlayerPrefs.GetInt("LevelNow") + 1;
        PlayerPrefs.SetInt("LevelNow", LevelNow);
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("LevelMain");
    }

    
    // private void Update()
    // {
    //     Debug.Log(LevelNow);
    // }
}
