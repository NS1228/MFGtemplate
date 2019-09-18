using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health_script : MonoBehaviour
{

    public GameObject cameraone;
    public GameObject cameratwo;

    public float health = 100;
    Animator anim;

    public bool isDead;
    public float ragdollTime;

    public bool hasDied;

    public Image healthBar;

    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        hasDied = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / 100;

        if(health >= 100)
        {
            health = 100;
        }

        print(Time.fixedDeltaTime);
        Death();

        if (ragdollTime <= Time.time && isDead)
        {
            //Destroy(gameObject);
            SceneManager.LoadScene(3);
            
            
        }
    }


    public void Death()
    {
        if(health <= 0 && hasDied)
        {
            anim.SetBool("Dead", true);
            isDead = true;
            ragdollTime = Time.time + 6;
            hasDied = false;
            this.GetComponent<Thirsperson_character>().enabled = false;
            cameraone.GetComponent<Follow_ThePlayer>().leader = null;
            cameratwo.GetComponent<Thirdperson_cam>().Player = null;
            DeathMC_Sound.deathSFX = true;
        }

        
    }
}
