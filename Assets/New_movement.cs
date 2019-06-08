using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_movement : MonoBehaviour
{
    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;

    public bool blockRotationPlayer;
    public float desiredRotationSpeed;

    public float Speed;
    public float allowPlayerRotation;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;
    public float verticalVel;
    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputMagnititude();

        isGrounded = controller.isGrounded;
        if(isGrounded)
        {
            verticalVel -= 0;
        }
        else
        {
            verticalVel -= 2;
        }
        moveVector = new Vector3(0, verticalVel, 0);
        controller.Move(moveVector);
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");


        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if(blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }
    }

    void InputMagnititude ()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        //Anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime * 2f); 

        Speed = new Vector2(InputX, InputZ).sqrMagnitude;


        if(Speed > allowPlayerRotation)
        {
            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {

        }
    }
    

        
}
