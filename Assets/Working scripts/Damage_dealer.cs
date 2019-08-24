using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_dealer : MonoBehaviour
{
    public GameObject healthPoint;
    public GameObject Player;
    public float difference;
   public float damageValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(healthPoint.transform.position.y < this.transform.position.y)
        {
            print("LOL");
            Player.GetComponent<Health_script>().health -= 1 * Time.deltaTime;
        }
    }
}
