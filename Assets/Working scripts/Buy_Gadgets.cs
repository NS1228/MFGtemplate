﻿  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Gadgets : MonoBehaviour
{
    public GameObject[] buyButtons;
    public GameObject[] useButtons;
    public GameObject[] sellButtons;

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
        if (Player.GetComponent<Money>().Gems >= 80)
        {
            useButtons[0].SetActive(true);
            buyButtons[0].SetActive(false);
            sellButtons[0].SetActive(true);
            Player.GetComponent<Money>().Gems -= 80;


        }
    }

    public void UseBoosters()
    {
        Player.GetComponent<AbilityManager>().enabled = true;
        Player.GetComponent<Normal_jump>().enabled = true;

        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
    }

    public void SellBoosters()
    {
        Player.GetComponent<Money>().Gems += 80;
        useButtons[0].SetActive(false);
        buyButtons[0].SetActive(true);
        sellButtons[0].SetActive(false);
        Player.GetComponent<AbilityManager>().enabled = false;


    }

    public void BuyRS()
    {
        if (Player.GetComponent<Money>().Gems >= 160)
        {
            useButtons[1].SetActive(true);
            buyButtons[1].SetActive(false);
            sellButtons[1].SetActive(true);
            Player.GetComponent<Money>().Gems -= 160;


        }

    }

    public void useRS()
    {
        Player.GetComponent<Rollerskates>().enabled = true;

        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;

    }

    public void SellRS()
    {
        Player.GetComponent<Money>().Gems += 160;
        useButtons[1].SetActive(false);
        buyButtons[1].SetActive(true);
        sellButtons[1].SetActive(false);
        Player.GetComponent<Rollerskates>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = true;


    }



    public void BuyBallShoe()
    {
        if(Player.GetComponent<Money>().Gems >= 250)
        {
            useButtons[2].SetActive(true);
            buyButtons[2].SetActive(false);
            sellButtons[2].SetActive(true);
            Player.GetComponent<Money>().Gems -= 250;


        }

    }

    public void UseBallShoe()
    {

        Player.GetComponent<Ballshoe_Cooldown>().enabled = true;


        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;

    }

    public void SellBallShoe()
    {
        Player.GetComponent<Money>().Gems += 250;
        useButtons[2].SetActive(false);
        buyButtons[2].SetActive(true);
        sellButtons[2].SetActive(false);
        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = true;


    }

    public void BuyBouncy()
    {
        if (Player.GetComponent<Money>().Gems >= 400)
        {
            useButtons[3].SetActive(true);
            buyButtons[3].SetActive(false);
            sellButtons[3].SetActive(true);
            Player.GetComponent<Money>().Gems -= 400;


        }

    }

    public void UseBouncy()
    {

        Player.GetComponent<Bouncy>().enabled = true;
        Player.GetComponent<Normal_jump>().enabled = true;

        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;

    }

    public void SellBouncy()
    {
        Player.GetComponent<Money>().Gems += 400;
        useButtons[3].SetActive(false);
        buyButtons[3].SetActive(true);
        sellButtons[3].SetActive(false);
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = true;


    }

    public void BuyFP()
    {

        if (Player.GetComponent<Money>().Gems >= 600)
        {
            useButtons[4].SetActive(true);
            buyButtons[4].SetActive(false);
            sellButtons[4].SetActive(true);
            Player.GetComponent<Money>().Gems -= 600;


        }

    }

    public void UseFP()
    {

        Player.GetComponent<Fp_Cooldown>().enabled = true;


        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        Player.GetComponent<Bouncy>().enabled = false;

    }

    public void SellFP()
    {
        Player.GetComponent<Money>().Gems += 600;
        useButtons[4].SetActive(false);
        buyButtons[4].SetActive(true);
        sellButtons[4].SetActive(false);
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = true;


    }

    public void BuyTeleporting()
    {
        if (Player.GetComponent<Money>().Gems >= 800)
        {
            useButtons[5].SetActive(true);
            buyButtons[5].SetActive(false);
            sellButtons[5].SetActive(true);
            Player.GetComponent<Money>().Gems -= 800;


        }

    }

    public void UseTeleporting()
    {

        Player.GetComponent<Telport_device>().enabled = true;
        Player.GetComponent<Normal_jump>().enabled = true;

        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        Player.GetComponent<Ballshoe_Cooldown>().enabled = false;
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fp_Cooldown>().enabled = false;


    }

    public void SellTeleporting()
    {
        Player.GetComponent<Money>().Gems += 800;
        useButtons[5].SetActive(false);
        buyButtons[5].SetActive(true);
        sellButtons[5].SetActive(false);
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = true;
        

    }

    public void BuyHoverboarding ()
    {

        if (Player.GetComponent<Money>().Gems >= 1000)
        {
            useButtons[6].SetActive(true);
            buyButtons[6].SetActive(false);
            sellButtons[6].SetActive(true);
            Player.GetComponent<Money>().Gems -= 1000;


        }

    }

    public void UseHoverboarding ()
    {

        Player.GetComponent<HBspawner>().enabled = true;


        Player.GetComponent<Normal_jump>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        Player.GetComponent<Ballshoe_Cooldown>().enabled = false; 
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fp_Cooldown>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;

    }

    public void SellHoverboarding()
    {
        Player.GetComponent<Money>().Gems += 1000;
        useButtons[6].SetActive(false);
        buyButtons[6].SetActive(true);
        sellButtons[6].SetActive(false);
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = true;
        hbCamera.SetActive(false);
        defaultCamera.SetActive(true);


    }

    public void BuyMines()
    {
        if (Player.GetComponent<Money>().Gems >= 80)
        {
            useButtons[7].SetActive(true);
            buyButtons[7].SetActive(false);
            sellButtons[7].SetActive(true);
            Player.GetComponent<Money>().Gems -= 80;


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

    }

    public void SellMines ()
    {
        Player.GetComponent<Money>().Gems += 80;
        useButtons[7].SetActive(false);
        buyButtons[7].SetActive(true);
        sellButtons[7].SetActive(false);
        Player.GetComponent<Mine_Generator>().enabled = false;
    }

    public void BuySleeper()
    {
        if (Player.GetComponent<Money>().Gems >= 150)
        {
            useButtons[8].SetActive(true);
            buyButtons[8].SetActive(false);
            sellButtons[8].SetActive(true);
            Player.GetComponent<Money>().Gems -= 150;


        }

    }

    public void UseSleeper()
    {
        this.GetComponent<Enemy_Sleeper>().enabled = true;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<ADA>().enabled = false;


    }

    public void SellSleeper()
    {
        Player.GetComponent<Money>().Gems += 150;
        useButtons[8].SetActive(false);
        buyButtons[8].SetActive(true);
        sellButtons[8].SetActive(false);
        Player.GetComponent<Enemy_Sleeper>().enabled = false;

    }

    public void BuyOrbs()
    {
        if (Player.GetComponent<Money>().Gems >= 300)
        {
            useButtons[9].SetActive(true);
            buyButtons[9].SetActive(false);
            sellButtons[9].SetActive(true);
            Player.GetComponent<Money>().Gems -= 300;


        }

    }

    public void UseOrbs()
    {
        this.GetComponent<Orbvest_manager>().enabled = true;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Enemy_Sleeper>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<ADA>().enabled = false;

    }

    public void SellOrbs()
    {
        Player.GetComponent<Money>().Gems += 300;
        useButtons[9].SetActive(false);
        buyButtons[9].SetActive(true);
        sellButtons[9].SetActive(false);
        Player.GetComponent<Orbvest_manager>().enabled = false;
    }

    public void BuyIceTrail()
    {
        if (Player.GetComponent<Money>().Gems >= 500)
        {
            useButtons[10].SetActive(true);
            buyButtons[10].SetActive(false);
            sellButtons[10].SetActive(true);
            Player.GetComponent<Money>().Gems -= 500;


        }
    }

    public void UseIceTrail()
    {
        this.GetComponent<Icetrail_Manager>().enabled = true;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Enemy_Sleeper>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<ADA>().enabled = false;

    }

    public void SellIceTrail()
    {
        Player.GetComponent<Money>().Gems += 500;
        useButtons[10].SetActive(false);
        buyButtons[10].SetActive(true);
        sellButtons[10].SetActive(false);
        Player.GetComponent<Icetrail_Manager>().enabled = false;

    }

    public void BuyTurrets()
    {
        if (Player.GetComponent<Money>().Gems >= 700)
        {
            useButtons[11].SetActive(true);
            buyButtons[11].SetActive(false);
            sellButtons[11].SetActive(true);
            Player.GetComponent<Money>().Gems -= 700;


        }
    }

    public void UseTurrets()
    {
        this.GetComponent<Spawn_Objects>().enabled = true;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Enemy_Sleeper>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<ADA>().enabled = false;

    }

    public void SellTurrets()
    {
        Player.GetComponent<Money>().Gems += 700;
        useButtons[11].SetActive(false);
        buyButtons[11].SetActive(true);
        sellButtons[11].SetActive(false);
        Player.GetComponent<Spawn_Objects>().enabled = false;
    }

    public void BuyLightning()
    {
        if (Player.GetComponent<Money>().Gems >= 900)
        {
            useButtons[12].SetActive(true);
            buyButtons[12].SetActive(false);
            sellButtons[12].SetActive(true);
            Player.GetComponent<Money>().Gems -= 900;


        }
    }

    public void UseLightning()
    {
        this.GetComponent<Lighting_Spawner>().enabled = true;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Enemy_Sleeper>().enabled = false;
        this.GetComponent<ADA>().enabled = false;
    }

    public void SellLightning()
    {
        Player.GetComponent<Money>().Gems += 900;
        useButtons[12].SetActive(false);
        buyButtons[12].SetActive(true);
        sellButtons[12].SetActive(false);
        Player.GetComponent<Lighting_Spawner>().enabled = false;

    }

    public void BuyGrenade()
    {
        if (Player.GetComponent<Money>().Gems >= 1100)
        {
            useButtons[13].SetActive(true);
            buyButtons[13].SetActive(false);
            sellButtons[13].SetActive(true);
            Player.GetComponent<Money>().Gems -= 1100;


        }
    }

    public void UseGrenade()
    {
        this.GetComponent<ADA>().enabled = true;

        this.GetComponent<Mine_Generator>().enabled = false;
        this.GetComponent<Orbvest_manager>().enabled = false;
        this.GetComponent<Icetrail_Manager>().enabled = false;
        this.GetComponent<Spawn_Objects>().enabled = false;
        this.GetComponent<Lighting_Spawner>().enabled = false;
        this.GetComponent<Enemy_Sleeper>().enabled = false;
    }

    public void SellGrenaqde()
    {
        Player.GetComponent<Money>().Gems += 1100;
        useButtons[13].SetActive(false);
        buyButtons[13].SetActive(true);
        sellButtons[13].SetActive(false);
        Player.GetComponent<ADA>().enabled = false;
    }

 
}
 