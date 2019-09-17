using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public GameObject Player;

   
    public float pillarGem;

    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(pillarGem >= 5)
        {
            portal.SetActive(true);
        }
        

       
        
    }

    
}
