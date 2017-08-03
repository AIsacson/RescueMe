using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class BossController : MonoBehaviour {

	public GameObject boss;
	public bool alive = true;
	GameObject player;
	NavMeshAgent nav;
	Animator anim;
	PlayerHealth playerHP;
	AudioSource dying;
	public int lives = 10;



	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHP = player.GetComponent<PlayerHealth> ();
		anim = this.transform.GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
		AudioSource [] audio = GetComponents<AudioSource> ();
		dying = audio [1];
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			
			if (Vector3.Distance (player.transform.position, boss.transform.position) < 20f) {
				nav.speed = 1.5f;
				nav.SetDestination (player.transform.position);
				anim.SetTrigger ("PlayerSpotted");
			}
			if (Vector3.Distance (player.transform.position, boss.transform.position) < 5f) {
				nav.speed = 3f;
				nav.SetDestination (player.transform.position);
				anim.SetTrigger ("PlayerAttack");
			} else {
				anim.SetTrigger ("PlayerGone");
			}

			if (playerHP.currentHealth <= 0) {
				PlayerDies ();
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
			return;
		Destroy (other.gameObject);
		lives--;
		if (lives > 0) {
			GetHit ();
		}
		if (lives <= 0) {
			nav.speed = 0f;
			Death (gameObject);
		}
	}

	void Death(GameObject gameObj){
		anim.SetTrigger ("BossDead");
		nav.enabled = false;
		alive = false;
		Destroy (gameObj, 20f);
		dying.Play ();
	}

	void GetHit(){
		anim.SetTrigger ("BossHit");
	}

	void PlayerDies(){
		anim.SetTrigger ("PlayerGone");
		anim.speed = 0f;
		nav.speed = 0f;
	}
}
