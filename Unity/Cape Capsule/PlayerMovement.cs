//Is Rigidbody a kind of variable storage thingy? 
//how are we able to store a function in it though? Is that allowed??!
//and how is velocity a variable stored in our Rigidbody? Am I looking too much into this?

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
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

        rb.velocity = new Vector3(horizontalInput, rb.velocity.y, verticalInput);

        if(Input.GetButtonDown("Jump"))
        {
            //Vector3 expects float values

            rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
        }
       
        
    }
}

