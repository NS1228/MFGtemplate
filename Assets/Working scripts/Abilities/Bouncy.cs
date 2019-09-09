using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{

    public bool cooldown;
    public bool canBounce;
    public float height;
    public PhysicMaterial bouncyness;
    private Rigidbody rb;

    float cdTimer;

    public bool cdStarter;

    public bool reset;
    public float resetTimer;

    public float jumpTimer;

    Animator anim;

    public float jumpAllowed;
    

    // Start is called before the first frame update
    void Start()
    {
        cooldown = false;
        canBounce = false;
        
        rb = GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.F) && canBounce)
        {
            cdTimer = 0;
        }

        if (Input.GetKey(KeyCode.Space) && !cooldown)
        {
            canBounce = true;
           
            //GetComponent<Rigidbody>().useGravity = false;

            GetComponent<BoxCollider>().material = bouncyness;
            cooldown = true;
            cdTimer = Time.time + 12;
            cdStarter = true;
            jumpTimer = Time.time + 1;
            
            this.GetComponent<Shop_Menu>().enabled = false;
        }


        

        if (Time.time >= cdTimer && cdStarter)
        {
            cdStarter = false;
            this.GetComponent<BoxCollider>().material = null;
            canBounce = false;
            anim.SetBool("Bounce", false);
            reset = true;
            resetTimer = Time.time + 6;
            this.GetComponent<Shop_Menu>().enabled = true;



        }

        if (Time.time >= resetTimer && reset)
        {
            reset = false;
            cooldown = false;
        }




        if (Input.GetKey(KeyCode.F) && cooldown)
        {
            this.GetComponent<BoxCollider>().material = null;
            canBounce = false;
        }




        if (canBounce == true && Time.time >= jumpTimer)
        {
            //this.GetComponent<Normal_jump>().jumpHeight = 0;
            this.GetComponent<Normal_jump>().enabled = false;
            


        }
        if (!canBounce)
        {
            //this.GetComponent<Normal_jump>().jumpHeight = 300;
            this.GetComponent<Normal_jump>().enabled = true;
            
        }

    }

    void OnCollisionEnter(Collision theCollision) 
    {
        if (theCollision.gameObject.tag == "Floor" && canBounce && Time.time >= jumpAllowed)
        {
            rb.AddForce(Vector3.up * height);
            print("whats wrong");
            anim.SetBool("Bounce", true);
            Bounce_sound.bounceSFX = true;
            jumpAllowed = Time.time + 0.5f;
        }

        

    }

    void OnCollisionExit (Collision theCollision)
    {
        if(theCollision.gameObject.tag == "Floor" && canBounce)
        {
            anim.SetBool("Bounce", false);
            Bounce_sound.bounceSFX = false;
        }
    }
}



