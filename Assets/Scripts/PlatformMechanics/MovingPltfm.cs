using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Source File Name: MovingPltfm.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 12/7/2020
* Program Description: Script for Moving Platform Behaviour.
* Modifications: Added a script for the Platform to move Vertically.
*/

public class MovingPltfm : MonoBehaviour
{
    public float dirY;
    public float moveSpeed;
    public bool moveUp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 4.0f)
        {
            moveUp = false;
        }
        else if (transform.position.y < -4.0f)
        {
            moveUp = true;
        }

        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
}
