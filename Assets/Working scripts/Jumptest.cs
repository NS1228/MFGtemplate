using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Jumptest : MonoBehaviour
{
    public bool isJumping;
    private float timer = 0;
    Vector3 gravity;
    FirstPersonController fpc;

    


    void Start()
    {
        gravity = Physics.gravity;
        isJumping = false;
        fpc = GameObject.FindObjectOfType<FirstPersonController>();
    }

    void FixedUpdate()
    {
        Physics.gravity = gravity;

        if (Input.GetKey(KeyCode.E))
        {

            timer = Time.time + 1f;
            isJumping = true;

        }


        if(Time.time > timer)
        {
            isJumping = false;
            gravity.x = 0;
            gravity.y = -10;
            gravity.z = 0;
        }

        Jumper();
    }

    public void Jumper ()
    {
        if(isJumping)
        {

            gravity.x = 0;
            gravity.y = 5;
            gravity.z = 0;
           // fpc.m_RunSpeed = (runSpeed / 100 * playerSpeedPercent);

        }
    }
}
