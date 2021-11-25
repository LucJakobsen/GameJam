using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
// this code was shamelessly stolen from Brackeys video: https://www.youtube.com/watch?v=6OT43pvUyfY 
public class AudioManager : MonoBehaviour
{
    // Adds the mixer and the array to the inspector in Unity 
    public AudioMixer audioMixer;
    public Sound[] sounds;  
    // Start is called before the first frame update
    void Awake()
    { 
        // Each sound in the array gets these options for audio configuration 
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.audioMikser;
        }
        
    }

    // This method is used to call one of the sounds as long as the string name matches the file name for the sound 
    // The function works with 'FindObjectOfType<AudioManager>().Play(string name)' in the other scripts 
    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    
}
