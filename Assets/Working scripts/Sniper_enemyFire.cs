using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_enemyFire : MonoBehaviour
{
    public Transform player;
    public float range = 50.0f;
    public float bulletImpulse = 20.0f;

    public float shootdelay;


    private bool onRange = false;

    public Rigidbody projectile;

    public Transform spawnPosition;

    void Start()
    {
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }

    void Shoot()
    {

        if (Time.time >= shootdelay)
        {
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, spawnPosition.transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2);
            shootdelay = Time.time + 5;
        }
    }

       


    }

   


