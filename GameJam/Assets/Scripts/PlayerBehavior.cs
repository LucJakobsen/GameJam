using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerBehavior: MonoBehaviour
{
    GameBehavior gameManager;
    Rigidbody rb;
    
    public Animator animator;

    bool isJumping;
    bool isGrounded = false;

    float moveSpeed = 4f;

    float jumpHeight = 0.0f;

    int playerWidth = 6;
    float playerHeight = 1.4f;
    

    public GameObject soul;

    public bool canCollect;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        FindObjectOfType<AudioManager>().Play("GameMusic");
        FindObjectOfType<AudioManager>().Play("Explosion");
    }

    private void Update()
    {
        CheckGrounded();
        Debug.Log(isGrounded);
        Move();
        Jump();
        PickUpSouls();

    }

     /// <summary>
	/// Sets isGrounded to true or false depending if it hits the ground or not
    ///<summary>
    void CheckGrounded()
    {
        bool backedgeOnGround =Physics.Raycast(new Vector3((transform.position.x - transform.localScale.x / 6), transform.position.y, transform.position.z),
          (-transform.up), playerHeight );
        bool frontedgeOnGround = Physics.Raycast(new Vector3((transform.position.x + transform.localScale.x / 6), transform.position.y, transform.position.z),
          (-transform.up), playerHeight);
        bool centerOnGround = Physics.Raycast (transform.position, (-transform.up), playerHeight);
        if (backedgeOnGround || frontedgeOnGround || centerOnGround)
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
        if (isGrounded && !Input.GetKey(KeyCode.Space))
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
           
        }
        if (isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            
            jumpHeight = 0.0f;
        } if (isGrounded == false)
        {
            animator.SetBool("IsJumping", true);
        } else if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3((transform.position.x - transform.localScale.x/ playerWidth), transform.position.y, transform.position.z),
           new Vector3((transform.position.x - transform.localScale.x / playerWidth), transform.position.y, transform.position.z) + (-transform.up));

        Gizmos.DrawLine(new Vector3((transform.position.x + transform.localScale.x / playerWidth), transform.position.y, transform.position.z),
           new Vector3((transform.position.x + transform.localScale.x / playerWidth), transform.position.y, transform.position.z) + (-transform.up));
    }

}