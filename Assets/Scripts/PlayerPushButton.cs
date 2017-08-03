using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerPushButton : MonoBehaviour {

	public Text message;
	public GameObject player;

	PlayerController playerMovement;
	GameController control;

	void Awake () {
		message.text = "";
		playerMovement = player.GetComponent<PlayerController>();
		control = FindObjectOfType<GameController> ();
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, control.cPanel.transform.position) < 2f) {
			message.text = "Send SOS message, press [E]";
			if (Input.GetButton ("Push")) {
				playerMovement.PushButton ();
				message.text = "Rescue on the way, find the rescueship!";
				control.ShipSpawn ();
			}
		}
		else {
			playerMovement.Recover ();
			message.text = "";
		}
	}
}