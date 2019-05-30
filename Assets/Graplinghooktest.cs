using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graplinghooktest : MonoBehaviour
{

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //this.transform.Translate(Vector3.up * Time.deltaTime *300f);
            //this.GetComponent<Rigidbody>().useGravity = false;
            transform.position += Vector3.up * Time.deltaTime * speed;
           



        }
    } 
}
