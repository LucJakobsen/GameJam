using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Rigidbody rb;

    bool isGrounded = false;

    float moveSpeed = 5.0f;

    float jumpHeight = 0.0f;
    float dashForce;

    RaycastHit Hit;
    int soulsCollected;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckGrounded();
        Debug.Log(isGrounded);
        Move();
        Jump();
        //FaceForward();
        PickUp();
    }

    void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector2.down);
        if (Physics.Raycast(ray, 0.7f))
        {
            isGrounded = true;
        }
        else isGrounded = false;
    }

    void Move()
    {
        if(isGrounded && !Input.GetKey(KeyCode.Space))
        {
            float hInput = Input.GetAxis("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(hInput, rb.velocity.y);

           // if (rb.velocity.x != 0)
            //{
             //   transform.forward = rb.velocity;
           // }
        }
    }

    void Jump()
    {

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            if (jumpHeight <= 7) {
                jumpHeight+= 0.05f;
            }
        }

        if (isGrounded && Input.GetKeyUp(KeyCode.Space))
        {

            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            Invoke("ResetJump", 0.2f);
        }
    
        
    }

    private void ResetJump()
    {
        jumpHeight = 0.0f;
    }

    void PickUp()
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
    }
}
