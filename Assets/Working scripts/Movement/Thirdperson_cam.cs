using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirdperson_cam : MonoBehaviour
{

    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    public bool isHover;
    // Start is called before the first frame update
    void Start()
    {
       // Cursor.visible = false;
       // Cursor.lockState = CursorLockMode.Locked;
        isHover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(HBspawner.Riding)
        {
            isHover = true;
        }
        else
        {
            isHover = false;
        }
    }

    void LateUpdate ()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }

        else
        {
            if (isHover)
            {

                //Player.rotation = Quaternion.Euler(0, mouseX, 0);
                Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            }
            if(!isHover)
                {
                
                Player.rotation = Quaternion.Euler(0, mouseX, 0);
                Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            }
        }

    }
        
}
