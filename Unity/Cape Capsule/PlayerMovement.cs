using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    //we did not use get component because it cannot distinguish between different audio files
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource endlevelSound;

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
            Jump();
        }
    }
        void Jump()
    {
        //Vector3 expects float values, thus the f after 5
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Enemy Head is used as the string, because we don't want the Enemy to be destroyed Oncollision but rather when we jump over it's head
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            //here we can use destroy as we don't care if the whole enemy get erased from the disk- that is the goal!
            //transforming the gameObject to be destroyed to the parent rather than only the head box collider
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    //Function for ground check using a game object directly below the player - To avoid air jump 

    bool IsGrounded()
    {
        //Why did we create a new layer mask: ground though? Was the older ones not good enough or something??

        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);

        //What is a Prefab anyways? And why are we operating on it, rather than directly operating on the floor? 
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Endgate"))
        {
            endlevelSound.Play();
        }
    }
}
