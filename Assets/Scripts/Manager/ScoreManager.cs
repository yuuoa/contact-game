using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private Scene scene;
    public int Score;
    public int HighScore;
    private Text ScoreText;
    private int NowLevel;
    void Start()
    {
        NowLevel = GameObject.Find("LevelManager").GetComponent<LevelManager>().LevelNow;
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        scene = SceneManager.GetActiveScene();
        if (NowLevel == 1)
        {
            Score = 0;
        }
        if (NowLevel > 1)
        {
            Score = PlayerPrefs.GetInt("Score");
        }
    }

    void Update()
    {
        if (scene.name == "LevelMain1" || scene.name == "LevelMain2" || scene.name == "LevelMain3")
        {   
            ScoreText.text = "Score : " + Score.ToString();        
            PlayerPrefs.SetInt("Score", Score);
        }
        if (scene.name == "MainMenu")
        {
            HighScore = PlayerPrefs.GetInt("HighScore");
            ScoreText.text = "High Score : " + HighScore.ToString();
        }
    }
    
    public void UpdateScore(int mod)
    {
        Score += mod;
        PlayerPrefs.SetInt("Score", Score);
        HighScore = PlayerPrefs.GetInt("HighScore");
        if (HighScore < Score)
        {
            HighScore = Score;
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
    }

    public void DeleteScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
