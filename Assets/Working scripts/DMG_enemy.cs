using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMG_enemy : MonoBehaviour
{

     public Vector3 location;
     public float radius;
     public float damage;

    public AudioClip mineExp;
    AudioSource audioSourcee;

    public bool destroy;
    public float destroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        location = this.transform.position;
        audioSourcee = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       // AreaDamageEnemies();

        if(destroy && Time.time >= destroyTimer)
        {
            Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Axer")
        {
            AreaDamageEnemies();
            print("LEL");

        }

       else if (collision.gameObject.tag == "Shotguner")
        {
            AreaDamageEnemies();
            print("LEL");

        }

        else if (collision.gameObject.tag == "Blowguner")
        {
            AreaDamageEnemies();
            print("LEL");

        }



    }


   public void AreaDamageEnemies()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
        foreach (Collider col in objectsInRange)
        {
        Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
            {
                // linear falloff of effect
                float proximity = (location - enemy.transform.position).magnitude;
                float effect = 1 - (proximity / radius);

                audioSourcee.PlayOneShot(mineExp, 0.7f);
                enemy.GetComponent<AI_health>().health -= 50f;
                //Destroy(gameObject);
                this.GetComponent<MeshRenderer>().enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;
                destroy = true;
                destroyTimer = Time.time + 3f;
            }
        }
    }
}
