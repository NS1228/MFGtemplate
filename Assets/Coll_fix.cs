using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_fix : MonoBehaviour
{
    public GameObject ramp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            ramp.GetComponent<MeshCollider>().convex = true;
            print("yo");
        }
    }

    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            ramp.GetComponent<MeshCollider>().convex = false;
        }
    }
}
