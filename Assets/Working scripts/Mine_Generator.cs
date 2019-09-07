using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Generator : MonoBehaviour
{

    public GameObject Mines;

    public float currentMines;
    public float maxMines;

    public bool canMine;

    Animator anim;

    public float animTimer;
    public bool deployMine;

    public bool soundSwitch;
    public float soundTimer;

    AudioSource audios;

   
   
    // Start is called before the first frame update
    void Start()
    {
        maxMines = 3;
        StartCoroutine(AddMines());
        anim = this.GetComponent<Animator>();
        audios = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      

      

    
       

        if (soundSwitch && Time.time >= soundTimer)
        {
            audios.volume = 1;
            soundSwitch = false;
            Mine_Sound.mineSFX = false;


        }
        

        if (this.GetComponent<Thirsperson_character>().hasBall == false && AbilityManager.hasBooster == false && this.GetComponent<Rollerskates>().skating == false && this.GetComponent<Bouncy>().canBounce == false && this.GetComponent<Fly_test>().canFly == false && HBspawner.Riding == false)
        {

            if (maxMines >= 1 && Input.GetKeyDown(KeyCode.E) && canMine)
            {
                anim.SetBool("dropMine", true);
                animTimer = Time.time + 0.69f;
                deployMine = true;
                this.GetComponent<Thirsperson_character>().verSpeed = 0;
                Thirsperson_character.speed = 0;
                audios.volume = 0;
                soundSwitch = true;
                soundTimer = Time.time + 0.69f;
                Mine_Sound.mineSFX = true;
                

            }
        }

        if (Time.time >= animTimer && deployMine)
        {
            Instantiate(Mines, transform.position + (transform.forward * 1 + transform.up * 0f), transform.rotation);
            maxMines -= 1;
            //currentMines++;
            anim.SetBool("dropMine", false);
            deployMine = false;
            this.GetComponent<Thirsperson_character>().verSpeed = 2;
            Thirsperson_character.speed = 4;
            
            if(maxMines == 9)
            {
                StartCoroutine(AddMines());
            }


        }



    }

    IEnumerator AddMines()
    {
        if (maxMines <= 9)
        {
            yield return new WaitForSeconds(5.0f);
            maxMines++;
            StartCoroutine(AddMines());
            
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            canMine = true;
        }


    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            canMine = false;
        }


    }

}
