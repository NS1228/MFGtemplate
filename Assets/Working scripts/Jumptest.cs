using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jumptest : MonoBehaviour
{
    public bool isJumping;
    private float timer = 0;
    Vector3 gravity;
    //FirstPersonController fpc;

    


    void Start()
    {
        gravity = Physics.gravity;
        isJumping = false;
        //fpc = GameObject.FindObjectOfType<FirstPersonController>();
    }

    void FixedUpdate()
    {
        print(gravity.y);

        Physics.gravity = gravity;

        if (Input.GetKey(KeyCode.E))
        {

            timer = Time.time + 0.5f;
            isJumping = true;

        }


        if(Time.time > timer)
        {
            isJumping = false;
            gravity.x = 0;
            gravity.y -= 1f;
            gravity.z = 0;

            Thirsperson_character.speed = 10;

            if(gravity.y <= -10)
            {
                gravity.y = -10;
            }
        }

        Jumper();
    }

    public void Jumper ()
    {
        if(isJumping)
        {
            Thirsperson_character.speed += 0.25f;
           

            if (Thirsperson_character.speed >= 18)
            {
                Thirsperson_character.speed = 18;
            }

            gravity.x = 0;
            gravity.y = 15;
            gravity.z = 0;
           // fpc.m_RunSpeed = (runSpeed / 100 * playerSpeedPercent);

        }
    }
}
