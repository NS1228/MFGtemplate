using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Knockback_test : MonoBehaviour
{
    
    public bool knockback;
    Rigidbody rb;
    public GameObject attack;

    public Vector3 moveDirection;

    NavMeshAgent agent;

    public float yValue;

    public float zValue;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        knockback = false;
        rb = this.GetComponent<Rigidbody>();
        attack = this.gameObject;
        agent = gameObject.GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (knockback)
        {
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
           rb.AddForce(transform.up * yValue + transform.forward * zValue);
            knockback = false;
           agent.enabled = false;
            timer = Time.time + 2f;
            
            
        }
        if (!knockback && Time.time >= timer)
        {
            agent.enabled = true;
        }
       
        



        if(Input.GetKey(KeyCode.E))
        {
            knockback = true;
        }
    }



}
