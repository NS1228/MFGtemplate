using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Simulation : MonoBehaviour
{

    public float jumpValue;
    public float leapValue;
    public float fallValue;

    private float timer;

    private bool inAir;
    // Start is called before the first frame update
    void Start()
    {
        jumpValue = 30;
        leapValue = 10;
        fallValue = 10;
        timer = 0;
        inAir = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().useGravity = false;
           transform.position += Vector3.up * Time.deltaTime * jumpValue;
           transform.position += Vector3.forward * Time.deltaTime * leapValue;

            jumpValue += 3f;
            leapValue += 3f;

            if(jumpValue >= 70)
            {
                jumpValue = 70;
            }

            if (leapValue >= 50)
            {
                leapValue = 50;
            }

            timer = Time.time + 3f;

            inAir = true;

        }

        if(Time.time >= timer && inAir)
        {
            this.GetComponent<Rigidbody>().useGravity = true;

            leapValue = 10;
            jumpValue = 30;


            fallValue += 0.25f;


            if (fallValue >= 18)
            {
                fallValue = 18;
            }


            Changer();

        }

    }

    void Changer ()
    {

        transform.position += Vector3.down * Time.deltaTime * fallValue;

        if (fallValue == 18)
        {
            inAir = false;
            
        }


    }

   }

