﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {

    /// <summary>
    /// CharacterController2D handles the core logic of the player's:
    /// -States such as: grounded, immune, air jumps lefts, and facing right.
    /// -Properties such as: how many air jumps, jump power, gravity force, movement, and air control
    /// 
    /// CharacterController2D is often getting called by other scripts that want to gather/modify information from the player(Ex: PlayerMovement) 
    /// </summary>
    
    [SerializeField] private float m_JumpForce = 800f;
    [SerializeField] public int m_AirJumps = 0;
    [SerializeField] private float m_FallGravity = 4f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private LayerMask m_GroundLayer;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private bool m_AirControl = false;
    [SerializeField] private float m_JumpForceOnEnemies = 20;

    private bool m_Grounded;
    public bool m_FacingRight = true;
    public bool m_Damaged;
    public bool m_Immune = false;
    private int m_AirJumpsLeft;
    private Vector3 m_Velocity = Vector3.zero;
    public GameObject FirePoints;

    [HideInInspector] public Rigidbody2D m_RigidBody2D;
    private Animator anim; //If using animations
    AudioSource jumpsound;

    void Awake()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //get animator component
        jumpsound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moving = Input.GetAxisRaw("Horizontal");
        m_Grounded = Physics2D.Linecast(transform.position, m_GroundCheck.position, m_GroundLayer);
        if (m_Grounded)
        {
            m_AirJumpsLeft = m_AirJumps;
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if (moving == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    private void Update()
    {
      
    }

    //Handles the player movement and their jumping, called in PlayerMovement.cs
    public void Move(float move, bool jump)
    {

        if (m_Grounded || m_AirControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, m_RigidBody2D.velocity.y);

            m_RigidBody2D.velocity = Vector3.SmoothDamp(m_RigidBody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (move > 0 && !m_FacingRight)
                Flip();
            
            else if (move < 0 && m_FacingRight)
                Flip();
            
        }

        JumpGravity(jump);

        if (m_Grounded && jump)
        {
            m_Grounded = false;
            m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce));
            anim.Play("flash");
            jumpsound.Play();
        }

        //Air Jump
        else if (jump && m_AirJumpsLeft > 0)
        {
            m_Grounded = false;
            m_RigidBody2D.AddForce(new Vector2(0f, m_JumpForce));
            m_AirJumpsLeft--;
        }
    }

    //Enhances the Jump by adding gravity when falling, short hop, and full hop
    void JumpGravity(bool jump)
    {
        if (jump && m_AirJumpsLeft >= 1)
            m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, 0); //resets gravity if player jumps in the air so we the momentum doesnt kill the jump force
 
        if (m_RigidBody2D.velocity.y < 0) //we are falling, therefore increase gravity down
        {
            m_RigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (m_FallGravity - 1) * Time.deltaTime;
            
        }
        
        else if (m_RigidBody2D.velocity.y > 0  && !Input.GetButton("Jump"))//Tab Jump
            m_RigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (m_FallGravity - 1) * Time.deltaTime; 
    }

    //Turns around the gameObject attach to this script
    void Flip()
    {
        
        m_FacingRight = !m_FacingRight;
        /*
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        
        Replace upper code with:*/
        transform.Rotate(0f,180f,0f);
        FirePoints.transform.Rotate(0f,180f,0f);
        
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "hurtbox" && this.gameObject.transform.position.y - collide.gameObject.transform.position.y >= 0)
        {
            m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, m_JumpForceOnEnemies);
        }

    }

    //Used by other scripts to check Character status
    public bool IsGrounded()
    {
        return m_Grounded;
    }

}
