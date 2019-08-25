using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_takedamage : MonoBehaviour
{
    public float playerHealth;
    public float axeDamage;
    public float shotgunDamage;

    public float canTakeDmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Axe" && Time.time >= canTakeDmg)
        {
            canTakeDmg = Time.time + 1.08f;
            this.GetComponent<Health_script>().health -= axeDamage;
            //print("BITCH");
        }

        if(other.gameObject.tag == "Bullet")
        {
            playerHealth -= shotgunDamage;
            //print("BITCH");
        }
    }


    void Death ()
    {
        if(this.GetComponent<Health_script>().health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
