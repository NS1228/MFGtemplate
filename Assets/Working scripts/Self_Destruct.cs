using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_Destruct : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destoryer());
     
    }

    // Update is called once per frame
    void Update()
    {
        
      

    }

    IEnumerator Destoryer()
    {

        yield return new WaitForSeconds(10);
        Destroy(gameObject);

    }
}
