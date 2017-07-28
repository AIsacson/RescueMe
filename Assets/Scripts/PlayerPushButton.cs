using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerPushButton : MonoBehaviour {

	public Text message;
	public Transform spawnShip;
	public GameObject ship;

	GameObject cPanel;
	GameObject player;
	Animator anim;

	void Awake () {
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		cPanel = GameObject.FindGameObjectWithTag ("ControlPanel");
		message.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, cPanel.transform.position) < 1.5f) {
			message.text = "Send SOS message, press [E]";
			if (Input.GetButton ("Push")) {
				anim.SetBool ("PushedButton", true);
				Rescue ();
			}
		}
		else {
			anim.SetBool ("PushedButton", false);
			message.text = "";
		}
	}

	void Rescue(){
		message.text = "Rescue on the way, get out of there!";
		Invoke ("ShipSpawn", 5);
	}

	void ShipSpawn(){
		if (GameObject.FindGameObjectsWithTag ("Ship").Length <= 0) {
			Instantiate (ship, spawnShip.position, spawnShip.rotation);
		}
	}
}