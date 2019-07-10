using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Test : MonoBehaviour
{
    
   public Transform destination;
    public GameObject player;


   void Update ()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            StartCoroutine(Startspawn());
           
        }
    }


    IEnumerator Startspawn ()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = transform.position;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        print("yes");
    }
    
}