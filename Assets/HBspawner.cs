using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBspawner : MonoBehaviour
{

    public GameObject hoverBoard;
    public static bool Riding;
    // Start is called before the first frame update
    void Start()
    {
        Riding = false;
    }

    // Update is called once per frame
    void Update()
    {
        Triggercheck();
        Spawner();
    }


    public void Triggercheck()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!Riding)
            {
                Riding = true;
            }
            else if (Riding)
            {
                Riding = false;
            }
        }

           

        
    }

    public void Spawner()
    {
        if (Riding)
        {
            hoverBoard.SetActive(true);
            this.gameObject.transform.parent = hoverBoard.transform;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            hoverBoard.SetActive(false);
            this.gameObject.transform.parent = null;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }


  
}
