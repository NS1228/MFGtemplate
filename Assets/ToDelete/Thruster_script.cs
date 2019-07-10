using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster_script : MonoBehaviour
{
    public float thrusterStrength;
    public float thrusterDistance;
    public Transform[] thrusters;

    Rigidbody rb;

    void start ()
    {
       rb = gameObject.GetComponent<Rigidbody>();
    }
        

    void FixedUpdate()
    {
        RaycastHit hit;
        foreach (Transform thruster in thrusters)
        { 
            Vector3 downwardForce;
            float distancePercentage;

            if(Physics.Raycast (thruster.position, thruster.up *-1, out hit, thrusterDistance))
            {
                distancePercentage = 1 - (hit.distance / thrusterDistance);

                downwardForce = transform.up * thrusterStrength * distancePercentage;

                downwardForce = downwardForce * Time.deltaTime * rb.mass;

                rb.AddForceAtPosition(downwardForce, thruster.position);
            }
        }

  }
}
