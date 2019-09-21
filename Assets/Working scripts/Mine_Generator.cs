using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Generator : MonoBehaviour
{
    public GameObject[] mineCount;

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

    public GameObject banButton;
   
   
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

        if(this.GetComponent<Thirsperson_character>().isGrounded)
        {
            canMine = true;
        }
        else
        {
            canMine = false;
        }

        if(maxMines == 1)
        {
            mineCount[0].SetActive(true);
            mineCount[1].SetActive(false);
            mineCount[2].SetActive(false);
            mineCount[3].SetActive(false);
            mineCount[4].SetActive(false);
            mineCount[5].SetActive(false);
            mineCount[6].SetActive(false);
            mineCount[7].SetActive(false);
            mineCount[8].SetActive(false);
            mineCount[9].SetActive(false);

        }
        if (maxMines == 2)
        {
            mineCount[1].SetActive(true);
            mineCount[0].SetActive(false);
            mineCount[2].SetActive(false);
            mineCount[3].SetActive(false);
            mineCount[4].SetActive(false);
            mineCount[5].SetActive(false);
            mineCount[6].SetActive(false);
            mineCount[7].SetActive(false);
            mineCount[8].SetActive(false);
            mineCount[9].SetActive(false);

        }



        if (maxMines == 3)
        {
            mineCount[2].SetActive(true);
            mineCount[1].SetActive(false);
            mineCount[0].SetActive(false);
            mineCount[3].SetActive(false);
            mineCount[4].SetActive(false);
            mineCount[5].SetActive(false);
            mineCount[6].SetActive(false);
            mineCount[7].SetActive(false);
            mineCount[8].SetActive(false);
            mineCount[9].SetActive(false);

        }
        if (maxMines == 4)
        {
            mineCount[3].SetActive(true);
            mineCount[1].SetActive(false);
            mineCount[2].SetActive(false);
            mineCount[0].SetActive(false);
            mineCount[4].SetActive(false);
            mineCount[5].SetActive(false);
            mineCount[6].SetActive(false);
            mineCount[7].SetActive(false);
            mineCount[8].SetActive(false);
            mineCount[9].SetActive(false);

        }
        if (maxMines == 5)
        {
            mineCount[4].SetActive(true);
            mineCount[1].SetActive(false);
            mineCount[2].SetActive(false);
            mineCount[3].SetActive(false);
            mineCount[0].SetActive(false);
            mineCount[5].SetActive(false);
            mineCount[6].SetActive(false);
            mineCount[7].SetActive(false);
            mineCount[8].SetActive(false);
            mineCount[9].SetActive(false);

        }
        if (maxMines == 6)
        {
            mineCount[5].SetActive(true);
            mineCount[1].SetActive(false);
            mineCount[2].SetActive(false);
            mineCount[3].SetActive(false);
            mineCount[4].SetActive(false);
            mineCount[0].SetActive(false);
            mineCount[6].SetActive(false);
            mineCount[7].SetActive(false);
            mineCount[8].SetActive(false);
            mineCount[9].SetActive(false);

        }
        if (maxMines == 7)
        {
            mineCount[6].SetActive(true);
            mineCount[1].SetActive(false);
            mineCount[2].SetActive(false);
            mineCount[3].SetActive(false);
            mineCount[4].SetActive(false);
            mineCount[5].SetActive(false);
            mineCount[0].SetActive(false);
            mineCount[7].SetActive(false);
            mineCount[8].SetActive(false);
            mineCount[9].SetActive(false);

        }
        if (maxMines == 8)
        {
            mineCount[7].SetActive(true);
            mineCount[1].SetActive(false);
            mineCount[2].SetActive(false);
            mineCount[3].SetActive(false);
            mineCount[4].SetActive(false);
            mineCount[5].SetActive(false);
            mineCount[6].SetActive(false);
            mineCount[0].SetActive(false);
            mineCount[8].SetActive(false);
            mineCount[9].SetActive(false);

        }
        if (maxMines == 9)
        {
            mineCount[8].SetActive(true);
            mineCount[1].SetActive(false);
            mineCount[2].SetActive(false);
            mineCount[3].SetActive(false);
            mineCount[4].SetActive(false);
            mineCount[5].SetActive(false);
            mineCount[6].SetActive(false);
            mineCount[7].SetActive(false);
            mineCount[0].SetActive(false);
            mineCount[9].SetActive(false);

        }
        if (maxMines == 10)
        {
            mineCount[9].SetActive(true);
            mineCount[1].SetActive(false);
            mineCount[2].SetActive(false);
            mineCount[3].SetActive(false);
            mineCount[4].SetActive(false);
            mineCount[5].SetActive(false);
            mineCount[6].SetActive(false);
            mineCount[7].SetActive(false);
            mineCount[8].SetActive(false);
            mineCount[0].SetActive(false);

        }


        if (maxMines <= 0)
        {
            banButton.SetActive(true);
        }
      else
        {
            banButton.SetActive(false);
        }

    
       

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

                this.GetComponent<Shop_Menu>().enabled = false;


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

            this.GetComponent<Shop_Menu>().enabled = true;

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


   /* void OnCollisionEnter(Collision other)
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


    } */

}
