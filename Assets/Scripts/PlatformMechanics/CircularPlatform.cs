using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Source File Name: CircularPlatform.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 12/7/2020
* Program Description: Script for the Cirucular Motion Platform.
* Modifications: Created a script to make the platform move in a Ferris Wheel Motion.
*/

public class CircularPlatform : MonoBehaviour
{
    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float rotationRadius = 2.0f, angularSpeed = 2.0f;

    float posX, posY, angle = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360.0f)
        {
            angle = 0.0f;
        }
    }
}
