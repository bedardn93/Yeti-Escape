using UnityEngine;
using System.Collections;

public class arrow_collide : MonoBehaviour {

	void Start() {
		
	}
	
	void OnTriggerEnter(Collider collision){
		Debug.Log ("hit");
		if (collision.transform.tag == "Maze") {
			Destroy (collision.gameObject);
		}
		if (collision.transform.tag == "YetiModel") {
			//Destroy(this.gameObject);
			//Destroy(collision.gameObject);
		}
		if (collision.transform.tag == "Player") {
			Destroy (collision.gameObject);
		}
	}

	void OnCollisionEnter(Collision col){
		Rigidbody rb = (Rigidbody)GetComponent (typeof(Rigidbody));
		Transform t = (Transform)GetComponent (typeof(Transform));
		if (col.transform.tag != "Player") {
			rb.isKinematic = true;
			t.parent = col.transform;
		}
	}
}