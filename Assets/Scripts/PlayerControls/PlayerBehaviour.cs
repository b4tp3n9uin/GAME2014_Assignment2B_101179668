using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Controls")]
    public Joystick joystick;
    public float joystickHorizontalSensitivity;
    public float joystickVerticalSensitivity;
    public float horizontalForce;
    public float verticleForce;
    public bool isGrounded;
    public bool isJumping;
    public Transform SpawnPoint;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (isGrounded == true)
        {
            if (joystick.Horizontal > joystickHorizontalSensitivity)
            {
                // move right
                rigidBody.AddForce(Vector3.right * horizontalForce * Time.deltaTime);
                spriteRenderer.flipX = false;
                animator.SetInteger("AnimState", (int) PlayerAnimType.RUN);
            }
            else if (joystick.Horizontal < -joystickHorizontalSensitivity)
            {
                // move left
                rigidBody.AddForce(Vector3.left * horizontalForce * Time.deltaTime);
                spriteRenderer.flipX = true;
                animator.SetInteger("AnimState", (int)PlayerAnimType.RUN);
            }
            else if (!isJumping)
            {
                // idle
                animator.SetInteger("AnimState", (int) PlayerAnimType.IDLE);
            }

            if ((joystick.Vertical > joystickVerticalSensitivity))
            {
                // jump
                rigidBody.AddForce(Vector3.up * verticleForce);
                animator.SetInteger("AnimState", (int) PlayerAnimType.JUMP);
                isJumping = true;
                Debug.Log("Jump");
            }
            else
            {
                isJumping = false;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // respawn
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            transform.position = SpawnPoint.position;
        }
    }
}
