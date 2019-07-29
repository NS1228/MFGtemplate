using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Generator : MonoBehaviour
{

    public GameObject Mines;

    public float currentMines;
    public float maxMines;

    public bool canMine;
   
    // Start is called before the first frame update
    void Start()
    {
        maxMines = 3;
        StartCoroutine(AddMines());
    }

    // Update is called once per frame
    void Update()
    {
        if(currentMines <= maxMines && Input.GetKeyDown(KeyCode.E) && canMine)
        {
            Instantiate(Mines, transform.position + (transform.forward * 1 + transform.up * -0.75f), transform.rotation);
            maxMines -= 1;
            currentMines++;
        }


        
    }

    IEnumerator AddMines()
    {
        if (maxMines <= 10)
        {
            yield return new WaitForSeconds(5.0f);
            maxMines++;
            StartCoroutine(AddMines());
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            canMine = true;
        }


    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            canMine = false;
        }


    }

}
