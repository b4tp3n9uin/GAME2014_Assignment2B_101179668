using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Source File Name: InstructionButton.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 11/16/2020
* Program Description: Button Script to touch the button to go to the Instruction Scene.
* Modifications: Made a OnPressed Function to go to the Instruction Scene
*/

public class InstructionButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInstructionButtonPressed()
    {
        FindObjectOfType<AudioManager>().Play("Select");

        SceneManager.LoadScene("HowToPlay");
        Debug.Log("Instruction Pressed");
    }
}
