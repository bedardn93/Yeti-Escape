using UnityEngine;
using System.Collections;

public class char_shoot : MonoBehaviour {

	public float speed;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Start() {

	}

	void Fire(){
		//Create arrow as gameobject at shot spawn's location
		GameObject arrowInstance = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
		arrowInstance.tag = "Arrow";
		//Add Rigidbody to it for physics
		BoxCollider arrowCollider = arrowInstance.AddComponent<BoxCollider> ();
		Rigidbody clone = arrowInstance.AddComponent<Rigidbody> ();
		//Add arrow collide script to handle collisions
		arrowInstance.AddComponent <arrow_collide>();
		//Shoot arrow forward from Transform object's location
		clone.AddForce (shotSpawn.forward * speed*1000);
	}

	// Update is called once per frame
	void Update () {
		//If player left clicks and the time for 
		//nextFire has passed then fire and restart nextFire clock
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Fire ();
		}
	}

	void FixedUpdate(){

	}
}
