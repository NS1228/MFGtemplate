using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_shooting : MonoBehaviour
{
    //public Transform enemies;

    //public GameObject rangedShooters;

    public Transform target;

    public float rotSpeed = 10f;

    public Transform parent;

    public string enemyTag = "Axer";
    public string enemyShotgun = "Shotguner";
    public string enemyBlowgun = "Blowguner";

    public GameObject[] test;

    public float range = 10;

    public float fireDelay = 0;

    public Transform spawnLocation;
    public GameObject prefab;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
       
        
        // rangedShooters = GameObject.FindGameObjectWithTag("Shotguner");

    }

    // Update is called once per frame
    void Update()
    {

        /*  Collider[] cols = Physics.OverlapSphere(transform.position, range);
          foreach (Collider col in cols)
          {
              if (col && col.tag == "Shotguner" &&  Time.time >= fireDelay)
              { // if object has the right tag...
                // assuming the enemy script is called EnemyScript

                      col.GetComponent<AI_health>().health -= 10;
                      fireDelay = Time.time + 1;
                  Instantiate(prefab, spawnLocation.transform.position + transform.forward, transform.rotation);
                  prefab.transform.position = rangedShooters.transform.position * speed * Time.deltaTime;
                  rangedShooters = col.gameObject;
              }
          } */



        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject[] enemiestwo = GameObject.FindGameObjectsWithTag(enemyShotgun);
        GameObject[] enemiesthree = GameObject.FindGameObjectsWithTag(enemyBlowgun);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        foreach (GameObject enemy in enemiestwo)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        foreach (GameObject enemy in enemiesthree)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            if (nearestEnemy.GetComponent<Animator>().GetBool("Dead") == false)
            {
                target = nearestEnemy.transform;
            }
            // parent.transform.LookAt(target.transform.position);
            Vector3 dir = target.position - parent.transform.position;
            Quaternion Lookdirection = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(parent.rotation, Lookdirection, Time.deltaTime * rotSpeed).eulerAngles;
            parent.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);


        }


        if (target == null)
        {
            return;
        }

        if (target != null && Time.time >= fireDelay)
        {
            target.GetComponent<AI_health>().health -= 40;
            fireDelay = Time.time + 2;
            Turret_Audio.turretSFX = true;

            GameObject bulletGo = (GameObject)Instantiate(prefab, spawnLocation.position, spawnLocation.rotation);
            Bullets bullet = bulletGo.GetComponent<Bullets>();

            if (bullet != null)
            {
                bullet.Seek(target);
            }
            // Instantiate(prefab, spawnLocation.transform.position + transform.forward, transform.rotation);
            //  prefab.transform.position = target.transform.position * speed * Time.deltaTime;

        }
        else
        {
            Turret_Audio.turretSFX = false;
        }






        /* RaycastHit hit;
         var rayDirection = rangedShooters.transform.position - transform.position;
         if (Physics.Raycast(transform.position, rayDirection, out hit))
         {

             if (hit.transform == rangedShooters)
             {
                 insight = true;
             }
             else
             {
                 insight = false;
             }

         } */



    }

   
}
