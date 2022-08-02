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

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        // Set variables
        moveSpeed = 2f;
        jumpForce = 15f;
        isJumping = false;
        jumpCount = 2;
    }

    // Update is called once per frame
    void Update()
    {

        // Check for input
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetKeyDown(KeyCode.Space);
        
        // Vertical movement
        if (jumpCount != 0 && moveVertical == true)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            // lowers jumpCount by 1 for each "space" jump
            jumpCount--;
            animator.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        bool flipped = moveHorizontal < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

        // Horizontal movement
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
            // Resets jumpCount
            jumpCount = 2;

            animator.SetBool("IsJumping", false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Ground Exit
        if (collision.gameObject.tag == "Platform")
        {
                isJumping = true;
        }
    }

}
