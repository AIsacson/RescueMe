﻿using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Animator anim;
	public float speed;
	public float turnSpeed;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
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
			GetComponent<AudioSource>().Play ();
		}
	}

	void Walk(float y, float x)
	{
		anim.SetFloat ("VelY", y);
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			transform.Translate (-Vector3.forward * speed * Time.deltaTime);
		}
		Rotate (x);
	}

	void Rotate(float x){
		anim.SetFloat ("VelX", x);
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
		}
	}
}