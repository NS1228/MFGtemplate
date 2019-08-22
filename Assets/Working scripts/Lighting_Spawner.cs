﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Lighting_Spawner : MonoBehaviour
{

    public GameObject[] arrayOfGameObjects;
    public bool spawnYes = true;
    public bool switcherbool = false;

    public float timer = 0;
    public float cooldownTimer = 0;

    public bool reset;

    public float animTimer;
    public bool deployLightning;

    Animator anim;

    AudioSource audios;

    public void Start ()
    {
        anim = this.GetComponent<Animator>();
        audios = this.GetComponent<AudioSource>();
    }

    // Randomly activates an inactive game object
    public void Update()
    {
        if(deployLightning && Time.time >= animTimer)
        {
            deployLightning = false;
            anim.SetBool("Lightning", false);
            Thirsperson_character.speed = 4;
            this.GetComponent<Thirsperson_character>().verSpeed = 2;
            audios.volume = 1;
            Mine_Sound.lightningSFX = false;

        }
        
        if (Input.GetKeyDown(KeyCode.E) && spawnYes)
        {
            
            GameObject selection = arrayOfGameObjects
            .Where(i => !i.activeSelf)
            .OrderBy(n => Random.value).FirstOrDefault();

            // selection will be null if all game objects are already active
            if (selection != null) selection.SetActive(true);
            spawnYes = false;
            timer = Time.time + 5;
            switcherbool = true;
            anim.SetBool("Lightning", true);
            deployLightning = true;
            animTimer = Time.time + 3.02f;
            Thirsperson_character.speed = 0;
            this.GetComponent<Thirsperson_character>().verSpeed = 0;
            audios.volume = 0;
            Mine_Sound.lightningSFX = true;




        }

        Switchingthing();
        Cooldown();
    }

    
    public void Switchingthing ()
    {
        if(Time.time >= timer && switcherbool)
        {
            switcherbool = false;
            
            arrayOfGameObjects[0].SetActive(false);
            arrayOfGameObjects[1].SetActive(false);

            cooldownTimer = Time.time + 5f;
            reset = true;



        }
    }


    public void Cooldown ()
    {
        if(reset && Time.time >= cooldownTimer)
        {
            spawnYes = true;
            reset = false;
        }

    }
}

