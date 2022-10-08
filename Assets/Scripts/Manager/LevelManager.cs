using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public Text LevelText;
    private Scene scene;
    public int LevelNow;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "MainMenu")
        {
            PlayerPrefs.DeleteKey("LevelNow");
            LevelNow = 0;
            PlayerPrefs.SetInt("LevelNow", LevelNow);
            FindObjectOfType<BGMManager>().Stop("LevelMain");
            FindObjectOfType<BGMManager>().Play("MainMenu");
        }
        else if (scene.name == "LevelMain1" || scene.name == "LevelMain2" || scene.name == "LevelMain3")
        {
            PlayerPrefs.GetInt("LevelNow");
            FindObjectOfType<BGMManager>().Stop("MainMenu");
            FindObjectOfType<BGMManager>().Play("LevelMain");
        }
    }

    public void LevelFinish()
    {
        int index = Random.Range(1, 3);
        SceneManager.LoadScene(index);
    }

    public void UpdateLevel(int mod)
    {
        LevelNow += mod;
        PlayerPrefs.SetInt("LevelNow", LevelNow);
        if (LevelNow < 0)
        {
            LevelNow = 0;
        }
    }

    private void Update()
    {
        LevelText.text = "Level " + LevelNow.ToString();
    }

    public static void ResetScene()
    {
        int index = Random.Range(1, 3);
        SceneManager.LoadScene(index);
    }
}
