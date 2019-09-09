using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Manager : MonoBehaviour
{
    public float offTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B) && !this.GetComponent<Shop_Menu>().shopActive)
        {
            offTimer = Time.time + 5;
        }

        if(offTimer > Time.time)
        {
            this.GetComponent<Shop_Menu>().enabled = false;
            this.GetComponent<Shop_Menu>().shopActive = false;
        }
        else if(Time.time >= offTimer)
        {
            this.GetComponent<Shop_Menu>().enabled = true;
        }
    }
}
