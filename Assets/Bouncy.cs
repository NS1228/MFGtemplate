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

    // Start is called before the first frame update
    void Start()
    {
        cooldown = false;
        canBounce = false;
        height = 4000;
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && !cooldown)
        {
            canBounce = true;
           
            //GetComponent<Rigidbody>().useGravity = false;

            GetComponent<CapsuleCollider>().material = bouncyness;
            cooldown = true;
            cdTimer = Time.time + 8;


        }


        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<CapsuleCollider>().material = null;
            canBounce = false;
        }

        


        if(canBounce == true)
        {
            this.GetComponent<Normal_jump>().jumpHeight = 0;
            

        }
        if(!canBounce)
        {
            this.GetComponent<Normal_jump>().jumpHeight = 2000;
            
        }

        if (Time.time >= cdTimer)
        {
            cooldown = false;
            GetComponent<CapsuleCollider>().material = null;
            canBounce = false;

        }

    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Floor" && canBounce)
        {
            rb.AddForce(Vector3.up * height);

        }

        

    }
}



