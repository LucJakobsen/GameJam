using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Rigidbody rb;

    GameBehavior gameManager;
    bool isGrounded = false;

    float moveSpeed = 5.0f;

    float jumpHeight = 0.0f;
    float dashForce;
    bool isJumping;

    public GameObject soul;

    public bool canCollect;

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
        FaceForward();
        Debug.Log(canCollect);
      PickUp();
    }
    void FaceForward()
    {
        Vector3 vel = rb.velocity;
        if (vel.x != 0)
        {
            transform.forward = new Vector3(vel.x, 0, 0);
        }
    }

    void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector2.down);
        if (Physics.Raycast(ray, 01f))
        {
            isGrounded = true;
        }
        else isGrounded = false;
    }

    void Move()
    {
        if(isJumping == false && !Input.GetKey(KeyCode.Space))
        {
            float hInput = Input.GetAxis("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(hInput, rb.velocity.y);
        }
    }

    void Jump()
    {

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            if (jumpHeight <= 7) {
                jumpHeight+= 0.1f;
            }
        }

        if (isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            Invoke("ResetJump", 1.6f);
            jumpHeight = 0.0f;
        }
    
        
    }

    private void ResetJump()
    {
        isJumping = false;
    }

    void PickUp()
    {
        if(canCollect && Input.GetKeyDown(KeyCode.E))
            {
            gameManager.souls += 1;
                Destroy(soul);
            }
    }

    /* void PickUp()
     {
         float distanceToSoul = 3f;
         float height = 1f;
         if (Physics.SphereCast(rb.position, height, transform.forward, out Hit, distanceToSoul))
         {
             if (Hit.transform.gameObject.CompareTag("Soul"))
             {
                 if (Input.GetKeyDown(KeyCode.E))
                 {
                     soulsCollected += 1;
                     Destroy(Hit.transform.gameObject);
                 }
             }
         }
     }*/
}
