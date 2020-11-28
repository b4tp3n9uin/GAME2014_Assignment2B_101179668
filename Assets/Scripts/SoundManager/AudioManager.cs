using UnityEngine.Audio;
using UnityEngine;
using System;

/*
* Source File Name: AudioManager.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 11/16/2020
* Creates the sound array and manages the Audio in the game.

* Modifications:  * Create an array of sounds.
                  * Create a play function so the array can find the sound name, and play it.
*/

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
