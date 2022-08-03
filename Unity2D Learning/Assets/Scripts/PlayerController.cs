using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float moveSpeed;
    private float jumpForce;
    private float jumpCount;
    private bool isJumping;
    private float moveHorizontal;
    private bool moveVertical;
    private bool isFacingRight = true;
    private Vector3 spawnPoint;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {   
        // Set variables
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 2f;
        jumpForce = 15f;
        isJumping = false;
        jumpCount = 2;
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Check for input
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetKeyDown(KeyCode.Space);
        
        // Vertical movement
        if (jumpCount != 0 && moveVertical == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            // lowers jumpCount by 1 for each "space" jump
            jumpCount--;
            animator.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate()
    {
        // Horizontal movement
        if (moveHorizontal > 0 || moveHorizontal < 0)
        {
            rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (moveHorizontal > 0 && !isFacingRight)
        {
            Flip();
        }

        if (moveHorizontal < 0 && isFacingRight)
        {
            Flip();
        }
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Groundcheck
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJumping = false;
            // Resets jumpCount
            jumpCount = 2;

            animator.SetBool("IsJumping", false);
        }

        if (collision.gameObject.CompareTag("Border"))
        {
            gameObject.transform.position = spawnPoint;
        }

        if(collision.gameObject.CompareTag("Currency"))
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Ground Exit
        if (collision.gameObject.CompareTag("Platform"))
        {
                isJumping = true;
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        isFacingRight = !isFacingRight;
    }

}
