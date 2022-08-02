using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    private float jumpForce;
    private float jumpCount;
    private bool isJumping;
    private float moveHorizontal;
    private bool moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        // Set variables
        moveSpeed = 1f;
        jumpForce = 5f;
        isJumping = false;
        jumpCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetKeyDown(KeyCode.Space);
        
        if (jumpCount != 0 && moveVertical == true)
        {
                rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                jumpCount--;
        }
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < 0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Groundcheck
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
            jumpCount = 2;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
                isJumping = true;
        }
    }

}
