﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_health : MonoBehaviour
{

    public float health = 100;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

   void Death ()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

     
    }
}
