using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior: MonoBehaviour
{
    GameBehavior gameManager;
    Rigidbody rb;
    
    public Animator animator;

    bool isJumping;
    bool isGrounded = false;

    float moveSpeed = 4f;

    float jumpHeight = 0.0f;

    

    public GameObject soul;

    public bool canCollect;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();

    }

    private void Update()
    {
        CheckGrounded();
        Move();
        Jump();
        PickUpSouls();

    }

     /// <summary>
	/// Sets isGrounded to true or false depending if it hits the ground or not
    ///<summary>
    void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector2.down);
       // Ray ray 
        if (Physics.Raycast(ray, 1.5f))
        {
            isGrounded = true;
        }
        else isGrounded = false;
    }

    /// <summary>
	/// Moves the player in a given position depending on the way being pressed
	/// </summary>
    void Move()
    {
        // Will only move if not jumping
        if (isJumping == false && !Input.GetKey(KeyCode.Space))
        {
            float hInput = Input.GetAxis("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(hInput, rb.velocity.y);

            animator.SetFloat("IsRunning", Mathf.Abs(hInput));

            //Changes the scale to turn depending on which way you are moving (The scale of our guy can now only be 3)
            if (hInput < 0)
            {
                var scale = transform.localScale;
                scale.x = -6f;
                transform.localScale = scale;
            } else if (hInput > 0)
            {
                var scale = transform.localScale;
                scale.x = 6f;
                transform.localScale = scale;
            }
        }
        
    }

    /// <summary>
	/// Method to jump when standing  on the ground
	/// </summary>
    void Jump()
    {

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            if (jumpHeight <= 9.5)
            {
                jumpHeight += 0.15f;
            }
           
           animator.SetBool("IsJumping", true);
        }
        if (isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            //Calls ResetJump after 1.6 seconds
            Invoke("ResetJump", 1.6f);
            jumpHeight = 0.0f;
        }
    }

    /// <summary>
	/// Stops the jumoing animation and sets jumoing to false
	/// </summary>
    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    private void ResetJump()
    {
        isJumping = false;
        OnLanding();
    }

      /// <summary>
	/// Method to pickup Souls
	/// </summary>
    void PickUpSouls()
    {
        if (canCollect && Input.GetKeyDown(KeyCode.E))  
        {
            gameManager.souls += 1;
            Destroy(soul);
        }
    }
}