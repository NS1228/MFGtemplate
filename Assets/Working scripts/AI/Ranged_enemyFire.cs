using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_enemyFire : MonoBehaviour
{
    public Transform player;
    public float range = 50.0f;
    public float bulletImpulse = 20.0f;

    private bool onRange = false;

    public Rigidbody projectile;

    public Transform spawnPosition;

    public float shootDelay;
    public int clip = 0;
    public bool reloading;

    void Start()
    {
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
        reloading = false;
    }

    void Shoot()
    {

        if (onRange && Time.time >= shootDelay)
        {

            Rigidbody bullet = (Rigidbody)Instantiate(projectile,spawnPosition.transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward* bulletImpulse, ForceMode.Impulse);
            
            Destroy(bullet.gameObject, 2);
            shootDelay = Time.time + 0.5f;
            clip += 1;
        }

       // print(shootDelay);

    }

    void Update()
    {

        //spawnPosition.transform.LookAt(player);

        if (Ranged_enemyMovement.aiCANSHOOT)
        {
            onRange = true;
        }
       else
        {
            onRange = false;
        }

       if(clip >= 8)
        {
            shootDelay = Time.time + 5f;
            clip = 0;
        }
    }





}