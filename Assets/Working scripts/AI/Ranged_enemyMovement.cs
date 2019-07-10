using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_enemyMovement : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed = 4;
    public float MaxDist = 15;
    public float MinDist = 10;


    public static bool aiCANSHOOT;

    public bool Canlookaround;


    Rigidbody rb;

    void Start()
    {
        aiCANSHOOT = false;
        rb = GetComponent<Rigidbody>();
        Canlookaround = false;
    }
        
    void Update()
    {
       

        if (!Canlookaround)
        {
            Vector3 lookAtPosition = Player.position;
            lookAtPosition.y = transform.position.y;
            transform.LookAt(lookAtPosition);
        }
        if(Canlookaround)
          {
            transform.LookAt(Player);
        }
        
       

        Player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something 
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                aiCANSHOOT = true;




            }
            else
            {
                aiCANSHOOT = false;
                
                
            }

        }
    }
}

