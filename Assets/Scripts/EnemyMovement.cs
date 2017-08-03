using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	GameObject player;
	NavMeshAgent nav;
	PlayerHealth playerHP;
	EnemyAttack enemyScript;
	AudioSource dying;
	Animator anim;

	public bool alive = true;
	public int lives = 3;
	public GameObject enemy;


	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHP = player.GetComponent<PlayerHealth> ();
		anim = this.transform.GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
		enemyScript = FindObjectOfType<EnemyAttack> ();
		AudioSource [] audio = GetComponents<AudioSource> ();
		dying = audio [2];
	}

	void Update () {

		if (alive) {
			Vector3 randomPos = Random.insideUnitSphere * 30f;
			NavMeshHit navHit;
			NavMesh.SamplePosition (transform.position + randomPos, out navHit, 10f, NavMesh.AllAreas);
			nav.SetDestination (navHit.position);
			anim.SetTrigger ("PlayerGone");

			if (Vector3.Distance (player.transform.position, enemy.transform.position) < 20f) {
				nav.speed = 5.5f;
				anim.speed = 2.3f;
				nav.SetDestination (player.transform.position);
				anim.SetTrigger ("PlayerSpotted");
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
			anim.speed = 1f;
			Death (gameObject);
		}
	}

	void Death(GameObject gameObj){
		anim.SetTrigger ("EnemyDead");
		nav.enabled = false;
		alive = false;
		dying.Play ();
		Destroy (gameObj, 20f);
	}

	void GetHit(){
		anim.SetTrigger ("EnemyHit");
		enemyScript.gettingHit.Play ();
	}

	void PlayerDies(){
		anim.SetTrigger ("PlayerDead");
		anim.speed = 0f;
		nav.speed = 0f;
	}
}
