using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledByContact : MonoBehaviour {

	public int lives = 3;

	//***Bug! Enemy disappears if not inside the collider box of the player.***

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary" || other.tag == "Player")
			return;
		Destroy (other.gameObject);
		lives--;
		if (lives <= 0) {
			Destroy (gameObject);
		}
	}
}
