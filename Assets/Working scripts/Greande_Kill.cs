using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greande_Kill : MonoBehaviour
{
    public Vector3 location;
    public float radius;
    public float damage;

    public bool timetoBlow;
    public float blowTime;

    public GameObject gSpawner;
    // Start is called before the first frame update
    void Start()
    {
        location = this.transform.position;
       
    }

    // Update is called once per frame


    void Update()
    {
        if(Time.time >= blowTime && timetoBlow)
        {
            timetoBlow = false;
            Destroy(gameObject);
        }

        Collider[] cols = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider col in cols)
        {
            if (col && col.tag == "Axer")
            { // if object has the right tag
              // assuming the enemy script is called EnemyScript
               AI_health script = col.GetComponent<AI_health>();
                script.health -= 10; // apply damage 5
                Destroy(gameObject);

            }

            if (col && col.tag == "Shotguner")
            { // if object has the right tag
              // assuming the enemy script is called EnemyScript
                AI_health script = col.GetComponent<AI_health>();
                script.health -= 10; // apply damage 5
                Destroy(gameObject);

            }


        }
    }


     void OnCollisionEnter(Collision other)
     {
     if(other.gameObject.name == "Floor")
       {
            timetoBlow = true;
            blowTime = Time.time + 3f;

       
      }
   }















}
