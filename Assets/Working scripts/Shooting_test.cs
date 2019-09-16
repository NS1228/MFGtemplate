using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_test : MonoBehaviour
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
    public float ammo = 0;

    public float shootTiming;

    public GameObject muzzle;
    public GameObject muzzlePos;



    Animator anim;
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




        if (this.GetComponent<New_ShotgunMovement>().canShoot && inSight && Time.time >= fireDelay && ammo <= 6 && !this.GetComponent<New_ShotgunMovement>().isFrozen && !this.GetComponent<New_ShotgunMovement>().isStun)
        {
            
                canFire = true;
                fireDelay = Time.time + 1;
            Instantiate(muzzle, muzzlePos.transform.position, muzzlePos.transform.rotation);
            
            ammo += 1;

            if(ammo == 7)
            {
                this.GetComponent<New_ShotgunMovement>().reload = true;
                this.GetComponent<New_ShotgunMovement>().timeforReload = Time.time + 2.5f;
                this.GetComponent<New_ShotgunMovement>().realoading = true;
            }
            

            print(highAcc);

            shooting -= highAcc;
            if (AbilityManager.hasBooster)
            {
                if (shooting >= 0.65f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -booster");
                    targetEnmy.GetComponent<Health_script>().health -= 5;
                    Grunt_Sound.gruntSFX = true;
                }
            }

            else if (targetEnmy.GetComponent<Rollerskates>().skating)
            {
                if (shooting >= 0.70f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -rs");
                    targetEnmy.GetComponent<Health_script>().health -= 5;
                    Grunt_Sound.gruntSFX = true;
                }
            }

            else if (targetEnmy.GetComponent<Thirsperson_character>().hasBall)
            {
                if (shooting >= 0.75f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -bs");
                    targetEnmy.GetComponent<Health_script>().health -= 5;
                    Grunt_Sound.gruntSFX = true;
                }
            }

            else if (targetEnmy.GetComponent<Bouncy>().canBounce)
            {
                if (shooting >= 0.80f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -bounce");
                    targetEnmy.GetComponent<Health_script>().health -= 5;
                    Grunt_Sound.gruntSFX = true;
                }
            }

            else if (targetEnmy.GetComponent<Fp_Cooldown>().flyCD)
            {
                if (shooting >= 0.85f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -fp");
                    targetEnmy.GetComponent<Health_script>().health -= 5;
                    Grunt_Sound.gruntSFX = true;
                }
            }
            else if (HBspawner.Riding)
            {
                if (shooting >= 0.90f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    print("TAKEDAMAGE -hb");
                    targetEnmy.GetComponent<Health_script>().health -= 5;
                    Grunt_Sound.gruntSFX = true;
                }
            }
          else if (!targetEnmy.GetComponent<Thirsperson_character>().hasBall && !targetEnmy.GetComponent<Thirsperson_character>().hasBall && !targetEnmy.GetComponent<Fp_Cooldown>().flyCD && !targetEnmy.GetComponent<Bouncy>().canBounce && !targetEnmy.GetComponent<Thirsperson_character>().hasBall && !targetEnmy.GetComponent<Rollerskates>().skating && !AbilityManager.hasBooster)
            {
                if (shooting >= 0.60f)
                {
                    DI_System.CreateIndicator(this.transform);
                    playerHealth -= playerDMG;
                    Grunt_Sound.gruntSFX = true;

                    if (this.anim.GetCurrentAnimatorStateInfo(1).IsName("Shoot"))
                    {
                        targetEnmy.GetComponent<Health_script>().health -= 5;
                        print("TAKEDAMAGE -normal");
                    }
                }
                
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
                if (!this.GetComponent<New_ShotgunMovement>().isFrozen && !this.GetComponent<New_ShotgunMovement>().freezeReShoot)
                {
                    this.GetComponent<New_ShotgunMovement>().MaxDist = 9f;
                    this.GetComponent<New_ShotgunMovement>().MinDist = 0.1f;
                }
            }
            else
            {
                inSight = false;
                if (!this.GetComponent<New_ShotgunMovement>().isFrozen)
                {
                    this.GetComponent<New_ShotgunMovement>().MaxDist = 0.1f;
                    this.GetComponent<New_ShotgunMovement>().MinDist = 0.1f;
                }
            }

        }
    }
}

       

    


