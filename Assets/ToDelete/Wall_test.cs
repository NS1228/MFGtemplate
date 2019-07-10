using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_test : MonoBehaviour
{
    public GameObject playerOBJ;
   public bool canClimb = false;
   public float speed = 1;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            canClimb = true;
            playerOBJ = coll.gameObject;
            playerOBJ.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void OnCollisionExit(Collision coll2)
    {
        if (coll2.gameObject.tag == "Player")
        {
            canClimb = false;
           // playerOBJ = null;
            //playerOBJ.GetComponent<Rigidbody>().useGravity = true;

        }
    }
    void Update()
    {
        if (canClimb)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerOBJ.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerOBJ.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                playerOBJ.transform.Translate(new Vector3(0, 1, 1) * Time.deltaTime * speed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                playerOBJ.transform.Translate(new Vector3(0, 1, -1) * Time.deltaTime * speed);
            }

            
        }

        if (Input.GetKey(KeyCode.F))
        {
            playerOBJ.GetComponent<Rigidbody>().useGravity = true;
            playerOBJ.transform.Translate(new Vector3(1, 1, 0) * Time.deltaTime * 20);
            canClimb = false;
        }


    }
}
