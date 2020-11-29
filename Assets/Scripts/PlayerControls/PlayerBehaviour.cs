using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Renderer")]
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [Header("Lives")]
    public int lives;
    public GameObject lives1;
    public GameObject lives2;
    public GameObject lives3;
    public GameObject lives4;
    public GameObject lives5;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        lives = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        SetLives();
        Move();
    }

    void SetLives()
    {
        if (lives > 5)
        {
            lives = 5;
        }

        switch (lives)
        {
            case 5:
                lives1.SetActive(true);
                lives2.SetActive(true);
                lives3.SetActive(true);
                lives4.SetActive(true);
                lives5.SetActive(true);
                break;
            case 4:
                lives1.SetActive(true);
                lives2.SetActive(true);
                lives3.SetActive(true);
                lives4.SetActive(true);
                lives5.SetActive(false);
                break;
            case 3:
                lives1.SetActive(true);
                lives2.SetActive(true);
                lives3.SetActive(true);
                lives4.SetActive(false);
                lives5.SetActive(false);
                break;
            case 2:
                lives1.SetActive(true);
                lives2.SetActive(true);
                lives3.SetActive(false);
                lives4.SetActive(false);
                lives5.SetActive(false);
                break;
            case 1:
                lives1.SetActive(true);
                lives2.SetActive(false);
                lives3.SetActive(false);
                lives4.SetActive(false);
                lives5.SetActive(false);
                break;
            default:
                lives1.SetActive(false);
                lives2.SetActive(false);
                lives3.SetActive(false);
                lives4.SetActive(false);
                lives5.SetActive(false);
                break;
        }
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

        if (other.gameObject.CompareTag("Walls"))
        {
            rigidBody.AddForce(Vector3.up * 80.0f);
            Debug.Log("Hit Wall");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            lives--;
            transform.position = SpawnPoint.position;
        }

        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            lives++;
            rigidBody.AddForce(Vector3.up * 50.0f);
        }

        if (other.gameObject.CompareTag("Cherry"))
        {
            Destroy(other.gameObject);
            CherryScript.cherry++;
            rigidBody.AddForce(Vector3.up * 50.0f);
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
            lives--;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            if (CherryScript.cherry == 8)
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
