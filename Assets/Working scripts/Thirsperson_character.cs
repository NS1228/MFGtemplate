using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirsperson_character : MonoBehaviour
{

    public bool hasBall;
    public GameObject ballShoe;
    public static float speed;
    public float verSpeed;
    public float ballSpeed;
    public float boosterSpeed;
    
    // Start is called before the first frame update
    void Start()
    {

        speed = 4;
        hasBall = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

    }

    void PlayerMovement()
    {
        if (hasBall)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * ballSpeed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        }

        if (!hasBall & AbilityManager.hasBooster == false) 
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver * verSpeed) * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        }

        if(AbilityManager.hasBooster &!hasBall)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver * verSpeed) * boosterSpeed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);

        }



        if(ballShoe.activeInHierarchy)
        {
            hasBall = true;
            
        }
        else
        {
            hasBall = false;
        }







    }
}



    


