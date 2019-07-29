using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Mines : MonoBehaviour
{

    public GameObject Mine;
    public float maxMines;

    public bool cooldown;
    public float cooldownTimer;

    public bool limitReached;

  
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (maxMines>= 0 && maxMines <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Mine, transform.position + (transform.forward * 1 + transform.up * -0.75f), transform.rotation);
            maxMines += 1;
            limitReached = true;

           
            
        }

        if(maxMines == 3 && limitReached)
        {
            cooldown = true;
            cooldownTimer =  Time.time + 5;
            limitReached = false;
        }

        if(cooldown && Time.time >= cooldownTimer)
        {
            cooldown = false;
            maxMines = 0;
        }

     
       
        
       


    }
}
