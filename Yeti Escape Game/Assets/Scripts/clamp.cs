using UnityEngine;
using System.Collections;

public class clamp : MonoBehaviour {

	public Transform target;
	public bool clampRotX = false;
	public bool clampRotY = false;
	public bool clampRotZ = false;

	public bool clampPosX = false;
	public bool clampPosY = false;
	public bool clampPosZ = false;

	float targetRotX, targetRotY, targetRotZ;
	float targetPosX, targetPosY, targetPosZ;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if (clampRotX == true)
			targetRotX = target.eulerAngles.x;
		else
			targetRotX = transform.eulerAngles.x;
		if (clampRotY == true)
			targetRotY = target.eulerAngles.y;
		else
			targetRotY = transform.eulerAngles.y;
		if (clampRotZ == true)
			targetRotZ = target.eulerAngles.z;
		else
			targetRotZ = transform.eulerAngles.z;
		if (clampPosX == true)
			targetPosX = target.position.x;
		else
			targetPosX = transform.position.x;
		if (clampPosY == true)
			targetPosY = target.position.y;
		else
			targetPosY = transform.position.y;
		if (clampRotZ == true)
			targetPosZ = target.position.z;
		else
			targetPosZ = transform.position.z;
		transform.eulerAngles = new Vector3(targetRotX, targetRotY, targetRotZ);
		transform.position = new Vector3 (targetPosX, targetPosY, targetPosZ);
	}

		     
}
