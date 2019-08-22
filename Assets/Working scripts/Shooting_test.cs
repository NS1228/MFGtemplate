using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_test : MonoBehaviour
{

    public Transform player;
    public bool inSight;

    [Range(0.0f, 1.0f)]
    //public float goodacc = 0.1f;
    //public float medacc = 0.45f;
    //public float lowacc = 0.8f;

    public float shooting = 1;

    public float playerHealth = 100;
    public float playerDMG = 20;

    public bool something;

    public bool canFire;
    public float fireDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        inSight = false;

    }

    // Update is called once per frame
    void Update()
    {
     



        float highAcc = Random.Range(0.0f, 0.5f);
        float medAcc = Random.Range(0.0f, 0.75f);
        float lowAcc = Random.Range(0.0f, 1f);
        //isHit = random > 1.0f - hitAccuracy;

        // print(canFire);


        if (Ranged_enemyMovement.aiCANSHOOT == false)
        {
            shooting = 1f;
        }


        if (playerHealth <= 0)
        {
            print("DEAD");
        }




        if (Ranged_enemyMovement.aiCANSHOOT && inSight && Time.time >= fireDelay && Ranged_enemyMovement.grounded)
        {
            canFire = true;
            fireDelay = Time.time + 2;

            if (Thirsperson_character.speed <= 4)
            {
               // print(highAcc);

                shooting -= highAcc;
                if (shooting >= 0.75f)
                {
                    playerHealth -= playerDMG;
                    //print("TAKEDAMAGE");
                    player.GetComponent<Health_script>().health -= 20;
                }



            }

        }
        else
        {
            canFire = false;
            shooting = 1;
        }


        RaycastHit hit;
        var rayDirection = player.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit))
        {
            if (hit.transform == player)
            {
                // enemy can see the player!
                //print("see");
                inSight = true;

                this.GetComponent<Ranged_enemyMovement>().MaxDist = 15;
                this.GetComponent<Ranged_enemyMovement>().MinDist = 10;
                

            }
            else
            {
                // there is something obstructing the view
                // print("can't see");
                inSight = false;

                this.GetComponent<Ranged_enemyMovement>().MaxDist = 1;
                this.GetComponent<Ranged_enemyMovement>().MinDist = 1;
                





            }
        }
    }
}
