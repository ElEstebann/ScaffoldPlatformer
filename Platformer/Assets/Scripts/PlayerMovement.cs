using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    /// <summary>
    /// PlayeMovement handles the movement of the player by specifying player speed, reading user Input,
    /// and calling CharacterController2D to move the Player Object  
    /// </summary>
    
    [SerializeField] private float runSpeed;
    float horizontalMove = 0f;
    bool jump = false;
    public CharacterController2D controller;
    public static bool inputEnabled = true;
    private Animator anim; //If using animations
    AudioSource jumpsound;
    //private bool shootingEnabled = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
        jumpsound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputEnabled){

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                anim.SetBool("isJumping", true);
                anim.SetBool("isRunning", false);
                anim.Play("flash");
                jumpsound.Play();
                
            }
            /*
            if (Input.GetButton("FireRight")){
                Debug.Log("Right");
            }
            else if(Input.GetButton("FireLeft")){
                Debug.Log("Left");
            }
            else if(Input.GetButton("FireUp")){
                Debug.Log("Up");
            }
            else if(Input.GetButton("FireDown")){
                Debug.Log("Down");
            }
            */
        }
    }

    // FixedUpdate is called multiple times per x amount of frames
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
        anim.SetBool("isJumping", false);
        anim.SetBool("inAir", false);
    }

    public void EnableInput(){
        //Debug.Log("Enabling input");
        inputEnabled = true;
    }


    public void DisableInput(){
        //Debug.Log("Disabling input");
        inputEnabled = false;
    }


}
