﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookdetector : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Hookable")
        {
           Graplinghook.hooked = true;
          player.GetComponent<Graplinghook>().hookedobj = other.gameObject;
            
            
        }
    }
}
