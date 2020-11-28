using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    /*
* Source File Name: PlayButton.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 11/16/2020
* Program Description: Button Script to touch the button to go to the Game Level Scene.
* Modifications: Made a OnPressed Function to go to the Game Level Scene
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

        SceneManager.LoadScene("GameScene");
        Debug.Log("Game Pressed");
    }
}
