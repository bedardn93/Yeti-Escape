using UnityEngine;
using System.Collections;

public class YetiCollision : MonoBehaviour {

	public BoxCollider collider1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag=="arrow"){
			Destroy (this.gameObject);
		}
	}
}
