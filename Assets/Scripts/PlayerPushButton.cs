using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerPushButton : MonoBehaviour {

	public Text message;

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
			if (Input.GetKey (KeyCode.E)) {
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
	}
}
