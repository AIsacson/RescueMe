using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	GameObject player;
	NavMeshAgent nav;
	PlayerHealth playerHP;
	public GameObject enemy;

	Animator anim;

	public bool alive = true;
	public int lives = 4;


	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHP = player.GetComponent<PlayerHealth> ();
		anim = this.transform.GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update () {

		if (alive) {
			Vector3 randomPos = Random.insideUnitSphere * 20f;
			NavMeshHit navHit;
			NavMesh.SamplePosition (transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);
			nav.SetDestination (navHit.position);
			anim.SetTrigger ("PlayerGone");

			if (Vector3.Distance (player.transform.position, enemy.transform.position) < 20f) {
				nav.speed = 4.5f;
				anim.speed = 2f;
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
		Destroy (gameObj, 10.0f);
	}

	void GetHit(){
		anim.SetTrigger ("EnemyHit");
	}

	void PlayerDies(){
		anim.SetTrigger ("PlayerDead");
		anim.speed = 0f;
		nav.speed = 0f;
	}
}
