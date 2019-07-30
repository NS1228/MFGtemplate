using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Menu : MonoBehaviour
{
    public GameObject shopMenu;
    public bool shopActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyUp(KeyCode.B))
            {
            shopActive = !shopActive;
        }


        if(shopActive)
        {
            shopMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            shopMenu.SetActive(false);
            Time.timeScale = 1;
        }

    }


}
