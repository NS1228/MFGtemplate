using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Jump : MonoBehaviour
{

    private Vector3 MoveVector;
    private Vector3 lastMove;
    private float speed = 9;
    private float jumpforce = 20;
    private float gravity = 10;
    private float verticalVelocity;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveVector = Vector3.zero;
        MoveVector.x = Input.GetAxis("Horizontal");
        MoveVector.z = Input.GetAxis("Vertical");

        if(controller.isGrounded)
        {
            verticalVelocity = -1;

            if(Input.GetKey(KeyCode.V))
            {
                verticalVelocity = jumpforce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            MoveVector = lastMove;
        }

        MoveVector.y = 0;
        MoveVector.Normalize();
        MoveVector *= speed;
        MoveVector.y = verticalVelocity;

        controller.Move(MoveVector * Time.deltaTime);
        lastMove = MoveVector;


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(!controller.isGrounded && hit.normal.y < 0.1f)
        {
            if(Input.GetKey(KeyCode.V))
            Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
            verticalVelocity = jumpforce;
            MoveVector = hit.normal * speed;
        }
    }
  
}
