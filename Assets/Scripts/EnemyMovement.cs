using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	public GameObject enemy;
	Animator anim;

	public bool alive = true;
	public int lives = 4;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update () {

		if (alive) {
			Vector3 randomPos = Random.insideUnitSphere * 20f;
			NavMeshHit navHit;
			NavMesh.SamplePosition (transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);
			nav.SetDestination (navHit.position);
			anim.SetTrigger ("PlayerGone");

			if (Vector3.Distance (player.position, enemy.transform.position) < 20f) {
				nav.speed = 3.5f;
				anim.speed = 1.5f;
				nav.SetDestination (player.position);
				anim.SetTrigger ("PlayerSpotted");
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
}
