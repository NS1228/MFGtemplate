using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Test : MonoBehaviour
{
    
    public Transform destination;
    public GameObject player;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            player.transform.position = destination.transform.position;
            print("yes");
        }
    }
}