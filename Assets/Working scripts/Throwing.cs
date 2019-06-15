using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{

    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
   public bool hasPlayer = true;
    public bool beingCarried = false;
   
    public int dmg;
    private bool touched = false;

    public static bool tpEquiped;
    // Start is called before the first frame update
    void Start()
    {
        hasPlayer = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
       if(dist <= 2.5f)
       {
            hasPlayer = true;
        }
        else
        {
           hasPlayer = false;
        } 
        if(hasPlayer && Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.transform.parent = playerCam;
            beingCarried = true;
        } 
        if (beingCarried)
        {
            if(touched)
            {
               GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
                tpEquiped = false;

            



            }
            else if (Input.GetMouseButtonDown(1))
                {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                

            }
        }

       
    }

    void OnTriggerEnter()
    {
        if(beingCarried)
        {
            touched = true;
        }
    }
}
