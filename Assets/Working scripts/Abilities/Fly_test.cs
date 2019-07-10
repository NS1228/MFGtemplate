using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_test : MonoBehaviour
{

    public float value;

    public bool canFly;
    
    // Start is called before the first frame update
    void Start()
    {

        value = 12;
    }

    // Update is called once per frame
    void Update()
    {
        //print(Thirsperson_character.speed);

        if (Input.GetKey(KeyCode.Space))
        {
            canFly = true;
            transform.position += Vector3.up * Time.deltaTime * 10;
            this.GetComponent<Rigidbody>().useGravity = false;

            value = 12;
            Thirsperson_character.speed += 0.1f;

            if (Thirsperson_character.speed >= 18 )
            {
                Thirsperson_character.speed = 18;
            }

            
        }
        else
        {
            if (canFly)
            {
                transform.position += Vector3.down * Time.deltaTime * value;
                value += 0.25f;

                Thirsperson_character.speed -= 0.5f;
                if (Thirsperson_character.speed <= 10)
                {
                    Thirsperson_character.speed = 10;
                }

                if (value >= 25)
                {
                    value = 25;
                }
            }
        }





    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Floor")
        {
            canFly = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            value = 12;

           

        }
    }


}
