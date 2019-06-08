using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Camera : MonoBehaviour
{

    public float mouseSensitivity = 10;
    public Transform target;
    public float dstFromTarget = 2;
    public Vector2 pitchMixMax = new Vector2(-40, 85);

    public float rotationSmoothTime = 1.2f;
    Vector3 rotationSmoothVelocity;
    Vector3 CurrentRotation;

    float yaw;
    float pitch;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMixMax.x, pitchMixMax.y);

       CurrentRotation = Vector3.SmoothDamp(CurrentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

        
       transform.eulerAngles = CurrentRotation;

        transform.position = target.position - transform.forward * dstFromTarget;
    }

}
