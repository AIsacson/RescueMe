using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryControl : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if (other.tag != "Environment" && other.tag != "Enemy") {
			Destroy (other.gameObject);
		}
	}
}
