using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthBar;

	Animator anim;
	PlayerController playerMovement;
	bool isDead;
	bool damaged;

	void Awake(){
		anim = GetComponent<Animator> ();
		playerMovement = GetComponent<PlayerController> ();

		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			anim.SetTrigger ("GetHit");
		}
		damaged = false;
		anim.SetTrigger ("Recover");
	}

	public void TakeDamage(int amount){
		damaged = true;

		currentHealth -= amount;

		healthBar.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {

			Death ();
		}
	}

	void Death(){
		isDead = true;

		anim.SetTrigger ("PlayerDeath");

		playerMovement.enabled = false;
	}
}
