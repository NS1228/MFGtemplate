using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirsperson_character : MonoBehaviour
{

    public bool hasBall;
    public GameObject ballShoe;
    public static float speed;
    public float verSpeed;
    public float ballSpeed;
    public float boosterSpeed;
    public float flightSpeed;

    public Animator animator;
    public float blend;
    public float blendside;
    public float doubleblend;


    public bool isGrounded;

    Rigidbody thisrigidbody;

   


    // Start is called before the first frame update
    void Start()
    {

        speed = 4f;
        hasBall = false;
        animator = this.GetComponent<Animator>();
        thisrigidbody = this.GetComponent<Rigidbody>();
        


    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Bouncy>().canBounce == false)
        {
            GetComponent<BoxCollider>().material = null;
        }

        PlayerMovement();

        // blend = Input.GetAxis("Vertical");
        //  animator.SetFloat("Movement", blend);

        // blendside = Input.GetAxis("Horizontal");
        //  animator.SetFloat("Moveside", blendside);


        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            animator.SetBool("isJog", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isLeftStrafe", false);
            animator.SetBool("isRightStrafe", false);
            animator.SetBool("Backwards", false);
            animator.SetBool("isJump", false);

           
            

            if (hasBall)
            {
                this.GetComponent<Anim_testing>().enabled = true;
                animator.SetBool("Ballshoe", true);
                animator.SetBool("BSidle", false);
                animator.SetBool("BSleft", false);
                animator.SetBool("BSright", false);
                this.GetComponent<Normal_jump>().enabled = false;
            }
            else
            {
                this.GetComponent<Anim_testing>().enabled = false;
                animator.SetBool("Ballshoe", false);
                this.GetComponent<Normal_jump>().enabled = true;

            }

            if(this.GetComponent<Rollerskates>().skating)
            {
                animator.SetBool("isSkating", true);
                
            }
            if (this.GetComponent<Rollerskates>().skating == false)
            {
                animator.SetBool("isSkating", false);
               
            }
            //  animator.SetBool("isSkating", false);

            if (this.GetComponent<Bouncy>().canBounce)
            {
                animator.SetBool("isJog", false);
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                animator.SetBool("isIdle", true);

            }


            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && Teleporting_Sound.muteWalk == false && HB_sound.hbSFX == false && !this.GetComponent<Bouncy>().canBounce)
            {
                Sound_Manager.jogSFX = true;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
               Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 1f);
                


            }
            if (!hasBall && AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = true;
                Strafe_Sound.bsSFX = false;
                animator.SetFloat("Boost", 3f);
                BS_sound.rollingSFX = false;



            }

            if (hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = true;
                
                 
                

            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && FP_Sound.fpSFX == true)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;

            }


        }
        else if (Input.GetKey(KeyCode.A) && isGrounded)
        {
            animator.SetBool("isJog", false);
            animator.SetBool("isRightStrafe", false);
            animator.SetBool("isLeftStrafe", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("Backwards", false);
            animator.SetBool("isJump", false);
            animator.SetBool("isSkating", false);
            //  animator.SetBool("isSkating", false);

            if (hasBall)
            {
                this.GetComponent<Anim_testing>().enabled = true;
                animator.SetBool("Ballshoe", false);
                animator.SetBool("BSidle", false);
                animator.SetBool("BSleft", true);
                animator.SetBool("BSright", false);
                this.GetComponent<Normal_jump>().enabled = false;
            }
            else
            {
                this.GetComponent<Anim_testing>().enabled = false;
                animator.SetBool("BSleft", false);
                this.GetComponent<Normal_jump>().enabled = true;

            }

            if (this.GetComponent<Bouncy>().canBounce)
            {
                animator.SetBool("isLeftStrafe", false);
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                animator.SetBool("isIdle", true);
            }



            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && Teleporting_Sound.muteWalk == false && HB_sound.hbSFX == false && !this.GetComponent<Bouncy>().canBounce)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = true;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                animator.SetFloat("Boost", 1f);
                
            }

            if (!hasBall && AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = true;
                animator.SetFloat("Boost", 3f);
                
            }

            if (hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = true;
            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && FP_Sound.fpSFX == true)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;

            }
        }

        else if (Input.GetKey(KeyCode.D) && isGrounded)
        {
            animator.SetBool("isJog", false);
            animator.SetBool("isRightStrafe", true);
            animator.SetBool("isLeftStrafe", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("Backwards", false);
            animator.SetBool("isJump", false);
            //  animator.SetBool("isSkating", false);

            if (hasBall)
            {
                this.GetComponent<Anim_testing>().enabled = true;
                animator.SetBool("Ballshoe", false);
                animator.SetBool("BSidle", false);
                animator.SetBool("BSleft", false);
                animator.SetBool("BSright", true);
                this.GetComponent<Normal_jump>().enabled = false;
            }
            else
            {
                this.GetComponent<Anim_testing>().enabled = false;
                animator.SetBool("BSright", false);
                this.GetComponent<Normal_jump>().enabled = true;
            }

            if (this.GetComponent<Bouncy>().canBounce)
            {
                animator.SetBool("isRightStrafe", false);
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                animator.SetBool("isIdle", true);
            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && Teleporting_Sound.muteWalk == false && HB_sound.hbSFX == false && !this.GetComponent<Bouncy>().canBounce)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = true;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                animator.SetFloat("Boost", 1f);
                
            }

            if (!hasBall && AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = true;
                animator.SetFloat("Boost", 3f);
                
            }

            if (hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = true;
            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && FP_Sound.fpSFX == true)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;

            }
        }

        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && isGrounded)
        {
            animator.SetBool("isJog", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isLeftStrafe", false);
            animator.SetBool("isRightStrafe", false);
            animator.SetBool("Backwards", false);
            animator.SetBool("isJump", false);
            // animator.SetBool("isSkating", false);

            if (hasBall)
            {
                this.GetComponent<Anim_testing>().enabled = true;
                animator.SetBool("Ballshoe", true);
                animator.SetBool("BSidle", false);
                animator.SetBool("BSleft", false);
                animator.SetBool("BSright", false);
                this.GetComponent<Normal_jump>().enabled = false;
            }
            else
            {
                this.GetComponent<Anim_testing>().enabled = false;
                animator.SetBool("Ballshoe", false);
                this.GetComponent<Normal_jump>().enabled = true;
            }

            if (this.GetComponent<Bouncy>().canBounce)
            {
                animator.SetBool("isJog", false);
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                animator.SetBool("isIdle", true);
            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && Teleporting_Sound.muteWalk == false && HB_sound.hbSFX == false && !this.GetComponent<Bouncy>().canBounce)
            {
                Sound_Manager.jogSFX = true;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 1f);
                
               
            }

            if (!hasBall && AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = true;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 3f);
                
            }

            if (hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = true;
               
                

            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && FP_Sound.fpSFX == true)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;

            }

        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && isGrounded)
        {
            animator.SetBool("isJog", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isLeftStrafe", false);
            animator.SetBool("isRightStrafe", false);
            animator.SetBool("Backwards", false);
            animator.SetBool("isJump", false);
            //  animator.SetBool("isSkating", false);

            if (hasBall)
            {
                this.GetComponent<Anim_testing>().enabled = true;
                animator.SetBool("Ballshoe", true);
                animator.SetBool("BSidle", false);
                animator.SetBool("BSleft", false);
                animator.SetBool("BSright", false);
                this.GetComponent<Normal_jump>().enabled = false;
            }
            else
            {
                this.GetComponent<Anim_testing>().enabled = false;
                animator.SetBool("Ballshoe", false);
                this.GetComponent<Normal_jump>().enabled = true;
            }

            if (this.GetComponent<Bouncy>().canBounce)
            {
                animator.SetBool("isJog", false);
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;

            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && Teleporting_Sound.muteWalk == false && HB_sound.hbSFX == false && !this.GetComponent<Bouncy>().canBounce)
            {
                Sound_Manager.jogSFX = true;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
               BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 1f);
                
            }

            if (!hasBall && AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = true;
                Strafe_Sound.bsSFX = false;
               BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 3f);
                
            }

            if (hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = true;



            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && FP_Sound.fpSFX == true)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;

            }

        }
        else if (Input.GetKey(KeyCode.S) && isGrounded)
        {
            animator.SetBool("isJog", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isLeftStrafe", false);
            animator.SetBool("isRightStrafe", false);
            animator.SetBool("Backwards", true);
            animator.SetBool("isJump", false);
            // animator.SetBool("isSkating", false);

            if (hasBall)
            {
                this.GetComponent<Anim_testing>().enabled = true;
                animator.SetBool("Ballshoe", true);
                animator.SetBool("BSidle", false);
                animator.SetBool("BSleft", false);
                animator.SetBool("BSright", false);
                this.GetComponent<Normal_jump>().enabled = false;
            }
            else
            {
                this.GetComponent<Anim_testing>().enabled = false;
                animator.SetBool("Ballshoe", false);
                this.GetComponent<Normal_jump>().enabled = true;
            }

            if (this.GetComponent<Bouncy>().canBounce)
            {
                animator.SetBool("isJog", false);
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                animator.SetBool("isIdle", true);
            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && Teleporting_Sound.muteWalk == false && HB_sound.hbSFX == false && !this.GetComponent<Bouncy>().canBounce)
            {
                Sound_Manager.jogSFX = true;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
               BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 1f);
                
            }

            if (!hasBall && AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = true;
                Strafe_Sound.bsSFX = false;
               BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 3f);
                
            }

            if (hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = true;



            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && FP_Sound.fpSFX == true)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;

            }

            //setback to true;

        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && isGrounded)
        {
            animator.SetBool("isJog", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isLeftStrafe", false);
            animator.SetBool("isRightStrafe", false);
            animator.SetBool("Backwards", true);
            animator.SetBool("isJump", false);
            // animator.SetBool("isSkating", false);

            if (hasBall)
            {
                this.GetComponent<Anim_testing>().enabled = true;
                animator.SetBool("Ballshoe", true);
                animator.SetBool("BSidle", false);
                animator.SetBool("BSleft", false);
                animator.SetBool("BSright", false);
                this.GetComponent<Normal_jump>().enabled = false;
            }
            else
            {
                this.GetComponent<Anim_testing>().enabled = false;
                animator.SetBool("Ballshoe", false);
                this.GetComponent<Normal_jump>().enabled = true;
            }

            if (this.GetComponent<Bouncy>().canBounce)
            {
                animator.SetBool("isJog", false);
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                animator.SetBool("isIdle", true);
            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && Teleporting_Sound.muteWalk == false && HB_sound.hbSFX == false && !this.GetComponent<Bouncy>().canBounce)
            {
                Sound_Manager.jogSFX = true;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 1f);
                

            }

            if (!hasBall && AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = true;
                Strafe_Sound.bsSFX = false;
               BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 3f);
                
            }

            if (hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = true;



            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && FP_Sound.fpSFX == true)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;

            }

            //setback to true;

        }

        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && isGrounded)
        {
            animator.SetBool("isJog", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isLeftStrafe", false);
            animator.SetBool("isRightStrafe", false);
            animator.SetBool("Backwards", true);
            animator.SetBool("isJump", false);
            //animator.SetBool("isSkating", false);

            if (hasBall)
            {
                this.GetComponent<Anim_testing>().enabled = true;
                animator.SetBool("Ballshoe", true);
                animator.SetBool("BSidle", false);
                animator.SetBool("BSleft", false);
                animator.SetBool("BSright", false);
                this.GetComponent<Normal_jump>().enabled = false;
            }
            else
            {
                this.GetComponent<Anim_testing>().enabled = false;
                animator.SetBool("Ballshoe", false);
                this.GetComponent<Normal_jump>().enabled = true;
            }

            if (this.GetComponent<Bouncy>().canBounce)
            {
                animator.SetBool("isJog", false);
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                animator.SetBool("isIdle", true);
            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && Teleporting_Sound.muteWalk == false && HB_sound.hbSFX == false && !this.GetComponent<Bouncy>().canBounce)
            {
                Sound_Manager.jogSFX = true;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 1f);
               
            }

            if (!hasBall && AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = true;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;
                animator.SetFloat("Boost", 3f);
               
            }

            if (hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = true;



            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && FP_Sound.fpSFX == true)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;

            }

            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && FP_Sound.fpSFX == true)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;
                

            }



            //setback to true;

        }

        else
        {

            if (!Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("isJog", false);
                animator.SetBool("isIdle", true);
                animator.SetBool("isLeftStrafe", false);
                animator.SetBool("isRightStrafe", false);
                animator.SetBool("Backwards", false);
                animator.SetBool("isJump", false);
            }
            //  animator.SetBool("isSkating", false);

            if (hasBall)
            {
                this.GetComponent<Anim_testing>().enabled = true;
                animator.SetBool("Ballshoe", true);
                animator.SetBool("BSidle", true);
                this.GetComponent<Normal_jump>().enabled = false;
            }
            else
            {
                this.GetComponent<Anim_testing>().enabled = false;
                animator.SetBool("Ballshoe", false);
                animator.SetBool("BSleft", false);
                animator.SetBool("BSidle", false);
                this.GetComponent<Normal_jump>().enabled = true;
            }

            if (this.GetComponent<Bouncy>().canBounce)
            {
                animator.SetBool("isIdle", true);
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                animator.SetBool("isJog", false);

            }



            if (!hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false && Teleporting_Sound.muteWalk == false && HB_sound.hbSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;
            }

            if (!hasBall && AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
               BS_sound.rollingSFX = false;
                
            }

            if (hasBall && !AbilityManager.hasBooster && Jump_sound.jumpSFX == false)
            {
                Sound_Manager.jogSFX = false;
                Strafe_Sound.strafeSFX = false;
                Sound_Manager.boostSFX = false;
                Strafe_Sound.bsSFX = false;
                BS_sound.rollingSFX = false;
                //turn on sound for ballshoe//



            }

            


        }


        if (thisrigidbody.velocity.y < -8 && !this.GetComponent<Rollerskates>().skating && !hasBall) 
            {
                isGrounded = false;
            animator.SetBool("isFalling", true);
            }

        if (thisrigidbody.velocity.y < -1 && !this.GetComponent<Rollerskates>().skating && !hasBall && this.GetComponent<Bouncy>().canBounce == true)
        {
            isGrounded = false;
            animator.SetBool("isFalling", true);
        }




        }

        void PlayerMovement()
        {
            if (hasBall)
            {
                float hor = Input.GetAxis("Horizontal");
                float ver = Input.GetAxis("Vertical");
                Vector3 playerMovement = new Vector3(hor, 0f, ver) * ballSpeed * Time.deltaTime;
                transform.Translate(playerMovement, Space.Self);
            }

            if (!hasBall & AbilityManager.hasBooster == false)
            {
                float hor = Input.GetAxis("Horizontal");
                float ver = Input.GetAxis("Vertical");
                Vector3 playerMovement = new Vector3(hor, 0f, ver * verSpeed) * speed * Time.deltaTime;
                transform.Translate(playerMovement, Space.Self);
            }

            if (AbilityManager.hasBooster & !hasBall)
            {
                float hor = Input.GetAxis("Horizontal");
                float ver = Input.GetAxis("Vertical");
                Vector3 playerMovement = new Vector3(hor, 0f, ver * verSpeed) * boosterSpeed * Time.deltaTime;
                transform.Translate(playerMovement, Space.Self);

            }

        if (!AbilityManager.hasBooster && !hasBall && this.GetComponent<Fly_test>().canFly == true)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * flightSpeed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);

        }



        if (ballShoe.activeInHierarchy)
            {
                hasBall = true;

            }
            else
            {
                hasBall = false;
            }


        }




        
        void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.tag == "Floor")
            {
                isGrounded = true;
            animator.SetBool("isFalling", false);

           




        }

        }

        void OnCollisionExit(Collision collision)
        {

            if (collision.gameObject.tag == "Floor")
            {
                //

            }

     
    }
    }

        
    
        
    
    






    


