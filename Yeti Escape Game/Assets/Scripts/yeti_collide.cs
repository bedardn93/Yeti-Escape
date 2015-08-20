using UnityEngine;
using System.Collections;

public class yeti_collide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Arrow"){
			Debug.Log ("Enemy hit");
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
