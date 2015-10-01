using UnityEngine;
using System.Collections;

public class char_shoot : MonoBehaviour {

	public float shootSpeed;
	public float ammo = 5;
	public float maxAmmo = 5;

	public Transform shot;
	public Transform shotSpawn;
	public float fireRate;
	public GameObject w_Lantern;
	public GameObject w_Bow;

	public int currentWeapon=0;
	public int numWeapons = 2;

	private float nextFire;

	//Vector3 fwd = Transform.TransformDirection(transform.forward);

	void Start() {

	}

	void arrowFire(){
		//Create arrow as gameobject at shot spawn's location
		GameObject arrowInstance = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
	}

	void gunFire(){
		//if (Physics.Raycast (transform.position, fwd, 10))
			//Debug.Log ("There is something in front of the object.");
	}

	// Update is called once per frame
	void Update () {
		shoot ();
		selectLantern (currentWeapon, w_Lantern);

	}

	/*
	 *Name: Select Lantern 
	 *Purpose: If the itemSelect number is equal to a number between 1 and 2, 
	 *         lantern will be set to active. Else, it will be set to inactive
	 *@author Tinytunafish
	 */
	void selectLantern(int itemSelect, GameObject lantern){
		if (itemSelect ==1)
			//Change weapon to lantern
			lantern.SetActive (true);
		else
			lantern.SetActive (false);
	}

	void shoot(){
		//If player left clicks and the time for 
		//nextFire has passed then fire and restart nextFire clock
		if (Input.GetMouseButtonDown (0) && Time.time > nextFire) {
			if (currentWeapon == 0 && ammo > 0) { 
				nextFire = Time.time + fireRate;
				arrowFire ();
				ammo--;
			}
		}
/*		//mouse wheel down
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
		}*/
		if (Input.GetKeyDown("1")){
			currentWeapon = 0;
		} else if (Input.GetKeyDown("f")){
			if(currentWeapon < 1)
				currentWeapon = 1;
			else
				currentWeapon = 0;
		}

	}

	void FixedUpdate(){

	}
}
