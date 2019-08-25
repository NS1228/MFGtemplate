﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballshoe_Cooldown : MonoBehaviour
{
    public GameObject Ballshoe;
    public bool canBS;

    public bool bsCooldown;
    public float bsTimer;

    public bool bsReset;
    public float resetTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        canBS = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canBS && Input.GetKey(KeyCode.Q))
        {
            Ballshoe.SetActive(true);
            canBS = false;
            bsCooldown = true;
            bsTimer = Time.time + 12;
        }

        if(bsCooldown && Time.time >= bsTimer)
        {
            Ballshoe.SetActive(false);
            bsReset = true;
            resetTimer = Time.time + 6;
            bsCooldown = false;

        }

        if(bsReset && Time.time >= resetTimer)
        {
            canBS = true;
            bsReset = false;
        }

        if(!canBS && Input.GetKey(KeyCode.F))
        {
            Ballshoe.SetActive(false);
            
        }
        
    }
}