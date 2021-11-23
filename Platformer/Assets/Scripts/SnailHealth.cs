using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnailHealth : MonoBehaviour
{
	public float maxHealth;
	public float currentHealth;
	public Image healthBar;
	public GameObject mainObject;
	private SpriteRenderer snailSprite;
	private CharacterController2D characterController2D;
    public Animator anim;
    public ScoreDisplay score;
    private bool inHurtBox = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>(); //get animator component
        currentHealth = maxHealth;
        score = FindObjectOfType<ScoreDisplay>();
		healthBar.fillAmount = currentHealth;
        snailSprite = GetComponentInParent<SpriteRenderer>();
        characterController2D = GetComponent<CharacterController2D>();
    }

	public void TakeDamage(float damage)
    {
        currentHealth -= damage;
		float health = currentHealth / maxHealth;
		healthBar.fillAmount = health;
		if(currentHealth == 0)      //If health goes to 0 or below, call GameOver in GameManager
		{
            StartCoroutine(Deactivate());
            score.currentScore += 30;
            //gameObject.SetActive(false);
        }
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
            this.StartCoroutine(BlinkSprite());
            this.TakeDamage(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HurtBox")
        {
            inHurtBox = false;

        }

    }

    IEnumerator Deactivate()
    {
        anim.Play("Anim");
        yield return new WaitForSeconds(.4f);
        mainObject.SetActive(false);
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