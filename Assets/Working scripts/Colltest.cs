﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colltest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 13)
        {
            print("YO MAMA IS FAT");
        }
    }
}
