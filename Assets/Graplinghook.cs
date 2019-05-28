using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graplinghook : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookholder;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public static bool fired;
    public static bool hooked;
    public GameObject hookedobj;

    public float Maxdistance;
    private float currentDistance;

    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && fired == false)
        fired = true;

        if(fired)
        {
          //  LineRenderer rope = hook.GetComponent<LineRenderer>();
           // rope.SetVertexCount(2);
           // rope.SetPosition(0, hookholder.transform.position);
           // rope.SetPosition(1, hook.transform.position);
        }
        

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= Maxdistance)
                ReturnHook();
        }

        if (hooked && fired)
        {
            hook.transform.parent = hookedobj.transform;
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);
         
            this.GetComponent<Rigidbody>().useGravity = false;

            if (distanceToHook <= 2)
            {
                if(grounded == false)
                {
                    this.transform.Translate(Vector3.forward * Time.deltaTime * 16f);
                    this.transform.Translate(Vector3.up * Time.deltaTime * 45f);
                }

                StartCoroutine("Climb");
            }
                
        }
        else
        {
           hook.transform.parent = hookholder.transform.parent;
             this.GetComponent<Rigidbody>().useGravity = true;
           

        }
    }

    IEnumerator Climb()
    {
        yield return new WaitForSeconds(0.1f);
        ReturnHook();
    }

    void ReturnHook ()
    {
        hook.transform.rotation = hook.transform.rotation;
        hook.transform.position = hookholder.transform.position;
        fired = false;
        hooked = false;

       // LineRenderer rope = hook.GetComponent<LineRenderer>();
       // rope.SetVertexCount(0);



    }

    void CheckIfGround ()
    {
        RaycastHit hit;
        float distance = 1f;

        Vector3 dir = new Vector3(0, -1);

        if(Physics.Raycast(transform.position, dir, out hit, distance))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
