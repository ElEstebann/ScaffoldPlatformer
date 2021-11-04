using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovement : MonoBehaviour {
    /// <summary>
    /// PlayeMovement handles the movement of the player by specifying player speed, reading user Input,
    /// and calling CharacterController2D to move the Player Object  
    /// </summary>
    
    [SerializeField] private float runSpeed;
    float horizontalMove = 0f;
    bool jump = false;
    public RunnerController2D controller;
    public static bool inputEnabled = true;
    public Transform player;
    public float distanceToJump = 1f;
    public float distanceToStop = 0.5f;
    //AudioSource jumpsound;
    //private bool shootingEnabled = true;
    public Animator anim;

    void Start()
    {

        controller = GetComponent<RunnerController2D>();
        //jumpsound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float direction = player.position.x - transform.position.x;
        if (player.position.x - transform.position.x < distanceToStop &&  player.position.x - transform.position.x > (distanceToStop * -1)){
            direction = 0;
            anim.SetBool("isRunning",false);
        }
        else if(direction > 0){
            direction = 1;
            anim.SetBool("isRunning",true);
        }
        else{
            direction = -1;
            anim.SetBool("isRunning",true);
        }
        horizontalMove = direction * runSpeed;
        if (player.position.y - transform.position.y  - 1 > 0 && Mathf.Abs(player.position.x - transform.position.x) < distanceToJump )
        {
            jump = true;
            //jumpsound.Play();
            
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
