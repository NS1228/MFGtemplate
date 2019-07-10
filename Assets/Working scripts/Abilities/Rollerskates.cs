using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollerskates : MonoBehaviour
{

    public float speed;
    public bool skating;
  
    // Start is called before the first frame update
    void Start()
    {
        speed = 8;
        skating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!skating)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                skating = true;

            }
        }

            if (skating)
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    skating = false;
                }
            }
        






        if (skating)
        {
            this.GetComponent<Thirsperson_character>().enabled = false;

            transform.position += transform.forward * Time.deltaTime * speed;
            speed += 0.05f;
            if (speed >= 20)
            {
                speed = 20f;
            }
        }

        if(!skating)
        {
            
            speed -= 0.05f;
            if (speed <= 8)
            {
                speed = 8;
                this.GetComponent<Thirsperson_character>().enabled = true;

            }

            if(speed > 8)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }

        }

           
        }
    }

