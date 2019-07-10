using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Controls : MonoBehaviour
{

    public float acceleration;
    public float rotationRate;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    private float rotationVelocity;
    private float groundAngleVelocity;

    Rigidbody _rb;
    // Start is called before the first frame update
    void Start ()
    {
       _rb = gameObject.GetComponent<Rigidbody>();
    }

   void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.up*-1, 3f))
        {
            _rb.drag = 1;

            Vector3 forwardForce = transform.forward * acceleration * Input.GetAxis("Vertical");

            forwardForce = forwardForce * Time.deltaTime * _rb.mass;

            _rb.AddForce(forwardForce);
        }
        else
        {
            _rb.drag = 0;
        }
        Vector3 turnTorque = Vector3.up * rotationRate * Input.GetAxis("Horizontal");

        turnTorque = turnTorque * Time.deltaTime * _rb.mass;
        _rb.AddTorque(turnTorque);

        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        transform.eulerAngles = newRotation;


        }
    }

