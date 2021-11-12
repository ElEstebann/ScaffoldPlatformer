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
    //public Transform player;
    public float distanceToJump = 1f;
    public float distanceToStop = 0.5f;
    //AudioSource jumpsound;
    //private bool shootingEnabled = true;
    public Animator anim;

    void Start()
    {

        //controller = GetComponent<RunnerController2D>();
        //jumpsound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void MoveTowardsPlayer(Transform player)
    {
        
        float direction = player.position.x - transform.position.x;
  
        if(direction > 0){
            direction = 1;
            
        }
        else{
            direction = -1;
            
        }
        horizontalMove = direction * runSpeed;
        if (player.position.y - transform.position.y  - 1 > 0 && Mathf.Abs(player.position.x - transform.position.x) < distanceToJump )
        {
            jump = true;
            Debug.Log("Jumpe");
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")//if Player hits the weakspot then
        {
            MoveTowardsPlayer(collision.transform);
            anim.SetBool("isRunning",true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")//if Player hits the weakspot then
        {
            
            anim.SetBool("isRunning",false);
            horizontalMove = 0;
        }
    }

}
