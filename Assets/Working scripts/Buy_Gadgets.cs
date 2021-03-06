﻿  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Gadgets : MonoBehaviour
{
    public GameObject[] buyButtons;
    public GameObject[] useButtons;
    public GameObject[] sellButtons;
    public GameObject[] abilityIcons;
    public GameObject[] sellIcons;
    public GameObject[] price;

    public GameObject Player;

    public GameObject defaultCamera;
    public GameObject hbCamera;
    //public GameObject ballShoe;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //ballShoe = GameObject.FindGameObjectWithTag("Ballshoe");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyBoosters()
    {
        if (Player.GetComponent<Money>().Gems >= 50)
        {
            useButtons[0].SetActive(true);
            buyButtons[0].SetActive(false);
            sellButtons[0].SetActive(true);
            Player.GetComponent<Money>().Gems -= 50;
            price[0].SetActive(false);
            


        }
    }

    public void UseBoosters()
    {
        Player.GetComponent<AbilityManager>().enabled = true;
        Player.GetComponent<Telport_device>().tpdevices = 1;

        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = false;
        abilityIcons[0].SetActive(true);


        abilityIcons[1].SetActive(false);
        abilityIcons[2].SetActive(false);
        abilityIcons[3].SetActive(false);
        abilityIcons[4].SetActive(false);
        abilityIcons[5].SetActive(false);
        abilityIcons[6].SetActive(false);
        

        sellIcons[1].SetActive(false);
        sellIcons[2].SetActive(false);
        sellIcons[3].SetActive(false);
        sellIcons[4].SetActive(false);
        sellIcons[5].SetActive(false);
        sellIcons[6].SetActive(false);
      





    }

    public void SellBoosters()
    {
        Player.GetComponent<Money>().Gems += 50;
        useButtons[0].SetActive(false);
        buyButtons[0].SetActive(true);
        sellButtons[0].SetActive(false);
        Player.GetComponent<AbilityManager>().enabled = false;
        abilityIcons[0].SetActive(false);
        sellIcons[0].SetActive(false);
       price[0].SetActive(true);


    }

    public void BuyRS()
    {
        if (Player.GetComponent<Money>().Gems >= 100)
        {
            useButtons[1].SetActive(true);
            buyButtons[1].SetActive(false);
            sellButtons[1].SetActive(true);
            Player.GetComponent<Money>().Gems -= 100;
            price[1].SetActive(false);



        }

    }

    public void useRS()
    {
        Player.GetComponent<Rollerskates>().enabled = true;
        Player.GetComponent<Telport_device>().tpdevices = 1;

        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        abilityIcons[1].SetActive(true);


        abilityIcons[0].SetActive(false);
        abilityIcons[2].SetActive(false);
        abilityIcons[3].SetActive(false);
        abilityIcons[4].SetActive(false);
        abilityIcons[5].SetActive(false);
        abilityIcons[6].SetActive(false);
        

        sellIcons[0].SetActive(false);
        sellIcons[2].SetActive(false);
        sellIcons[3].SetActive(false);
        sellIcons[4].SetActive(false);
        sellIcons[5].SetActive(false);
        sellIcons[6].SetActive(false);
        




    }

    public void SellRS()
    {
        Player.GetComponent<Money>().Gems += 100;
        useButtons[1].SetActive(false);
        buyButtons[1].SetActive(true);
        sellButtons[1].SetActive(false);
        Player.GetComponent<Rollerskates>().enabled = false;
        abilityIcons[1].SetActive(false);
        sellIcons[1].SetActive(false);
        price[1].SetActive(true);



    }



    public void BuyBallShoe()
    {
        if(Player.GetComponent<Money>().Gems >= 150)
        {
            useButtons[2].SetActive(true);
            buyButtons[2].SetActive(false);
            sellButtons[2].SetActive(true);
            Player.GetComponent<Money>().Gems -= 150;
            price[2].SetActive(false);



        }

    }

    public void UseBallShoe()
    {

        Player.GetComponent<Ballshoe_Cooldown>().enabled = true;
        Player.GetComponent<Telport_device>().tpdevices = 1;

        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        abilityIcons[2].SetActive(true);


        abilityIcons[1].SetActive(false);
        abilityIcons[0].SetActive(false);
        abilityIcons[3].SetActive(false);
        abilityIcons[4].SetActive(false);
        abilityIcons[5].SetActive(false);
        abilityIcons[6].SetActive(false);
       

        sellIcons[1].SetActive(false);
        sellIcons[0].SetActive(false);
        sellIcons[3].SetActive(false);
        sellIcons[4].SetActive(false);
        sellIcons[5].SetActive(false);
        sellIcons[6].SetActive(false);
       

    }

    public void SellBallShoe()
    {
        Player.GetComponent<Money>().Gems += 150;
        useButtons[2].SetActive(false);
        buyButtons[2].SetActive(true);
        sellButtons[2].SetActive(false);
        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        abilityIcons[2].SetActive(false);
        sellIcons[2].SetActive(false);
        price[2].SetActive(true);



    }

    public void BuyBouncy()
    {
        if (Player.GetComponent<Money>().Gems >= 200)
        {
            useButtons[3].SetActive(true);
            buyButtons[3].SetActive(false);
            sellButtons[3].SetActive(true);
            Player.GetComponent<Money>().Gems -= 200;
            price[3].SetActive(false);



        }

    }

    public void UseBouncy()
    {

        Player.GetComponent<Bouncy>().enabled = true;
        Player.GetComponent<Telport_device>().tpdevices = 1;

        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = false;
        abilityIcons[3].SetActive(true);


        abilityIcons[1].SetActive(false);
        abilityIcons[2].SetActive(false);
        abilityIcons[0].SetActive(false);
        abilityIcons[4].SetActive(false);
        abilityIcons[5].SetActive(false);
        abilityIcons[6].SetActive(false);
      

        sellIcons[1].SetActive(false);
        sellIcons[2].SetActive(false);
        sellIcons[0].SetActive(false);
        sellIcons[4].SetActive(false);
        sellIcons[5].SetActive(false);
        sellIcons[6].SetActive(false);
        
    }

    public void SellBouncy()
    {
        Player.GetComponent<Money>().Gems += 200;
        useButtons[3].SetActive(false);
        buyButtons[3].SetActive(true);
        sellButtons[3].SetActive(false);
        Player.GetComponent<Bouncy>().enabled = false;
        abilityIcons[3].SetActive(false);
        sellIcons[3].SetActive(false);
        price[3].SetActive(true);



    }

    public void BuyFP()
    {

        if (Player.GetComponent<Money>().Gems >= 350 )
        {
            useButtons[5].SetActive(true);
            buyButtons[5].SetActive(false);
            sellButtons[5].SetActive(true);
            Player.GetComponent<Money>().Gems -= 350;
            price[5].SetActive(false);



        }

    }

    public void UseFP()
    {

        Player.GetComponent<Fp_Cooldown>().enabled = true;
        Player.GetComponent<Fly_test>().enabled = true;
        Player.GetComponent<Telport_device>().tpdevices = 1;

        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        Player.GetComponent<Bouncy>().enabled = false;
        abilityIcons[5].SetActive(true);


        abilityIcons[1].SetActive(false);
        abilityIcons[2].SetActive(false);
        abilityIcons[3].SetActive(false);
        abilityIcons[4].SetActive(false);
        abilityIcons[0].SetActive(false);
        abilityIcons[6].SetActive(false);
        
        sellIcons[1].SetActive(false);
        sellIcons[2].SetActive(false);
        sellIcons[3].SetActive(false);
        sellIcons[4].SetActive(false);
        sellIcons[0].SetActive(false);
        sellIcons[6].SetActive(false);
       

    }

    public void SellFP()
    {
        Player.GetComponent<Money>().Gems += 350;
        useButtons[5].SetActive(false);
        buyButtons[5].SetActive(true);
        sellButtons[5].SetActive(false);
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = false;
        abilityIcons[5].SetActive(false);
        sellIcons[5].SetActive(false);
        price[5].SetActive(true);


    }

    public void BuyTeleporting()
    {
        if (Player.GetComponent<Money>().Gems >= 250)
        {
            useButtons[4].SetActive(true);
            buyButtons[4].SetActive(false);
            sellButtons[4].SetActive(true);
            Player.GetComponent<Money>().Gems -= 250;
            price[4].SetActive(false);




        }

    }

    public void UseTeleporting()
    {

        Player.GetComponent<Telport_device>().enabled = true;
        

        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = false;
        abilityIcons[4].SetActive(true);


        abilityIcons[1].SetActive(false);
        abilityIcons[2].SetActive(false);
        abilityIcons[3].SetActive(false);
        abilityIcons[0].SetActive(false);
        abilityIcons[5].SetActive(false);
        abilityIcons[6].SetActive(false);
       

        sellIcons[1].SetActive(false);
        sellIcons[2].SetActive(false);
        sellIcons[3].SetActive(false);
        sellIcons[0].SetActive(false);
        sellIcons[5].SetActive(false);
        sellIcons[6].SetActive(false);
        
    }

    public void SellTeleporting()
    {
        Player.GetComponent<Money>().Gems += 250;
        useButtons[4].SetActive(false);
        buyButtons[4].SetActive(true);
        sellButtons[4].SetActive(false);
        Player.GetComponent<Telport_device>().enabled = false;
        abilityIcons[4].SetActive(false);
        sellIcons[4].SetActive(false);
        price[4].SetActive(true);



    }

    public void BuyHoverboarding ()
    {

        if (Player.GetComponent<Money>().Gems >= 450)
        {
            useButtons[6].SetActive(true);
            buyButtons[6].SetActive(false);
            sellButtons[6].SetActive(true);
            Player.GetComponent<Money>().Gems -= 450;
            price[6].SetActive(false);




        }

    }

    public void UseHoverboarding ()
    {
        Player.GetComponent<Telport_device>().tpdevices = 1;
        Player.GetComponent<HBspawner>().enabled = true;
        

        Player.GetComponent<Fly_test>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        Player.GetComponent<Ballshoe_Cooldown>().enabled = false; 
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        abilityIcons[6].SetActive(true);


        abilityIcons[1].SetActive(false);
        abilityIcons[2].SetActive(false);
        abilityIcons[3].SetActive(false);
        abilityIcons[4].SetActive(false);
        abilityIcons[5].SetActive(false);
        abilityIcons[0].SetActive(false);
        

        sellIcons[1].SetActive(false);
        sellIcons[2].SetActive(false);
        sellIcons[3].SetActive(false);
        sellIcons[4].SetActive(false);
        sellIcons[5].SetActive(false);
        sellIcons[0].SetActive(false);
      
    }

    public void SellHoverboarding()
    {
        Player.GetComponent<Money>().Gems += 400;
        useButtons[6].SetActive(false);
        buyButtons[6].SetActive(true);
        sellButtons[6].SetActive(false);
        Player.GetComponent<HBspawner>().enabled = false;
        abilityIcons[6].SetActive(false);
        sellIcons[6].SetActive(false);
        price[6].SetActive(true);

        hbCamera.SetActive(false);
        defaultCamera.SetActive(true);


    }

    public void BuyMines()
    {
        if (Player.GetComponent<Money>().Gems >= 50)
        {
            useButtons[7].SetActive(true);
            buyButtons[7].SetActive(false);
            sellButtons[7].SetActive(true);
            Player.GetComponent<Money>().Gems -= 50;
            price[7].SetActive(false);



        }

    }

    public void UseMines()
    {
        this.GetComponent<Mine_Generator>().enabled = true;

        this.GetComponent<Enemy_Sleeper>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<ADA>().enabled = false;
        abilityIcons[7].SetActive(true);


     
        
        abilityIcons[8].SetActive(false);
        abilityIcons[9].SetActive(false);
        abilityIcons[10].SetActive(false);
        abilityIcons[11].SetActive(false);
        abilityIcons[12].SetActive(false);
        abilityIcons[13].SetActive(false);

       
        
        sellIcons[8].SetActive(false);
        sellIcons[9].SetActive(false);
        sellIcons[10].SetActive(false);
        sellIcons[11].SetActive(false);
        sellIcons[12].SetActive(false);
        sellIcons[13].SetActive(false);
    }

    public void SellMines ()
    {
        Player.GetComponent<Money>().Gems += 50;
        useButtons[7].SetActive(false);
        buyButtons[7].SetActive(true);
        sellButtons[7].SetActive(false);
        Player.GetComponent<Mine_Generator>().enabled = false;
        abilityIcons[7].SetActive(false);
        sellIcons[7].SetActive(false);
    }

    public void BuySleeper()
    {
        if (Player.GetComponent<Money>().Gems >= 100)
        {
            useButtons[8].SetActive(true);
            buyButtons[8].SetActive(false);
            sellButtons[8].SetActive(true);
            Player.GetComponent<Money>().Gems -= 100;
            price[8].SetActive(false);



        }

    }

    public void UseSleeper()
    {
        this.GetComponent<Enemy_Sleeper>().enabled = true;
        Player.GetComponent<Mine_Generator>().maxMines = 3;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<ADA>().enabled = false;
        abilityIcons[8].SetActive(true);



      
        abilityIcons[7].SetActive(false);
       
        abilityIcons[9].SetActive(false);
        abilityIcons[10].SetActive(false);
        abilityIcons[11].SetActive(false);
        abilityIcons[12].SetActive(false);
        abilityIcons[13].SetActive(false);

        
        sellIcons[7].SetActive(false);
       
        sellIcons[9].SetActive(false);
        sellIcons[10].SetActive(false);
        sellIcons[11].SetActive(false);
        sellIcons[12].SetActive(false);
        sellIcons[13].SetActive(false);


    }

    public void SellSleeper()
    {
        Player.GetComponent<Money>().Gems += 100;
        useButtons[8].SetActive(false);
        buyButtons[8].SetActive(true);
        sellButtons[8].SetActive(false);
        Player.GetComponent<Enemy_Sleeper>().enabled = false;
        abilityIcons[8].SetActive(false);
        sellIcons[8].SetActive(false);
        price[8].SetActive(true);


    }

    public void BuyOrbs()
    {
        if (Player.GetComponent<Money>().Gems >= 150)
        {
            useButtons[9].SetActive(true);
            buyButtons[9].SetActive(false);
            sellButtons[9].SetActive(true);
            Player.GetComponent<Money>().Gems -= 150;
            price[9].SetActive(false);



        }

    }

    public void UseOrbs()
    {
        this.GetComponent<Orbvest_manager>().enabled = true;
        Player.GetComponent<Mine_Generator>().maxMines = 3;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Enemy_Sleeper>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<ADA>().enabled = false;
        abilityIcons[9].SetActive(true);


      
        abilityIcons[7].SetActive(false);
        abilityIcons[8].SetActive(false);
       
        abilityIcons[10].SetActive(false);
        abilityIcons[11].SetActive(false);
        abilityIcons[12].SetActive(false);
        abilityIcons[13].SetActive(false);

       
        sellIcons[7].SetActive(false);
        sellIcons[8].SetActive(false);
       
        sellIcons[10].SetActive(false);
        sellIcons[11].SetActive(false);
        sellIcons[12].SetActive(false);
        sellIcons[13].SetActive(false);

    }

    public void SellOrbs()
    {
        Player.GetComponent<Money>().Gems += 150;
        useButtons[9].SetActive(false);
        buyButtons[9].SetActive(true);
        sellButtons[9].SetActive(false);
        Player.GetComponent<Orbvest_manager>().enabled = false;
        abilityIcons[9].SetActive(false);
        abilityIcons[9].SetActive(false);
        price[9].SetActive(true);
    }

    public void BuyIceTrail()
    {
        if (Player.GetComponent<Money>().Gems >= 200)
        {
            useButtons[10].SetActive(true);
            buyButtons[10].SetActive(false);
            sellButtons[10].SetActive(true);
            Player.GetComponent<Money>().Gems -= 200;
            price[10].SetActive(false);



        }
    }

    public void UseIceTrail()
    {
        this.GetComponent<Icetrail_Manager>().enabled = true;
        Player.GetComponent<Mine_Generator>().maxMines = 3;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Enemy_Sleeper>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<ADA>().enabled = false;
        abilityIcons[10].SetActive(true);


       
        abilityIcons[7].SetActive(false);
        abilityIcons[8].SetActive(false);
        abilityIcons[9].SetActive(false);
       
        abilityIcons[11].SetActive(false);
        abilityIcons[12].SetActive(false);
        abilityIcons[13].SetActive(false);

      
        sellIcons[7].SetActive(false);
        sellIcons[8].SetActive(false);
        sellIcons[9].SetActive(false);
       
        sellIcons[11].SetActive(false);
        sellIcons[12].SetActive(false);
        sellIcons[13].SetActive(false);

    }

    public void SellIceTrail()
    {
        Player.GetComponent<Money>().Gems += 200;
        useButtons[10].SetActive(false);
        buyButtons[10].SetActive(true);
        sellButtons[10].SetActive(false);
        Player.GetComponent<Icetrail_Manager>().enabled = false;
        abilityIcons[10].SetActive(false);
        sellIcons[10].SetActive(false);
        price[10].SetActive(true);

    }

    public void BuyTurrets()
    {
        if (Player.GetComponent<Money>().Gems >= 250)
        {
            useButtons[11].SetActive(true);
            buyButtons[11].SetActive(false);
            sellButtons[11].SetActive(true);
            Player.GetComponent<Money>().Gems -= 250;
            price[11].SetActive(false);



        }
    }

    public void UseTurrets()
    {
        this.GetComponent<Spawn_Objects>().enabled = true;
        Player.GetComponent<Mine_Generator>().maxMines = 3;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Enemy_Sleeper>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<ADA>().enabled = false;
        abilityIcons[11].SetActive(true);


       
        abilityIcons[7].SetActive(false);
        abilityIcons[8].SetActive(false);
        abilityIcons[9].SetActive(false);
        abilityIcons[10].SetActive(false);
   
        abilityIcons[12].SetActive(false);
        abilityIcons[13].SetActive(false);

      
        sellIcons[7].SetActive(false);
        sellIcons[8].SetActive(false);
        sellIcons[9].SetActive(false);
        sellIcons[10].SetActive(false);
      
        sellIcons[12].SetActive(false);
        sellIcons[13].SetActive(false);

    }

    public void SellTurrets()
    {
        Player.GetComponent<Money>().Gems += 250;
        useButtons[11].SetActive(false);
        buyButtons[11].SetActive(true);
        sellButtons[11].SetActive(false);
        Player.GetComponent<Spawn_Objects>().enabled = false;
        abilityIcons[11].SetActive(false);
        sellIcons[11].SetActive(false);
       price[11].SetActive(true);
    }

    public void BuyLightning()
    {
        if (Player.GetComponent<Money>().Gems >= 350)
        {
            useButtons[12].SetActive(true);
            buyButtons[12].SetActive(false);
            sellButtons[12].SetActive(true);
            Player.GetComponent<Money>().Gems -= 350;
            price[12].SetActive(false);



        }
    }

    public void UseLightning()
    {
        this.GetComponent<Lighting_Spawner>().enabled = true;
        Player.GetComponent<Mine_Generator>().maxMines = 3;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Enemy_Sleeper>().enabled = false;
        this.GetComponent<ADA>().enabled = false;
        abilityIcons[12].SetActive(true);

        
        abilityIcons[7].SetActive(false);
        abilityIcons[8].SetActive(false);
        abilityIcons[9].SetActive(false);
        abilityIcons[10].SetActive(false);
        abilityIcons[11].SetActive(false);
      
        abilityIcons[13].SetActive(false);

  
        sellIcons[7].SetActive(false);
        sellIcons[8].SetActive(false);
        sellIcons[9].SetActive(false);
        sellIcons[10].SetActive(false);
        sellIcons[11].SetActive(false);
        
        sellIcons[13].SetActive(false);
    }

    public void SellLightning()
    {
        Player.GetComponent<Money>().Gems += 350;
        useButtons[12].SetActive(false);
        buyButtons[12].SetActive(true);
        sellButtons[12].SetActive(false);
        Player.GetComponent<Lighting_Spawner>().enabled = false;
        abilityIcons[12].SetActive(false);
        sellIcons[12].SetActive(false);
        price[12].SetActive(true);

    }

    public void BuyGrenade()
    {
        if (Player.GetComponent<Money>().Gems >= 450)
        {
            useButtons[13].SetActive(true);
            buyButtons[13].SetActive(false);
            sellButtons[13].SetActive(true);
            Player.GetComponent<Money>().Gems -= 450;
            price[13].SetActive(false);



        }
    }

    public void UseGrenade()
    {
        this.GetComponent<ADA>().enabled = true;
        Player.GetComponent<Mine_Generator>().maxMines = 3;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<Enemy_Sleeper>().enabled = false;
        abilityIcons[13].SetActive(true);


      
        abilityIcons[7].SetActive(false);
        abilityIcons[8].SetActive(false);
        abilityIcons[9].SetActive(false);
        abilityIcons[10].SetActive(false);
        abilityIcons[11].SetActive(false);
        abilityIcons[12].SetActive(false);
      

       
        sellIcons[7].SetActive(false);
        sellIcons[8].SetActive(false);
        sellIcons[9].SetActive(false);
        sellIcons[10].SetActive(false);
        sellIcons[11].SetActive(false);
        sellIcons[12].SetActive(false);
       
    }

    public void SellGrenaqde()
    {
        Player.GetComponent<Money>().Gems += 450;
        useButtons[13].SetActive(false);
        buyButtons[13].SetActive(true);
        sellButtons[13].SetActive(false);
        Player.GetComponent<ADA>().enabled = false;
        abilityIcons[13].SetActive(false);
        sellIcons[13].SetActive(false);
       price[13].SetActive(true);
    }

 
}
 