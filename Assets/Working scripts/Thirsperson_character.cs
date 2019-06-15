using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirsperson_character : MonoBehaviour
{

    public bool isSkating;

    public static float speed;
    public float skatespeed;
    // Start is called before the first frame update
    void Start()
    {
        skatespeed = 0;
        speed = 8;
        isSkating = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        
    }

    void PlayerMovement ()
    {
        if (!isSkating)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        }
        if (isSkating)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver * skatespeed) * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);

        }


        if (Input.GetKey(KeyCode.W))
        {
            skatespeed += 0.03f;

            if (skatespeed >= 2)
            {
                skatespeed = 2f;

            }
        }
        else
        {
            
            skatespeed -= 0.25f;
            if(skatespeed <= 0)
            {
                skatespeed = 0;
            }
        }
            

           

        }

    }



    


