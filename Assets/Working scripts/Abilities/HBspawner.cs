﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBspawner : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    public Material[] deafultMat;


    public Material[] hbMat;


    public GameObject hoverBoard;
    public static bool Riding;
    public GameObject hBP;
    public GameObject Seat;

    public bool isGrounded;


    public bool canHB;

    public bool coolDown;
    public float cooldownTimer;

    public bool reset;
    public float resetTimer;

    public float hbTimer;

    Animator anim;

    public Camera defaultCam;
    public Camera hbCAM;
    //public GameObject empty;

    public GameObject banButton;

    public bool coll;
    public float collTimer;
    // Start is called before the first frame update

    public GameObject character;

    void Start()
    {
        Riding = false;
        canHB = true;
        anim = this.GetComponent<Animator>();

        m_Rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Triggercheck();
        Spawner();


        if(this.GetComponent<Thirsperson_character>().isGrounded)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }



        if (coolDown && Time.time >= cooldownTimer)
        {
            coolDown = false;
            Riding = false;

            reset = true;
            resetTimer = Time.time + 5;
            Time.fixedDeltaTime = 0.02f;
            this.GetComponent<Shop_Menu>().enabled = true;

        }


        if (reset && Time.time >= resetTimer)
        {
            canHB = true;
            reset = false;
            banButton.SetActive(false);
        }
        // transform.localScale = new Vector3(1, 4, 0.5f);
        // transform.localRotation = Quaternion.Euler(0, 0, 0);


    }


    public void Triggercheck()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canHB && this.GetComponent<Thirsperson_character>().isGrounded)
        {
            banButton.SetActive(true);
            hbTimer = Time.time + 1f;
           



            if (!Riding)
            {
                Riding = true;
                canHB = false;
               coolDown = true;
               cooldownTimer = Time.time + 11.5f;
               
                this.GetComponent<Shop_Menu>().enabled = false;

            }


        }

        if (Input.GetKeyDown(KeyCode.F) && Riding)
        {
            coolDown = true;
            cooldownTimer = 0;


            this.GetComponent<Shop_Menu>().enabled = true;
        }




    }

    public void Spawner()
    {
        if (Riding)
        {
            anim.SetBool("isHovering", true);

            if (Time.time >= hbTimer)
            {
                hoverBoard.GetComponent<MeshRenderer>().enabled = true;
                HB_sound.hbSFX = true;
            }

            character.gameObject.GetComponent<Renderer>().materials = hbMat;
            this.gameObject.transform.parent = Seat.transform;
            this.transform.position = Seat.transform.position;
            this.transform.rotation = Seat.transform.rotation;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            //this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<Thirsperson_character>().enabled = false;
            this.GetComponent<Normal_jump>().enabled = false;
            //Time.fixedDeltaTime = 0.005f;


         


        }
        else
        {
            if (this.GetComponent<Orbvest_manager>().isUsing == false)
            {
                character.gameObject.GetComponent<Renderer>().materials = deafultMat;
            }
            Time.fixedDeltaTime = 0.02f;
            HB_sound.hbSFX = false;
            anim.SetBool("isHovering", false);
            hoverBoard.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.transform.parent = null;
            hoverBoard.transform.position = hBP.transform.position;
            hoverBoard.transform.rotation = hBP.transform.rotation;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
            this.gameObject.GetComponent<Thirsperson_character>().enabled = true;
            this.GetComponent<Normal_jump>().enabled = true;

            
        }
    }

    /*  void OnCollisionEnter(Collision collision)
      {

          if (collision.gameObject.tag == "Floor")
          {
              isGrounded = true;
          }
      }

      void OnCollisionExit(Collision collision)
      {

          if (collision.gameObject.tag == "Floor")
          {
              isGrounded = true;
          }
      } */


   /*( void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Floor" && coll && Time.time >= collTimer)
        {
            coolDown = true;
            cooldownTimer = 0;
            coll = false;
        }
    } */
} 
