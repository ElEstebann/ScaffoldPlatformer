using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallHeight;
    
    public Animator animator;
    private Rigidbody2D body;
    void Start()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,fallHeight);
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0f,-1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Ground"){
            animator.SetBool("done",true);
            body.Sleep();

            Collider2D collider = GetComponent<Collider2D>();
            collider.enabled = false;

            Destroy(gameObject,1f);
            
            //Debug.Log(animator.GetBool("done"));
        }
        
        

    }
}
