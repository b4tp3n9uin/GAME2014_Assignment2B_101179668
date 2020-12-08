using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Source File Name: DestroyBullet.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 11/30/2020
* Program Description: Script to destroy the banana bullet.
* Modifications: Call the Destroy function to destroy the banana bullets in 2 seconds after they are instanciated.
*/

public class DestroyBullet : MonoBehaviour
{
    [SerializeField]
    public float destroyTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
