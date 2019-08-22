using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telport_device : MonoBehaviour
{
    public GameObject teleporterdevice;
    public float throwForceLength;
    public float throwForceHeight;
    public Transform playerCam;

    GameObject telep;

    private bool hasTP;

    public float tpdevices;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddTPD());
        tpdevices = 1;
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       /*( if (Input.GetKeyDown(KeyCode.Q) && !hasTP)
        {
           telep = Instantiate(teleporterdevice, transform.position + (transform.forward * 1) + (transform.up *1), transform.rotation);
           telep.transform.parent = playerCam;
           telep.GetComponent<Rigidbody>().useGravity = false;


        }

        if (Input.GetMouseButtonDown(0))
        {
            telep.GetComponent<Rigidbody>().useGravity = true;
            telep.GetComponent<Rigidbody>().isKinematic = false;
            telep.transform.parent = null;
            telep.GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            StartCoroutine(Teleportthis());
        } */

        if(telep == null)
        {
            hasTP = false;
        }
        else
        {
            hasTP = true;
        }


        StartCoroutine(Test());

        
    }



    IEnumerator Teleportthis()
    {
        yield return new WaitForSeconds(2);
       this.transform.position = telep.transform.position;
        
        //yield return new WaitForSeconds(1);
        Destroy(telep);
        print("yes");
    }


    IEnumerator Test()
    {
        if (Input.GetKeyDown(KeyCode.C) && !hasTP && tpdevices > 0)
        {
            anim.SetBool("highThrow", true);
            this.GetComponent<Thirsperson_character>().verSpeed = 0;
            tpdevices -= 1;
            telep = Instantiate(teleporterdevice, transform.position + (transform.forward * 0.1f) + (transform.up * 5f), transform.rotation);
            telep.transform.parent = playerCam;
            telep.GetComponent<Rigidbody>().useGravity = false;
            //yield return new WaitForSeconds(1);
            telep.GetComponent<Rigidbody>().useGravity = true;
            telep.GetComponent<Rigidbody>().isKinematic = false;
            telep.transform.parent = null;
            telep.GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForceHeight);
            StartCoroutine(Teleportthis());
            yield return new WaitForSeconds(1);
            this.GetComponent<Thirsperson_character>().verSpeed = 2;
            anim.SetBool("highThrow", false);
            

        }

        if (Input.GetKeyDown(KeyCode.Q) && !hasTP && tpdevices > 0)
        {
            anim.SetBool("lowThrow", true);
            this.GetComponent<Thirsperson_character>().verSpeed = 0;
            tpdevices -= 1;
            telep = Instantiate(teleporterdevice, transform.position + (transform.forward * 3f) + (transform.up * 0.5f), transform.rotation);
            telep.transform.parent = playerCam;
            telep.GetComponent<Rigidbody>().useGravity = false;
            //yield return new WaitForSeconds(1);
            telep.GetComponent<Rigidbody>().useGravity = true;
            telep.GetComponent<Rigidbody>().isKinematic = false;
            telep.transform.parent = null;
            telep.GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForceLength);
            StartCoroutine(Teleportthis());
            yield return new WaitForSeconds(1);
            anim.SetBool("lowThrow", false);
            this.GetComponent<Thirsperson_character>().verSpeed =  2;
            
        }

    }

    IEnumerator AddTPD()
    {
        if (tpdevices <= 5)
        {
            yield return new WaitForSeconds(5.0f);
            tpdevices++;
            StartCoroutine(AddTPD());
        }
    }

}


