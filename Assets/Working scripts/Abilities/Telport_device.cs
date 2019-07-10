using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telport_device : MonoBehaviour
{
    public GameObject teleporterdevice;
    public float throwForce;
    public Transform playerCam;

    GameObject telep;

    private bool hasTP;


    // Start is called before the first frame update
    void Start()
    {

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
        if (Input.GetKeyDown(KeyCode.Q) && !hasTP)
        {
            telep = Instantiate(teleporterdevice, transform.position + (transform.forward * 1) + (transform.up * 1), transform.rotation);
            telep.transform.parent = playerCam;
            telep.GetComponent<Rigidbody>().useGravity = false;
            //yield return new WaitForSeconds(1);
            telep.GetComponent<Rigidbody>().useGravity = true;
            telep.GetComponent<Rigidbody>().isKinematic = false;
            telep.transform.parent = null;
            telep.GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            StartCoroutine(Teleportthis());
            yield return new WaitForSeconds(1);
        }

    }

}


