using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoohshooter : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookholder;
    public float Maxdistance;
    private float currentDistance;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    private bool fired;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !fired)
        {
            fired = true;

        }

        if (fired)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);


            if (currentDistance >= Maxdistance)
            {
                hook.transform.position = hookholder.transform.position;

            }
        }
            
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Hookable")
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);
        }
    }
}
