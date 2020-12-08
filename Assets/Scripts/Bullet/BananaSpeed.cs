using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Source File Name: BananaSpeed.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 12/6/2020
* Program Description: Banana Bullet Bheaviour Script.
* Modifications: Added the Bullet velocity, and made the OnCollision Enter to kill Enemy, or destroy bullet when it collides with anything.
*/

public class BananaSpeed : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody;

    public GameObject banana;
    public float bulletVelX = 5.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (FireButton.facingRight)
        {
            rigidbody.velocity = new Vector2(bulletVelX, 0.0f);
            spriteRenderer.flipX = false;
        }
        else
        {
            rigidbody.velocity = new Vector2(-bulletVelX, 0.0f);
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            ScoreSystem.score = ScoreSystem.score + 75;
            FindObjectOfType<AudioManager>().Play("killEnemy");
            Destroy(banana);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = Vector2.up;
            Destroy(banana);
        }
        else
        {
            Destroy(banana);
        }
    }
}
