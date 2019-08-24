using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Icetrail : MonoBehaviour
{
    public GameObject iceTrail;
    public bool usethis;

    public float timer;


    public bool grounded;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timer && grounded)
        {
            Instantiate(iceTrail, transform.position + (transform.up * -0.15f), transform.rotation);
            timer = Time.time + 0.15f;



        }


    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
           grounded = true;
        }


    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            grounded = false;
        }


    }
}

      