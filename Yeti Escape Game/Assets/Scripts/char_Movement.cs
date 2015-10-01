using UnityEngine;
using System.Collections;

public class char_Movement : MonoBehaviour {
	
	private float moveSpeed;
	public float walkSpeed = 10f;
	public float jogSpeed = 15f;
	public float sprintSpeed = 20f;
	public float rotateSpeed = 30f;

	//Updates every frame after physics simulation 
	void FixedUpdate()
	{
		movement ();
		turn ();
	}	

	/*
	 * Name: Old Move
	 * Purpose: Old movement method, no camera direction
	 * Arguments: None
	 * Author: Ridgely
	 */
	void movement()
	{
		// Take key input
		float moveHorizontal = Input.GetAxis ("Horizontal") * moveSpeed;
		float moveVertical = Input.GetAxis ("Vertical") * moveSpeed;

		if (Input.GetKey (KeyCode.LeftShift)) {
			moveSpeed = sprintSpeed;
		} else if (Input.GetKey (KeyCode.LeftControl)) {
			moveSpeed = walkSpeed;
		} else {
			moveSpeed = jogSpeed;
		}

		// Move Right
		if (moveHorizontal > 0) {
			moveRight (moveHorizontal);
		}

		// Move Left
		if (moveHorizontal < 0) {
			moveLeft (moveHorizontal);
		}

		// Move Forward
		if (moveVertical > 0) {
			moveForward (moveVertical);
		}

		// Move Backward
		if (moveVertical < 0) {
			moveBack (moveVertical);
		}

	}

	/*
	 * Name: Move Forward
	 * Purpose: Moves the object forward based on local orientation
	 * Arguments: Speed of movement in float
	 * Author: Ridgely
	 */
	void moveForward(float speed) {
		transform.localPosition += transform.forward * Mathf.Abs (speed) * Time.deltaTime;
	}

	/*
	 * Name: Move Backward
	 * Purpose: Moves the object backward based on local orientation
	 * Arguments: Speed of movement in float
	 * Author: Ridgely
	 */
	void moveBack(float speed) {
		transform.localPosition -= transform.forward * Mathf.Abs (speed) * Time.deltaTime;
	}

	/*
	 * Name: Move Right
	 * Purpose: Moves the object right based on local orientation
	 * Arguments: Speed of movement in float
	 * Author: Ridgely
	 */
	void moveRight(float speed) {
		transform.localPosition += transform.right * Mathf.Abs (speed) * Time.deltaTime;
	}

	/*
	 * Name: Move Left
	 * Purpose: Moves the object left based on local orientation
	 * Arguments: Speed of movement in float
	 * Author: Ridgely
	 */
	void moveLeft(float speed) {
		transform.localPosition -= transform.right * Mathf.Abs (speed) * Time.deltaTime;
	}

	/*
	 * Name: Turn
	 * Purpose: Rotates the object
	 * Arguments: None
	 * Author: Ridgely
	 */
	void turn()
	{
		float rotHorizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
		transform.Rotate (0, rotHorizontal, 0);
	}
}

