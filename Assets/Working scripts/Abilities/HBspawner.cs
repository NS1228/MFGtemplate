using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBspawner : MonoBehaviour
{

    public GameObject hoverBoard;
    public static bool Riding;
    public GameObject hBP;
    public GameObject Seat;


    public bool canHB;

    public bool coolDown;
    public float cooldownTimer;

    public bool reset;
    public float resetTimer;

    public float hbTimer;

    Animator anim;

    public Camera defaultCam;
    public Camera hbCAM;
    //public GameObject empty;
    // Start is called before the first frame update

   
    void Start()
    {
        Riding = false;
        canHB = true;
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Triggercheck();
        Spawner();
        



        if(coolDown && Time.time >= cooldownTimer)
        {
            coolDown = false;
            Riding = false;

            reset = true;
            resetTimer = Time.time + 8;
            
        }
        

        if(reset && Time.time >=  resetTimer)
        {
            canHB = true;
            reset = false;
        }
        // transform.localScale = new Vector3(1, 4, 0.5f);
       // transform.localRotation = Quaternion.Euler(0, 0, 0);


    }


    public void Triggercheck()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canHB)
        {
            hbTimer = Time.time + 1f;

            if (!Riding)
            {
                Riding = true;
                canHB = false;
                coolDown = true;
                cooldownTimer = Time.time + 10;

            }
            
           
        }

        if(Input.GetKeyDown(KeyCode.F)&& Riding)
            {

            Riding = false;
        }

           

        
    }

    public void Spawner()
    {
        if (Riding)
        {
            anim.SetBool("isHovering", true);

            if (Time.time >= hbTimer)
            {
                hoverBoard.SetActive(true);
            }

           
            //this.gameObject.transform.parent = hoverBoard.transform;
            this.transform.position = Seat.transform.position;
            this.transform.rotation = Seat.transform.rotation;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<Thirsperson_character>().enabled = false;






        }
        else
        {
           
            anim.SetBool("isHovering", false);
            hoverBoard.SetActive(false);
            this.gameObject.transform.parent = null;
            hoverBoard.transform.position = hBP.transform.position;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
            this.gameObject.GetComponent<Thirsperson_character>().enabled = true;
        }
    }

   


  
}
