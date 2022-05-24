using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

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
        else if (scene.name == "LevelMain")
        {
            LevelNow = PlayerPrefs.GetInt("LevelNow");
            Debug.Log(LevelNow);      
        }

    }

    public void LevelFinish()
    {
        LevelNow += 1;
        PlayerPrefs.SetInt("LevelNow", LevelNow);
        SceneManager.LoadScene("LevelMain");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
