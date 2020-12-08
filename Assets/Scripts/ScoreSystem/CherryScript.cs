using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Source File Name: CherryScript.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 11/29/2020
* Program Description: Cherry Counter Script
* Modifications: Update the Cherry COunter Values and render the Cherry Counter on the text in the HUD.
*/

public class CherryScript : MonoBehaviour
{

    public static int cherry;
    Text cherryText;

    // Start is called before the first frame update
    void Start()
    {
        cherryText = GetComponent<Text>();
        cherry = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cherryText.text = cherry+ "/8";
    }
}
