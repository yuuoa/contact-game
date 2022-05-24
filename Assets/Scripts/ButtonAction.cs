using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{

    int NowLevel;
    public void Play()
    {
        SceneManager.LoadScene("LevelMain");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
