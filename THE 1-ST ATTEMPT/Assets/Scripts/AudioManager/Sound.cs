using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    [HideInInspector]
    public AudioSource source;

    public AudioClip clip;
    public string name;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;
    public bool onAwake;
}
