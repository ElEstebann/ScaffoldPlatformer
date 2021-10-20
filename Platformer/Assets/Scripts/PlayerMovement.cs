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

    void Start()
    {

        controller = GetComponent<CharacterController2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputEnabled){

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }

    // FixedUpdate is called multiple times per x amount of frames
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
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
