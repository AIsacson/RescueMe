using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	public GameObject player;
	NavMeshAgent nav;
	public Transform eyes;
	Animator anim;

	private string state = "idle";
	private bool alive = true;

	void Awake () {
		anim = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		if (alive) {
			if (state == "idle") {
				Vector3 pos = Random.insideUnitSphere * 10f;
				NavMeshHit navHit;
				NavMesh.SamplePosition (transform.position + pos, out navHit, 10f, NavMesh.AllAreas);
				nav.SetDestination (navHit.position);
				state = "walk";
			}
			if (state == "walk") {
				if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending) {
					state = "idle";
				}
			}
			if (state == "chase") {
				nav.SetDestination (player.transform.position);
			}
		}
	}

	public void checkSight(){
		if (alive) {
			RaycastHit rayHit;
			if (Physics.Linecast (eyes.position, player.transform.position, out rayHit)) {
				if (rayHit.collider.gameObject.name == "Player") {
					if (state != "kill") {
						state = "chase";
						nav.speed = 4.5f;
						anim.speed = 4.5f;
						print ("chase");
					}
				}
			}
		}
	}
}
