using UnityEngine;
using System.Collections;


/* PURPOSES: 
 * A) Sets the points for the yeti to travel to
 * B) Changes speed depending on if wandering or chasing */
public class YetiAI : MonoBehaviour {
	
	NavMeshAgent agent;
	public GameObject currentTarget;
	public GameObject[] targets;
	
	public int maxWayPoints = 4;
	public int minWayPoints = 0;
	
	public float speedWander = 100.0f;
	public float speedRun = 30.0f;
	
	public bool chasingPlayer = false;
	
	void Awake ()
	{
		maxWayPoints = 4;
		//Locate WayPoints, store them into targets array 
		targets = new GameObject[5];
		//FOR LOOP STOPPED WORKING??
		for (int i = 0; i < maxWayPoints + 1; i++) {
			targets [i] = GameObject.Find ("Waypoint_" + i);
		}


	}
		

	void Start () {

		speedWander = 20.0f;
		agent = GetComponent<NavMeshAgent> ();
		setSpeed (speedWander);
		currentTarget = targets[Random.Range(minWayPoints,maxWayPoints)];
	}

	void Update () {	
		//Checks to see if yeti is traversing a path
		//If there is no new path, a new random target is set
		agent.SetDestination (currentTarget.transform.position);

		if(reachedDestination())
			currentTarget = targets[Random.Range(minWayPoints,maxWayPoints)];
		
	}
	
	//The Colliders will be the Yeti's field of view
	
	//An Object's enters yetis field of view
	void OnTriggerEnter(Collider other)
	{
		//If player is found, chase after the player
		if (other.transform.tag == "Player"){
			currentTarget = other.gameObject;
			setSpeed (speedRun);
		}
	}
	
	//Return to wander speed if player is out of sight i.e. leaves collider
	void OnTriggerExit(Collider other)
	{
		if (other.transform.tag == "Player")
			//Continues patroling if lost sight of player
			currentTarget = targets[Random.Range(minWayPoints,maxWayPoints)];
			setSpeed (speedWander);
	}
	
	//Sets the speed depending on condition of the yeti
	void setSpeed(float currentSpeed)
	{
		agent.speed = currentSpeed;
	}

	bool reachedDestination()
	{
		//Credit: Tryz
		// Check if we've reached the destination
		if (Vector3.Distance (transform.position, agent.destination) <= 7f) {
			Debug.Log ("Reached it");
			return true;
		} else {
			return false;
		}
	}
}


