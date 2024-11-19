using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //components
    private Rigidbody2D rb;
    private Animator animator;

    // movement stuff
    public float movementSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float groundCheckRadius = 0.1f;

    // input
    private float horizontalMove = 0f;

    
    // jump checks
    public Transform groundCheck;
    public LayerMask groundLayer;

    // flags
    private bool isFacingRight = true;
    private bool isJumping = false;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //handle the running animation
        if(horizontalMove != 0 && isGrounded == true)
        {
            animator.SetBool("isRunning", true);
        }
        else {
            animator.SetBool("isRunning", false);
        }


        // handles the jump animation
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
            animator.SetBool("isRunning", false);
        }

        // handles the fall animation
        if(isGrounded == false && rb.velocity.y < 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
            animator.SetBool("isRunning", false);
        }
        else{
            animator.SetBool("isFalling", false);
        }


        if(horizontalMove > 0 && !isFacingRight)
        {
            Flip();
        }
        else if(horizontalMove < 0 && isFacingRight)
        {
            Flip();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", false);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);

        // if the player pressed jump button, then do the jump
        if(isJumping == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;
        }
        

    }

    public void knockBack(float knockLeft, float knockUp)
    {
        rb.velocity = new Vector2(knockLeft, knockUp);
    }

    private void Flip()
    {

        // option 2
        if(isFacingRight)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else if(!isFacingRight)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }

        
        isFacingRight = !isFacingRight;



        // // opt 1
        // Vector3 theScale = transform.localScale;
        // theScale.x *= -1;
        // transform.localScale = theScale;
    }

}

