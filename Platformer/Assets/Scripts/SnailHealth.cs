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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>(); //get animator component
        currentHealth = maxHealth;
        score = FindObjectOfType<ScoreDisplay>();
		healthBar.fillAmount = currentHealth;
		snailSprite = GetComponent<SpriteRenderer>();
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
        if (collision.gameObject.tag == "PlayerAttack")
        {
            this.TakeDamage(1);
        }
    }

    IEnumerator Deactivate()
    {
        anim.Play("Anim");
        yield return new WaitForSeconds(.4f);
        mainObject.SetActive(false);
    }
}