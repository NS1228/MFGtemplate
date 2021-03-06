﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fp_Cooldown : MonoBehaviour
{
  
     public bool toFly;

    public bool flyCD;
    public float cdTimer;

    public bool reset;
    public float resetTimer;

    Animator anim;

    public GameObject banButton;

    // Start is called before the first frame update
    void Start()
    {
        toFly = true; 
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.F)&& !toFly && !reset)
        {
            cdTimer = 0;
            flyCD = true;
            this.GetComponent<Normal_jump>().enabled = true;
            Time.fixedDeltaTime = 0.02f;
            this.GetComponent<Shop_Menu>().enabled = true;
        }


        if (Input.GetKey(KeyCode.C) && toFly)
        {
            
            flyCD = true;
            cdTimer = Time.time + 8;
            toFly = false;
            FP_Sound.fpSFX = true;
            this.GetComponent<Normal_jump>().enabled = false;
            Time.fixedDeltaTime = 0.0075f;
            this.GetComponent<Shop_Menu>().enabled = false;
            banButton.SetActive(true);


        }

        if(flyCD && Time.time >= cdTimer)
        {
            FP_Sound.fpSFX = false;
            this.GetComponent<Fly_test>().enabled = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Fly_test>().canFly = false;
            this.GetComponent<Fly_test>().value = 4;
            this.GetComponent<Fly_test>().dropValue  = 4;
            flyCD = false;
            reset = true;
            resetTimer = Time.time + 6;
            anim.SetBool("isFlying", false);
            this.GetComponent<Normal_jump>().enabled = true;
            Time.fixedDeltaTime = 0.02f;
            this.GetComponent<Shop_Menu>().enabled = true;

        }

        if(reset && Time.time >= resetTimer)
        {
            toFly = true;
            reset = false;
            this.GetComponent<Fly_test>().enabled = true;
            banButton.SetActive(false);
        }

    }
}
