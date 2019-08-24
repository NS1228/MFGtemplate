using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_drop : MonoBehaviour
{
    public GameObject prefab;
    public float yAxis;


    public int grenadeLimit = 0;

   

    public float maxGrenades;

   
   
    
    // Start is called before the first frame update
    void Start()
    {
       
       
        //StartCoroutine(Setchanger());
    }

    // Update is called once per frame
    void Update()
    {
        

        if (grenadeLimit >= 0 && grenadeLimit < maxGrenades && ADA.isGrenadeFall)
        { 
            Vector3 xPosition = new Vector3(Random.Range(-50.0f, 50.0f), Random.Range( 40, 80f), Random.Range(-50.0f, 50.0f));

             

            
               Instantiate(prefab, xPosition, Quaternion.identity);
               grenadeLimit += 1;

            
           
            }


       


        
        //print(grenadeLimit);

      

    }

    






   


}
