using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Source File Name: ScoreSystem.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 11/30/2020
* Program Description: Score System Script to set the Score Value and Text on the Game HUD.
* Modifications: Update the Score Values and render the score on the text in the HUD.
*/

public class ScoreSystem : MonoBehaviour
{

    public static int score = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
