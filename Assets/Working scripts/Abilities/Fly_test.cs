using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_test : MonoBehaviour
{

    public float value;
     public bool canFly;
    public float dropValue;


    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        value = 4;
        dropValue = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //print(Thirsperson_character.speed);

        if (Input.GetKey(KeyCode.C))
        {
            anim.SetBool("isFlying", true);
            canFly = true;
            transform.position += Vector3.up * Time.deltaTime * value;
            this.GetComponent<Rigidbody>().useGravity = false;

            value += 0.05f;


            //this.GetComponent<Thirsperson_character>().flightSpeed += 0.1f;
            //Thirsperson_character.speed += 0.1f;

            // if (this.GetComponent<Thirsperson_character>().flightSpeed == 10)
            // {
            //     this.GetComponent<Thirsperson_character>().flightSpeed = 10;
            //  }
            if (value >= 10)
            {
                value = 10;
            }


        }
        else
        {
            if (canFly)
            {
                dropValue += 0.1f;
                if (dropValue >= 10)
                {
                    dropValue = 10;
                }
                //this.GetComponent<Rigidbody>().useGravity = true;
                transform.position += Vector3.down * Time.deltaTime * dropValue;

            }
        }

        

    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Floor")
        {
            canFly = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            value = 4;




        }
    }







}
