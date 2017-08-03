using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	GameObject player;

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	public void Walk(float y, float x, Animator anim, float speed, float turnSpeed)
	{
		anim.speed = 0.9f;
		anim.SetFloat ("VelY", y);
		anim.SetFloat ("VelX", x);
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			player.transform.Translate (-Vector3.forward * speed * Time.deltaTime);
		} 
		if (Input.GetKey (KeyCode.A)) {
			player.transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			player.transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
		}
	}

	/*public void WalkSound(AudioSource running){

		if (Input.GetButtonDown ("Horizontal") || Input.GetButtonDown ("Vertical")) {
			running.Play ();
		}
		else if(!(Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) && running.isPlaying){
			running.Pause ();
		}
	}*/

}
