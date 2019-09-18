using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Menu : MonoBehaviour
{
    public GameObject shopMenu;
    public bool shopActive;

    public float canOpen;
    public bool addTime;

    public GameObject mainHud;
    public GameObject DeathBox;

    
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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            AudioListener.volume = 0f;
            mainHud.SetActive(false);
            
            
        }
        else
        {
            
            shopMenu.SetActive(false);
            Time.timeScale = 1;
            if (DeathBox.activeInHierarchy == false)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            AudioListener.volume = 1f;
            mainHud.SetActive(true);

        }

    }


}
