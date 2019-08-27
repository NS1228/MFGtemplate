using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_test : MonoBehaviour
{
    public bool timetoBlow;
    public float blowTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= blowTime && timetoBlow)
        {
            timetoBlow = false;
            Destroy(gameObject);
        }
    }

   
}
