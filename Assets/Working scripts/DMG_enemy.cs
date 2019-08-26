using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMG_enemy : MonoBehaviour
{

     public Vector3 location;
     public float radius;
     public float damage;

   
    // Start is called before the first frame update
    void Start()
    {
        location = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // AreaDamageEnemies();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Axer")
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


                enemy.GetComponent<AI_health>().health -= 50f;
                Destroy(gameObject);
            }
        }
    }
}
