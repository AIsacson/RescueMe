using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float turnSpeed;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	AudioSource running;
	AudioSource shooting;

	Animator anim;
	float nextFire;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		AudioSource [] audio = GetComponents<AudioSource> ();
		shooting = audio [0];
		running = audio [1];
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		var x = Input.GetAxis ("Horizontal");
		var y = Input.GetAxis ("Vertical");

		Walk (y, x);
	}

	void Update(){
		bool fire = Input.GetButtonDown ("Fire1");
		anim.SetBool ("Fire", fire);
		if (fire && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			shooting.Play ();
		}

		if (Input.GetButtonDown ("Horizontal") || Input.GetButtonDown ("Vertical")) {
			running.Play ();
		}
		else if(!(Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) && running.isPlaying){
			running.Pause ();
		}
	}

	void Walk(float y, float x)
	{
		anim.speed = 0.9f;
		anim.SetFloat ("VelY", y);
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-Vector3.forward * speed * Time.deltaTime);
		} 
		Rotate (x);
	}

	void Rotate(float x){
		anim.SetFloat ("VelX", x);
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
		}
	}
}