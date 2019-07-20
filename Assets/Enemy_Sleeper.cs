using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sleeper : MonoBehaviour
{
    public  bool HackThem;

    public bool stopHack;
    public float timer;

    public bool inUse;
    public float Cooldown;

    public bool resetthis;
    public float resettimer;

    public bool stunDMG;
    

    // Start is called before the first frame update
    void Start()
    {
        HackThem = false;
        stopHack = false;
        inUse = false;
        resetthis = false;

        stunDMG = false;

    }

    // Update is called once per frame
    void Update()
    {

      
        if(Input.GetKey(KeyCode.E) && !inUse)
        {
            HackThem = true;
            timer = Time.time + 5f;
            stopHack = true;
            inUse = true;
            stunDMG = true;



        }

        if(stopHack && Time.time >= timer)
        {
            stopHack = false;
            HackThem = false;

            resetthis = true;
            resettimer = Time.time + 6;
           


        }




        
        CooldownReset();



        }

  

   


    void CooldownReset ()
    {
        if(resetthis && Time.time >= resettimer)
        {
            inUse = false;
            resetthis = false;
        }
    }








    }


