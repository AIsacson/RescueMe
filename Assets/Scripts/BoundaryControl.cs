using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryControl : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if (other.tag != "Environment" && other.tag != "Enemy" && other.tag != "ControlPanel") {
			Destroy (other.gameObject);
		}
	}
}
