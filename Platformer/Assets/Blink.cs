using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    private SpriteRenderer snailSprite;
    private CharacterController2D characterController2D;
    private bool inHurtBox = false;
    // Start is called before the first frame update
    void Start()
    {
        snailSprite = GetComponent<SpriteRenderer>();
        characterController2D = GetComponent<CharacterController2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HurtBox" && this.gameObject.transform.position.y - collision.gameObject.transform.position.y >= 0)
        {
            if (!(characterController2D.IsGrounded()))
            {
                characterController2D.m_RigidBody2D.velocity = new Vector2(characterController2D.m_RigidBody2D.velocity.x, 25);
                inHurtBox = true;
            }
        }

        if (collision.gameObject.tag == "PlayerAttack")
        {
            if (!inHurtBox)
            {
                this.StartCoroutine(BlinkSprite());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HurtBox")
        {
            inHurtBox = false;

        }

    }

    IEnumerator BlinkSprite()
    {
        for (int i = 0; i < 8; ++i)
        {
            yield return new WaitForSeconds(.05f);

            if (snailSprite.enabled == true)
                snailSprite.enabled = false;

            else
                snailSprite.enabled = true;
        }
    }
}
