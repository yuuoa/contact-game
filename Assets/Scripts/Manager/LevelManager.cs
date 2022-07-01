using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    
    private Scene scene;
    public int LevelNow;
    public GameObject SFXMan;
    public GameObject BGMMan;

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
            if (SFXMan != null)
            {
                FindObjectOfType<BGMManager>().Stop("LevelMain");
                FindObjectOfType<BGMManager>().Play("MainMenu");
            }
            LevelNow = 1;
            PlayerPrefs.SetInt("LevelNow", LevelNow);
        }
        else if (scene.name == "LevelMain")
        {
            if (SFXMan != null)
            {
                FindObjectOfType<BGMManager>().Stop("MainMenu");
                FindObjectOfType<BGMManager>().Play("LevelMain");
            }
        }
    }

    public void LevelFinish()
    {
        LevelNow = LevelNow + 1;
        PlayerPrefs.SetInt("LevelNow", LevelNow);
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("LevelMain");
    }

    private void Update()
    {
        Debug.Log(LevelNow);
    }
}
