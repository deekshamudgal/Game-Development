//Is Rigidbody a kind of variable storage thingy? 
//how are we able to store a function in it though? Is that allowed??!
//and how is velocity a variable stored in our Rigidbody? Am I looking too much into this?

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables are always preferred when you need to make things descriptive and self-explanatory

    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

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

        //HELP: {the movement is relatively slower now because instead of setting the value to 0 and relying on the physics, we let the button down do it's work...}

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if(Input.GetButtonDown("Jump"))
        {
            //Vector3 expects float values, thus the f after 5

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        //QUESTION OF THE DAY: WHAT IS EXPLICIT AND IMPLICIT? IN TERMS OF PROGRAMMING? IN TERMS OF FUNCTIONS?
       
        
    }
}

