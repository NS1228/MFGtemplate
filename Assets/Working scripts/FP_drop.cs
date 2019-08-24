using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_drop : MonoBehaviour
{

    public bool canDrop;

    public float value;
  void Start ()

    {

    }

    void Update ()
    {
        if (canDrop)
        {
            transform.position += Vector3.down * Time.deltaTime * value;
            value += 0.25f;

            //this.GetComponent<Thirsperson_character>().flightSpeed -= 0.5f;
            // Thirsperson_character.speed -= 0.5f;
            //  if (this.GetComponent<Thirsperson_character>().flightSpeed <= 1f)
            // {
            //     this.GetComponent<Thirsperson_character>().flightSpeed = 1;
            // }

            if (value >= 30)
            {
                value = 30;
            }
        }
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Floor")
        {
            canDrop = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            value = 4;




        }
    }
}






