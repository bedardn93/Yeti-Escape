using UnityEngine;
using System.Collections;

public class clamp : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(target.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
	}

		     
}
