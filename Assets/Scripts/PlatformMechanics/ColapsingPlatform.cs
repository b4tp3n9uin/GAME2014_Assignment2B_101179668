using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Source File Name: ColapsingPlatform.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 12/7/2020
* Program Description: Script for the Colapsing Platform
* Modifications: Added an OnCollisionEnter function to make the platform disapear after a second you collide with it. 
*/

public class ColapsingPlatform : MonoBehaviour
{

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("CollapsePlatform", 1.0f);
            Destroy(gameObject, 2.0f);
        }
    }

    void CollapsePlatform()
    {
        rigidbody.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
