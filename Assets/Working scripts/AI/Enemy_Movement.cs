using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{

    public Transform Player;
    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float MinDist = 5;

    public NavMeshAgent agent;

    //public GameObject thePlayer;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();



    }

    void Update()
    {

        Vector3 lookAtPosition = Player.position;
        lookAtPosition.y = transform.position.y;
        transform.LookAt(lookAtPosition);





        Player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;




            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;

            }

        }


    }

   
}
