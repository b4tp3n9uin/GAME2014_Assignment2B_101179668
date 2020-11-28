using UnityEngine.Audio;
using UnityEngine;

/*
* Source File Name: Sound.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 11/16/2020
* Program Description: Sound Class to makes sure the sounds can be called and edited through the SoundManager in the inspector. 

* Modifications: Set the variables for sounds which are the string names for the sounds, Clip, Volume, Pitch and Audio Source.
*/

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
