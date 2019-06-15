using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_jump : MonoBehaviour
{

    public float jumpHeight;
    public bool isGrounded;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpHeight = 400;
    }

    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight);
                
            }
        }

        print(jumpHeight);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
            //Thirsperson_character.speed = 10;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
            //Thirsperson_character.speed = 10;

        }
    }

  
}