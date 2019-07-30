using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Gadgets : MonoBehaviour
{
    public GameObject[] buyButtons;
    public GameObject[] useButtons;

    public GameObject Player;
    public GameObject ballShoe;
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
            Player.GetComponent<Money>().Gems -= 80;


        }
    }

    public void UseBoosters()
    {
        Player.GetComponent<AbilityManager>().enabled = true;
        Player.GetComponent<Normal_jump>().enabled = true;

        ballShoe.SetActive(false);
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
    }

    public void BuyRS()
    {
        if (Player.GetComponent<Money>().Gems >= 160)
        {
            useButtons[1].SetActive(true);
            buyButtons[1].SetActive(false);
            Player.GetComponent<Money>().Gems -= 160;


        }

    }

    public void useRS()
    {
        Player.GetComponent<Rollerskates>().enabled = true;

        ballShoe.SetActive(false);
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;

    }

    public void BuyBallShoe()
    {
        if(Player.GetComponent<Money>().Gems >= 250)
        {
            useButtons[2].SetActive(true);
            buyButtons[2].SetActive(false);
            Player.GetComponent<Money>().Gems -= 250;


        }

    }

    public void UseBallShoe()
    {

        ballShoe.SetActive(true);


        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;

    }

    public void BuyBouncy()
    {
        if (Player.GetComponent<Money>().Gems >= 400)
        {
            useButtons[3].SetActive(true);
            buyButtons[3].SetActive(false);
            Player.GetComponent<Money>().Gems -= 400;


        }

    }

    public void UseBouncy()
    {

        Player.GetComponent<Bouncy>().enabled = true;

        
        Player.GetComponent<Fly_test>().enabled = false;
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        ballShoe.SetActive(false);

    }

    public void BuyFP()
    {

        if (Player.GetComponent<Money>().Gems >= 600)
        {
            useButtons[4].SetActive(true);
            buyButtons[4].SetActive(false);
            Player.GetComponent<Money>().Gems -= 600;


        }

    }

    public void UseFP()
    {

        Player.GetComponent<Fly_test>().enabled = true;

       
        Player.GetComponent<Telport_device>().enabled = false;
        Player.GetComponent<HBspawner>().enabled = false;
        Player.GetComponent<Normal_jump>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        ballShoe.SetActive(false);
        Player.GetComponent<Bouncy>().enabled = false;

    }

    public void BuyTeleporting()
    {
        if (Player.GetComponent<Money>().Gems >= 800)
        {
            useButtons[5].SetActive(true);
            buyButtons[5].SetActive(false);
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
        ballShoe.SetActive(false);
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = true;


    }

    public void BuyHoverboarding ()
    {

        if (Player.GetComponent<Money>().Gems >= 1000)
        {
            useButtons[6].SetActive(true);
            buyButtons[6].SetActive(false);
            Player.GetComponent<Money>().Gems -= 1000;


        }

    }

    public void UseHoverboarding ()
    {

        Player.GetComponent<HBspawner>().enabled = true;


        Player.GetComponent<Normal_jump>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rollerskates>().enabled = false;
        ballShoe.SetActive(false);
        Player.GetComponent<Bouncy>().enabled = false;
        Player.GetComponent<Fly_test>().enabled = true;
        Player.GetComponent<Telport_device>().enabled = false;

    }
}
