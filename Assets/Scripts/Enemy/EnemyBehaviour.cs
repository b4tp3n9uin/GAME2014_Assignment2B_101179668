using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Controls")]
    public float runForce;
    public bool isGroundAhead;

    public LayerMask CollisionLayer;

    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public Transform LookAheadPoint;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.flipX = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAhead();
        Move();
    }

    private void LookAhead()
    {
        isGroundAhead = Physics2D.Linecast(transform.position, LookAheadPoint.position, CollisionLayer);

        Debug.DrawLine(transform.position, LookAheadPoint.position, Color.green);
    }

    private void Move()
    {
        if (isGroundAhead == true)
        {
            rigidBody.AddForce(Vector2.left * runForce * transform.localScale.x);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
        }
    }
}
