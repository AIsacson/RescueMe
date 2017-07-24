using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	GameObject player;
	Animator anim;
	PlayerHealth playerHP;
	EnemyMovement enemyLives;
	bool playerInRange;
	float timer;


	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
		enemyLives = GetComponent<EnemyMovement> ();
		playerHP = player.GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && enemyLives.lives > 0) {
			Attack();
		}

		if (playerHP.currentHealth <= 0) {
			anim.SetTrigger("PlayerDead");
		}
	}

	void Attack(){
		timer = 0;

		if (playerHP.currentHealth > 0) {
			playerHP.TakeDamage (attackDamage);
		}
	}
}
