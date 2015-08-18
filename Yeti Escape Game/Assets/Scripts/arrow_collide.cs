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
		if (collision.transform.tag == "Yeti") {
			Destroy(this.gameObject);
			Destroy(collision.gameObject);
		}
		if (collision.transform.tag == "Player") {
			Destroy (collision.gameObject);
		}
	}
}