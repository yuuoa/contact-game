using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    [SerializeField] Image OnIcon;
    [SerializeField] Image OffIcon;
    public SoundManager[] sounds;
    public static SFXManager instance;
    public bool muted;

    void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        ButtonIcon();
        AudioListener.pause = muted;
    }

    public void SFXActiveButton()
    {
        if (muted == true)
        {
            muted = false;
            this.gameObject.SetActive(true);
        }
        else
        {
            muted = true;
            this.gameObject.SetActive(false);
        }
        Save();
        ButtonIcon();
    }

    public void ButtonIcon()
    {
        if (muted == true)
        {
            OnIcon.enabled = false;
            OffIcon.enabled = true;
        }
        else
        {
            OnIcon.enabled = true;
            OffIcon.enabled = false;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
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
            s.source.playOnAwake = s.PlayOnAwake;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    public void Play (string name)
    {
        SoundManager s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
