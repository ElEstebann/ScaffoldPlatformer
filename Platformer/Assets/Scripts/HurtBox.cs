using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HurtBox is the "weakness" area of an entity, if the player hits an enemy on such spot the enemy takes damage. This script is attached to an object
/// with a "HurtBox tag.
/// </summary>
public class HurtBox : MonoBehaviour {

    public GameObject mainObject;

    //Gets call when a trigger collision happens on the game scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerAttack")//if Player hits the weakspot then
        {
            mainObject.SetActive(false); //Deactivate the mainObject scene object. We could destroy, but in order to still have access to such object 
                                         //so we can do things like reviving it, we deactivate it instead. 
        }
    }
}
