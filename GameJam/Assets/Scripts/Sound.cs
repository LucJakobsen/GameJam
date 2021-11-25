using UnityEngine.Audio;
using UnityEngine;

// This makes everything visiable from the inspector
[System.Serializable]
public class Sound
{
    // This is what is in each array. The class gets called in the 'AudioManager' Script for the array
    public string name; 
    public AudioClip clip;
    public AudioMixerGroup audioMikser;

    // [Range --, --] creates a slider in the inspector 
    [Range(0.0f,1.0f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;

    // Hides the audio source in the inspector, because it gets added in the 'AudioManager' Script
    [HideInInspector]
    public AudioSource source;
}
