using UnityEngine;
using System.Collections;

public class char_shoot : MonoBehaviour {

	public float speed;

	public Transform shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Start() {

	}

	void Fire(){
		//Create arrow as gameobject at shot spawn's location
		GameObject arrowInstance = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
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
