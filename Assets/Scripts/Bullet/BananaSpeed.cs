using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
