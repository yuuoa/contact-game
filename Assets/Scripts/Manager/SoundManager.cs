using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundManager
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    public bool loop;
    public bool PlayOnAwake;

    [HideInInspector]
    public AudioSource source;
}
