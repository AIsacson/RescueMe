using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthBar;
	public Image fill;

	Color mediumHealth = Color.yellow;
	Color lowHealth = Color.red;
	Animator anim;
	PlayerController player;
	bool isDead;
	bool damaged;
	GameOverMenuController gameOver;

	void Awake(){
		anim = GetComponent<Animator> ();
		player = GetComponent<PlayerController> ();

		currentHealth = startingHealth;
		gameOver = FindObjectOfType<GameOverMenuController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			anim.SetTrigger ("GetHit");
		}
		damaged = false;
		anim.SetTrigger ("Recover");
		SetHealthUI ();
	}

	public void TakeDamage(int amount){
		damaged = true;

		currentHealth -= amount;
		player.gettingHit.Play ();

		SetHealthUI ();

		healthBar.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {

			Death ();
		}
	}

	void Death(){
		isDead = true;

		anim.SetTrigger ("PlayerDeath");

		player.enabled = false;
		gameOver.GameOver ();
		player.running.Stop ();
		player.dying.Play ();
	}

	void SetHealthUI(){
		healthBar.value = currentHealth;

		if (currentHealth == 50) {
			fill.color = mediumHealth;
		}
		if (healthBar.value <= 20) {
			fill.color = lowHealth;
		}
	}
}
