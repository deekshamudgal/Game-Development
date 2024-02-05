using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables are always preferred when you need to make things descriptive and self-explanatory

    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    //groundCheck was made visible in the engine as we had to connect it to the original ground check game object, and then operate on it respectively

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        //GetAxis is much smoother than GetAxisRaw

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            //Vector3 expects float values, thus the f after 5

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    //Function for ground check using a game object directly below the player - To avoid air jump 

    bool IsGrounded()
    {
        //Why did we create a new layer mask: ground though? Was the older ones not good enough or something??

        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);

        //What is a Prefab anyways? And why are we operating on it, rather than directly operating on the floor? 
        
    }
}
