using UnityEngine;
using System.Collections;

public class char_Movement : MonoBehaviour {

	private Rigidbody rb;
	public float speed = 15f;

	//Used for intialization
	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	//Updates every frame after physics simulation 
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);	 
	}	
}

