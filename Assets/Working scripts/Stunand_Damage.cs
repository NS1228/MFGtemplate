using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunand_Damage : MonoBehaviour
{

    public bool Unfreeze;
    public float timer = 0;
    public GameObject frozenObject;

    
    public GameObject Player;
    public GameObject parent;


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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Axer") 
        {
            other.gameObject.GetComponent<Enemy_Movement>().MoveSpeed = 0;
            frozenObject = other.gameObject;
            timer = Time.time + 1;
            print("yes");
            Unfreeze = true;
            frozenObject.GetComponent<AI_health>().health -= 40;
            frozenObject.GetComponent<Enemy_Movement>().isStun = true;
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

    void Unstun ()
    {
        if(Time.time >= timer && Unfreeze && frozenObject.tag == "Axer")
        {
            frozenObject.gameObject.GetComponent<Enemy_Movement>().MoveSpeed = 4;
            Unfreeze = false;
            Destroy(this.gameObject);
            Destroy(parent.gameObject);
            frozenObject.GetComponent<Enemy_Movement>().isStun = false;


        }
        if(Time.time >= timer && Unfreeze && frozenObject == Player)
        {
            Player.GetComponent<Thirsperson_character>().verSpeed = 2;
            Thirsperson_character.speed = 4;
            Unfreeze = false;
            Destroy(this.gameObject);
            Destroy(parent.gameObject);

        }
    }


    
}
