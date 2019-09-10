using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowgun_Shooting : MonoBehaviour
{
    public GameObject targetEnmy;
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
   

    public float shootTiming;

    public float shootTimer;

    Animator anim;

    public GameObject fireBall;
    public GameObject fbPosition;
    // Start is called before the first frame update
    void Start()
    {
        inSight = false;
        anim = this.GetComponent<Animator>();
        canFire = true;

    }

    // Update is called once per frame
    void Update()
    {



        Debug.DrawRay(transform.position, transform.forward);

        float highAcc = Random.Range(0.0f, 1f);

        //isHit = random > 1.0f - hitAccuracy;

        // print(canFire);


        if (Ranged_enemyMovement.aiCANSHOOT == false)
        {
            shooting = 1f;
        }


        if (playerHealth <= 0)
        {
            //print("DEAD");
        }




        if (this.GetComponent<Blowguner_Movement>().canShoot && inSight && Time.time >= fireDelay && Time.time >= shootTimer && !this.GetComponent<Blowguner_Movement>().isFrozen && !this.GetComponent<Blowguner_Movement>().isStun)
        {

            canFire = true;
            fireDelay = Time.time + 3;
            Instantiate(fireBall, fbPosition.transform.position, fbPosition.transform.rotation);





            print(highAcc);


            shooting -= highAcc;
            if (AbilityManager.hasBooster)
            {
                if (shooting >= 0.65f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -booster");
                    targetEnmy.GetComponent<Health_script>().health -= 20;
                    Instantiate(fireBall, fbPosition.transform.position, fbPosition.transform.rotation);
                    Grunt_Sound.gruntSFX = true;
                }
            }

           if (targetEnmy.GetComponent<Rollerskates>().skating)
                if (shooting >= 0.70f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -rs");
                    targetEnmy.GetComponent<Health_script>().health -= 20;
                    Grunt_Sound.gruntSFX = true;
                }
            if (targetEnmy.GetComponent<Thirsperson_character>().hasBall)
                if (shooting >= 0.75f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -bs");
                    targetEnmy.GetComponent<Health_script>().health -= 20;
                    Grunt_Sound.gruntSFX = true;
                }
            if (targetEnmy.GetComponent<Bouncy>().canBounce)
                if (shooting >= 0.80f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -bounce");
                    targetEnmy.GetComponent<Health_script>().health -= 20;
                    Grunt_Sound.gruntSFX = true;
                }
            if (targetEnmy.GetComponent<Fp_Cooldown>().flyCD)
                if (shooting >= 0.85f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -fp");
                    targetEnmy.GetComponent<Health_script>().health -= 20;
                    Grunt_Sound.gruntSFX = true;
                }
            if (HBspawner.Riding)
                if (shooting >= 0.90f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -hb");
                    targetEnmy.GetComponent<Health_script>().health -= 20;
                    Grunt_Sound.gruntSFX = true;
                }
            if (!targetEnmy.GetComponent<Thirsperson_character>().hasBall && !targetEnmy.GetComponent<Thirsperson_character>().hasBall && !targetEnmy.GetComponent<Fp_Cooldown>().flyCD && !targetEnmy.GetComponent<Bouncy>().canBounce && !targetEnmy.GetComponent<Thirsperson_character>().hasBall && !targetEnmy.GetComponent<Rollerskates>().skating && !AbilityManager.hasBooster)
                if (shooting >= 0.60f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;


                    targetEnmy.GetComponent<Health_script>().health -= 20;
                        print("TAKEDAMAGE -normal");
                    Grunt_Sound.gruntSFX = true;

                }





        }
        else
        {

            canFire = false;
            shooting = 1;


        }


        /*   RaycastHit hit;

            var rayDirection = player.position - transform.position;
            if (Physics.Raycast(transform.position, rayDirection, out hit))
            {
                if (hit.transform == player)
                {
                    // enemy can see the player!
                    //print("see");
                    inSight = true;

                    this.GetComponent<New_ShotgunMovement>().MaxDist = 6.5f;
                    this.GetComponent<New_ShotgunMovement>().MinDist = 4;


                }
                else
                {
                    // there is something obstructing the view
                    // print("can't see");
                    inSight = false;

                    //this.GetComponent<New_ShotgunMovement>().MaxDist = 2;
                    // this.GetComponent<New_ShotgunMovement>().MinDist = 2;






                } */

        RaycastHit objectHit;
        // Shoot raycast
        if (Physics.Raycast(transform.position + (transform.up * 1f), transform.forward, out objectHit, 50))
        {
            //Debug.Log("Raycast hitted to: " + objectHit.collider);
            targetEnmy = objectHit.collider.gameObject;

            if (targetEnmy == GameObject.FindGameObjectWithTag("Player"))
            {
                inSight = true;
                

            }
            else
            {
                inSight = false;
               
            }

        }
    }
}
