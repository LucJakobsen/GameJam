using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior: MonoBehaviour
{
    GameBehavior gameManager;
    Rigidbody rb;
    
    public Animator animator;


    bool isGrounded = false;

    float moveSpeed = 3f;

    float jumpHeight = 0.0f;
    float dashForce;
    bool isJumping;

    public GameObject soul;

    public bool canCollect;

    bool facingRight;

    RaycastHit Hit;

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
        PickUp();

    }

    void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector2.down);
        if (Physics.Raycast(ray, 1.5f))
        {
            isGrounded = true;
        }
        else isGrounded = false;
    }

    void Move()
    {
        if (isJumping == false && !Input.GetKey(KeyCode.Space))
        {
            float hInput = Input.GetAxis("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(hInput, rb.velocity.y);

            animator.SetFloat("IsRunning", Mathf.Abs(hInput));

            if (hInput < 0)
            {
                var scale = transform.localScale;
                scale.x = -3f;
                transform.localScale = scale;
            } else if (hInput > 0)
            {
                var scale = transform.localScale;
                scale.x = 3f;
                transform.localScale = scale;
            }
        }
        
    }

    void Jump()
    {

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            if (jumpHeight <= 7)
            {
                jumpHeight += 0.1f;
            }
           
           animator.SetBool("IsJumping", true);
        }

        if (isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            Invoke("ResetJump", 1.4f);
            jumpHeight = 0.0f;


        }


    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    private void ResetJump()
    {
        isJumping = false;
        OnLanding();
    }

    void PickUp()
    {
        if (canCollect && Input.GetKeyDown(KeyCode.E))  
        {
            gameManager.souls += 1;
            Destroy(soul);
        }
    }
}