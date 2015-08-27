using UnityEngine;
using System.Collections;

public class char_shoot : MonoBehaviour {

	public float speed;

	public Transform shot;
	public Transform shotSpawn;
	public float fireRate;

	public int currentWeapon;
	public int numWeapons = 3;

	private float nextFire;

	Vector3 fwd = Transform.TransformDirection(transform.forward);

	void Start() {

	}

	void arrowFire(){
		//Create arrow as gameobject at shot spawn's location
		GameObject arrowInstance = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
	}

	void gunFire(){
		if (Physics.Raycast (transform.position, fwd, 10))
			Debug.Log ("There is something in front of the object.");
	}

	// Update is called once per frame
	void Update () {
		//If player left clicks and the time for 
		//nextFire has passed then fire and restart nextFire clock
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			if (currentWeapon == 0) { 
				nextFire = Time.time + fireRate;
				arrowFire ();
			} else if (currentWeapon == 1) {
				Debug.Log ("Shoot other thing");
				gunFire();
			}
		}
		//mouse wheel down
		if(Input.GetAxis("Mouse ScrollWheel") < 0){
			if(currentWeapon < numWeapons-1){
				currentWeapon++;
			}else{
				currentWeapon = 0;
			}
		//mouse wheel up
		} else if(Input.GetAxis ("Mouse ScrollWheel") > 0){
			if(currentWeapon-1 >= 0){
				currentWeapon--;
			} else {
				currentWeapon = numWeapons-1;
			}
		}
		if (Input.GetKeyDown("1")){
			currentWeapon = 0;
		} else if (Input.GetKeyDown("2")){
			currentWeapon = 1;
		}
	}

	void FixedUpdate(){

	}
}
