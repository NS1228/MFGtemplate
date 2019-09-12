using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_dealer : MonoBehaviour
{
    public GameObject healthPoint;
    public GameObject musicPoint;
    public GameObject Player;
    public float difference;
   public float damageValue;

    AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = this.GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(healthPoint.transform.position.y < this.transform.position.y)
        {
            print("LOL");
            Player.GetComponent<Health_script>().health -= 1 * Time.deltaTime;
            //DI_System.CreateIndicator(this.transform);
            Grunt_Sound.gruntSFX = true;
        }

        if (musicPoint.transform.position.y < this.transform.position.y)
        {

            AS.enabled = true;
        }
        else
        {
            AS.enabled = false;
        }
    }
}
