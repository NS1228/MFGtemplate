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

    public bool destroy;
    public float destroyTimer;

    public GameObject gSpawner;

    public GameObject gexp;
    public GameObject gexpPoint;

    public bool addTimer;
    // Start is called before the first frame update
    void Start()
    {
        location = this.transform.position;
        addTimer = true;

       
    }

    // Update is called once per frame


    void Update()
    {
        if(Time.time >= blowTime && timetoBlow)
        {
            timetoBlow = false;
            //Destroy(gameObject);
            destroy = true;
            destroyTimer = Time.time + 3;
            this.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;

            Grenade_Sound.grenadexpSFX = true;

            Instantiate(gexp, gexpPoint.transform.position, gexpPoint.transform.rotation);
            print("EXPLOSE NOW");
        }

        Collider[] cols = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider col in cols)
        {
            if (col && col.tag == "Axer")
            { // if object has the right tag
              // assuming the enemy script is called EnemyScript
               AI_health script = col.GetComponent<AI_health>();
                script.health -= 10; // apply damage 5

                destroy = true;
                destroyTimer = Time.time + 3;
                this.GetComponent<SphereCollider>().enabled = false;
                this.GetComponent<MeshRenderer>().enabled = false;
                Grenade_Sound.grenadexpSFX = true;

                Instantiate(gexp, gexpPoint.transform.position, gexpPoint.transform.rotation);

            }

            if (col && col.tag == "Shotguner")
            { // if object has the right tag
              // assuming the enemy script is called EnemyScript
                AI_health script = col.GetComponent<AI_health>();
                script.health -= 10; // apply damage 5

                destroy = true;
                destroyTimer = Time.time + 3;
                this.GetComponent<SphereCollider>().enabled = false;
                this.GetComponent<MeshRenderer>().enabled = false;
                Grenade_Sound.grenadexpSFX = true;

                Instantiate(gexp, gexpPoint.transform.position, gexpPoint.transform.rotation);
            }

            if (col && col.tag == "Blowguner")
            { // if object has the right tag
              // assuming the enemy script is called EnemyScript
                AI_health script = col.GetComponent<AI_health>();
                script.health -= 10; // apply damage 5

                destroy = true;
                destroyTimer = Time.time + 3;
                this.GetComponent<SphereCollider>().enabled = false;
                this.GetComponent<MeshRenderer>().enabled = false;
                Grenade_Sound.grenadexpSFX = true;

                Instantiate(gexp, gexpPoint.transform.position, gexpPoint.transform.rotation);

            }


        }

        if (destroy && Time.time >= destroyTimer)
        {
            Destroy(gameObject);
        }


    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            if (addTimer)
            {
                timetoBlow = true;
                blowTime = Time.time + 3f;
                addTimer = false;
            }
            Grenade_Bounce.gbounceSFX = true;
           // print("bounce sound");


        }
    }

        void OnCollisionExit(Collision other)
        {
            if (other.gameObject.tag == "Floor")
            {
               
                Grenade_Bounce.gbounceSFX = false;
           // print("bounce off");

            }
        }















}
