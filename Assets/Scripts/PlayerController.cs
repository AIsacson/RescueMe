using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float turnSpeed;
	public float fireRate;
	public Text ammo;
	public int bullets = 15;
	public AudioSource running;
	public AudioSource gettingHit;
	public AudioSource dying;

	Animator anim;
	float nextFire;
	AudioSource shooting;
	GameController control;


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		control = FindObjectOfType<GameController> ();
		AudioSource [] audio = GetComponents<AudioSource> ();
		shooting = audio [0];
		running = audio [1];
		dying = audio [2];
		gettingHit = audio [3];
		ammo.text = bullets.ToString() + "/15";
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
		bool reload = Input.GetButtonDown ("Reload");
		anim.SetBool ("Fire", fire);
		anim.SetBool ("Reload", reload);
		if ((bullets > 0) && fire && Time.time > nextFire && (bullets != 0)) {
			nextFire = Time.time + fireRate;
			//Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			control.BulletSpawn();
			shooting.Play ();
			bullets--;
			ammo.text = bullets.ToString() + "/15";
		}

		if (reload) {
			Invoke ("Reload", 3.5f);
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

	void Reload(){
		bullets = 15;
		anim.speed = 0.9f;
		ammo.text = bullets.ToString() + "/15";
	}

	public void PushButton (){
			anim.SetBool ("PushButton", true);
	}

	public void Recover(){
		anim.SetBool ("PushButton", false);
	}
}