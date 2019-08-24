using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_something : MonoBehaviour
{
    public GameObject player;

    public float tikTimer;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Enemy_Sleeper>().HackThem == true && this.GetComponent<Sleeping_Enemies>().inRange == true && Time.time >= tikTimer)
            {
            this.GetComponent<AI_health>().health -= 20f;
            tikTimer = Time.time + 6;
        }
     



    }

}