using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    
    public GameObject mainObject;
    public float speed = 20f;
    public float timeOut = 10f;
    public Rigidbody2D rb;
    [SerializeField] private bool destroyOnPlayer;
    [SerializeField]private bool destroyOnGround;
    [SerializeField]private bool destroyOnHurtBox;


    void Start()
    {
        Destroy(gameObject,timeOut);
        rb.velocity = transform.right * speed;
    }
    //Gets call when a trigger collision happens on the game scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "HurtBox" && destroyOnHurtBox)//if Player hits the weakspot then
        {
            Destroy(gameObject); //Deactivate the mainObject scene object. We could destroy, but in order to still have access to such object 
                                         //so we can do things like reviving it, we deactivate it instead. 
        }
        else if(collision.tag == "Ground" && destroyOnGround)
        {
            Destroy(gameObject);
        }
        else if (collision.tag == "Player" && destroyOnPlayer){
            Destroy(gameObject);
        }
    }
}
