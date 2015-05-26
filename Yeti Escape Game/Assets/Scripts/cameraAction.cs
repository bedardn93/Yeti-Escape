using UnityEngine;
using System.Collections;

public class cameraAction : MonoBehaviour {

	public Transform target;
	public float verticalSpeed = 10.0f;
	public float maxY = 50f;
	public float minY = -50.0f;

	private Vector3 v3Rotate;
	
	// Use this for initialization
	void Start () {
		transform.localEulerAngles = v3Rotate;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Vertical Look Rotation
		vLook ();
	}

	/*
	 * Name: Vertical Look
	 * Purpose: Used to transform the camera vertical rotation/ X rotation
	 * Arguments: None
	 * Author: Ridgely
	 */
	void vLook()
	{
		//Defaults to inverted mouse, this makes it normal
		v3Rotate.x += Input.GetAxis ("Mouse Y") * verticalSpeed * -1f;

		//This sets the limits of vertical look
		v3Rotate.x = Mathf.Clamp (v3Rotate.x, minY, maxY);

		//Transforms the camera up and down using Euler angles
		transform.localEulerAngles = v3Rotate;
	}

}
