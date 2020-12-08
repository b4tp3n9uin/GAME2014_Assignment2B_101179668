using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Source File Name: FireButton.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 12/6/2020
* Program Description: Button Script shoot the Banana Bullet.
* Modifications: Added the Fire function to shoot the banana, whether you are facing left or right, and added shoot sound.
*/

public class FireButton : MonoBehaviour
{
    public GameObject banana;
    public static bool facingRight = true;
    public Transform barrelL; //shoot from left/
    public Transform barrelR; //shoot from right.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFireButtonPressed()
    {
        FindObjectOfType<AudioManager>().Play("shoot");
        Fire();
    }

    public void Fire()
    {
        if (facingRight) // facing right
        {
            var fireBanana = Instantiate(banana, barrelR.position, barrelR.rotation);
        }
        else // facing left
        {
            var fireBanana = Instantiate(banana, barrelL.position, barrelL.rotation);
        }
    }
}
