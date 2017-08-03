using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {
	
	GameObject rescShip;
	GameObject player;
	EndGameController endGame;
	//Animator anim;

	public bool fly = false;

	// Use this for initialization
	void Start () {
		rescShip = GameObject.FindGameObjectWithTag ("Ship");
		player = GameObject.FindGameObjectWithTag ("Player");
		endGame = FindObjectOfType<EndGameController> ();
		//anim = player.GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			fly = true;
		}
	}

	void Update(){
		if (fly) {
			endGame.Congrats ();
			player.transform.Translate (Vector3.up* 3 * Time.deltaTime);
			player.SetActive (false);
			rescShip.transform.Translate (Vector3.forward * 3 * Time.deltaTime);
		}
	}
}
