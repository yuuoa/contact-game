using UnityEngine.Audio;
using System;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public SoundManager[] sounds;
    public static BGMManager instance;
    public bool isActive = true;

    public void ActiveStatus()
    {
        if (isActive == true)
            this.gameObject.SetActive(true);
        else
            this.gameObject.SetActive(false);
    }

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

        foreach (SoundManager s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    public void Play (string name)
    {
        SoundManager s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop (string name)
    {
        SoundManager s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}