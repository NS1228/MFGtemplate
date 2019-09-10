using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting_Test : MonoBehaviour
{
    public bool Unfreeze;
    public float timer = 0;



    public GameObject Player;
    //public GameObject parent;


    // Start is called before the first frame update
    void Start()
    {
        Unfreeze = false;

        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Unstun();
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Lighting")
        {
            if (this.gameObject.tag == "Axer")
            {
                this.gameObject.GetComponent<Enemy_Movement>().MoveSpeed = 0;

                timer = Time.time + 1;
                print("yes");
                Unfreeze = true;
                this.GetComponent<AI_health>().health -= 40;
                this.GetComponent<Enemy_Movement>().isStun = true;
                Electric_Sound.shockSFX = true;
            }

            if (this.gameObject.tag == "Shotguner")
            {
                this.gameObject.GetComponent<New_ShotgunMovement>().MoveSpeed = 0;

                timer = Time.time + 1;
                print("yes");
                Unfreeze = true;
                this.GetComponent<AI_health>().health -= 40;
                this.GetComponent<New_ShotgunMovement>().isStun = true;
                Electric_Sound.shockSFX = true;
            }
            if (this.gameObject.tag == "Blowguner")
            {
                this.gameObject.GetComponent<Blowguner_Movement>().MoveSpeed = 0;

                timer = Time.time + 1;
                print("yes");
                Unfreeze = true;
                this.GetComponent<AI_health>().health -= 40;
                this.GetComponent<Blowguner_Movement>().isStun = true;
                Electric_Sound.shockSFX = true;
            }
        }









        /* if(other.gameObject.tag == "Player")
         {
             Player.GetComponent<Thirsperson_character>().verSpeed = 0;
             Thirsperson_character.speed = 0;
             Player.GetComponent<Health_script>().health -= 10;


             frozenObject = other.gameObject;
             timer = Time.time + 1;
             Unfreeze = true;


             print("yes");

         } */



    }

    void Unstun()
    {
        if (Time.time >= timer && Unfreeze && this.gameObject.tag == "Axer")
        {
            this.gameObject.GetComponent<Enemy_Movement>().MoveSpeed = 4;
            Unfreeze = false;
            //Destroy(this.gameObject);
            //Destroy(parent.gameObject);
            this.GetComponent<Enemy_Movement>().isStun = false;
            Electric_Sound.shockSFX = false;


        }

        if (Time.time >= timer && Unfreeze && this.gameObject.tag == "Shotguner")
        {
            this.gameObject.GetComponent<New_ShotgunMovement>().MoveSpeed = 4;
            Unfreeze = false;
            //Destroy(this.gameObject);
            //Destroy(parent.gameObject);
            this.GetComponent<New_ShotgunMovement>().isStun = false;
            Electric_Sound.shockSFX = false;


        }

        if (Time.time >= timer && Unfreeze && this.gameObject.tag == "Blowguner")
        {
            this.gameObject.GetComponent<Blowguner_Movement>().MoveSpeed = 4;
            Unfreeze = false;
           // Destroy(this.gameObject);
           // Destroy(parent.gameObject);
            this.GetComponent<Blowguner_Movement>().isStun = false;
            Electric_Sound.shockSFX = false;


        }
       
    }
}
