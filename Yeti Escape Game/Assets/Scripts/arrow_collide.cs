using UnityEngine;
using System.Collections;

public class arrow_collide : MonoBehaviour {

	public float speed = 5;

	//When arrow spawns add force to it to send it flying foward.
	void Start() {
		GetComponent<Rigidbody> ().AddForce (transform.forward * speed*1000);
	}
	
	void OnTriggerEnter(Collider collision){
		Debug.Log ("hit");
		if (collision.transform.tag == "Maze") {
			Destroy (collision.gameObject);
		}
		if (collision.transform.tag == "Yeti") {
			//Destroy(this.gameObject);
			//Destroy(collision.gameObject);
		}
		if (collision.transform.tag == "Player") {
			Destroy (this.gameObject);
		}
	}

	//When arrow collides the arrow will stop moving but will "stick"
	//to the "parent" or object it collides with.
	void OnCollisionEnter(Collision col){
		Rigidbody rb = (Rigidbody)GetComponent (typeof(Rigidbody));
		Transform t = (Transform)GetComponent (typeof(Transform));
		if (col.transform.tag != "Player") {
			rb.isKinematic = true;
			t.parent = col.transform;
			if(col.transform.tag == "Yeti"){
				Debug.Log ("Hit Yeti");
				Destroy (col.gameObject);
			}
		}
	}
}