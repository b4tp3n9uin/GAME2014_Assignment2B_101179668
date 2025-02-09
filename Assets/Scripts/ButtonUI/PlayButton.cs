﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    /*
* Source File Name: PlayButton.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 11/28/2020
* Program Description: Button Script to touch the button to go to the Game Level Scene.
* Modifications: Set the score back to 0 when you hit the Play Again Button.
*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonPressed()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        ScoreSystem.score = 0; // Set score back to 0 when you play again.
        SceneManager.LoadScene("GameScene");
        Debug.Log("Game Pressed");
    }
}
