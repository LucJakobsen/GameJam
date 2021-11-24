using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Rigidbody rb;

    bool isGrounded = false;
    bool isJumping;
    float groundDistance = 0.7f;

    float moveSpeed = 5.0f;

    float jumpHeight = 0.0f;
    int counter = 0;

    [SerializeField]private float dashForce = 50f;
    private CapsuleCollider col;

    public LayerMask groundLayer;

    RaycastHit Hit;
    int soulsCollected;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        isOnGround();
        Move();
        Jump();
        //FaceForward();
        PickUp();
    }

   // void CheckGrounded()
   // {
    //    Ray ray = new Ray(transform.position, Vector2.down);
    //    if (Physics.Raycast(ray, 0.9f))
     //   {
     //       isGrounded = true;
     //   }
     //   else isGrounded = false;
   // }

    void isOnGround()
    {
        Vector3 capsuleBottom = new Vector3(col.bounds.center.x,
                  col.bounds.min.y, col.bounds.center.z);

        isGrounded = Physics.CheckCapsule(col.bounds.center,
           capsuleBottom, groundDistance, groundLayer,
              QueryTriggerInteraction.Ignore);
    }

    void FaceForward()
    {
        Vector3 vel = rb.velocity;
        if (vel.x != 0 )
        {
            transform.forward = vel;
        }
    }

    void Move()
    {
        if(!Input.GetKey(KeyCode.Space) && isGrounded)
        {
            float hInput = Input.GetAxis("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(hInput, rb.velocity.y);
        }
    }   

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            if (jumpHeight <= 15) {
                jumpHeight+= 0.1f;
                counter = 0;
            }
        }

        if (isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            Invoke("ResetJump", 0.4f);

        }

       if (Input.GetKey(KeyCode.A) && !isGrounded && counter == 0 )
            {
            rb.AddForce(transform.right * -dashForce);
            counter++;
            } else if (Input.GetKey(KeyCode.D) && counter == 0) {
            rb.AddForce(transform.right * dashForce);
            counter++;
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
