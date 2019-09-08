using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_jump : MonoBehaviour
{

    public float jumpHeight;
    public bool isGrounded;
    public Animator animator;

    private Rigidbody rb;

    public bool jumpAnim;

    public bool canJump;
    public float jumpTimer;

    public bool jumpSpeed;
    public float speedTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpHeight = 400;
        animator = this.GetComponent<Animator>();
        canJump = true;
    }

    void Update()
    {
        if (rb.velocity.y < -8)
        {
            isGrounded = false;
        }
        if (jumpAnim)
        {
            
        
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                rb.AddForce(Vector3.up * jumpHeight);
                jumpAnim = true;
                animator.SetBool("isJump", true);
                this.GetComponent<Thirsperson_character>().verSpeed = 1.5f;
                Jump_sound.jumpSFX = true;
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                canJump = false;
                jumpTimer = Time.time + 1.75f;
                jumpSpeed = true;
                speedTimer = Time.time + 1.5f;
                Time.fixedDeltaTime = 0.02f;

            }
            else
            {
                if (jumpSpeed && Time.time >= speedTimer)
                {
                    this.GetComponent<Thirsperson_character>().verSpeed = 2;
                    jumpSpeed = false;
                }
            }
        }

        if(!canJump && Time.time >=  jumpTimer)
        {
            canJump = true;
            Time.fixedDeltaTime = 0.0075f;

        }

        //print(jumpHeight);
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
            //isGrounded = false;
            //Thirsperson_character.speed = 10;

        }
    }

  
}