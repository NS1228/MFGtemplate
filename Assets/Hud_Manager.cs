using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud_Manager : MonoBehaviour
{
    public GameObject Player;
    public GameObject pearlButton;
    public GameObject pearlBan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<Shop_Menu>().enabled)
        {
            pearlButton.SetActive(true);
            pearlBan.SetActive(false);
        }
        else
        {
            pearlButton.SetActive(false);
            pearlBan.SetActive(true);
        }
    }
}
