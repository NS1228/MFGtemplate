using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Objects : MonoBehaviour
{
    public GameObject turret;
    public bool canBuild;

    public bool canBuildNCD;
    public int buildLimit = 0;

    public bool startCD;

    public float timer;

    public bool buildLimitReached;

    public float Turrettimerz;
    public bool buildtimer;

    // Start is called before the first frame update
    void Start()
    {
        canBuildNCD = true;
        startCD = false;
        buildLimitReached = false;
        buildtimer = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canBuild && canBuildNCD)
        {
            Instantiate(turret, transform.position + (transform.forward * 2 + transform.up * -0.5f),  transform.rotation);
            buildLimit += 1;
            buildLimitReached = true;
            buildtimer = true;
            Turrettimerz = Time.time + 10;

            
        }

        if(buildLimit >= 3 && buildLimitReached)
        {
            canBuildNCD = false;
            startCD = true;
            timer = Time.time + 5f;
            buildLimitReached = false;
        }

        if(buildtimer && Time.time >= Turrettimerz)
        {
            buildtimer = false;
            canBuildNCD = false;
            startCD = true;
            timer = Time.time + 5f;
        }

        Cooldown();

    }

    void OnCollisionEnter (Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            canBuild = true;
        }
        
        
    }

    void OnCollisionExit (Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            canBuild = false;
        }
        
        
    }


    public void Cooldown ()
    {
        if(startCD && Time.time >= timer)
        {
            startCD = false;
            canBuildNCD = true;
            buildLimit = 0;

        }
    }
}
