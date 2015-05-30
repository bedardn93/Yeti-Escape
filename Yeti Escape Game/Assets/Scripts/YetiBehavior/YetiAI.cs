using UnityEngine;
using System.Collections;

/* PURPOSES: 
 * A) Sets the points for the yeti to travel to
 * B) Changes speed depending on if wandering or chasing */
public class YetiAI : MonoBehaviour {

	NavMeshAgent agent;
	public GameObject currentTarget;
	public GameObject[] targets;

	public int maxWayPoints = 3;
	public int minWayPoints = 0;

	public float speedWander = 3.5f;
	public float speedRun = 5.0f;

	public bool chasingPlayer = false;

	void Awake ()
	{
		//Locate WayPoints, store them into targets array
		targets = new GameObject[11];
		for(int i = 0; i < maxWayPoints; i++)
			targets[i] = GameObject.Find("WayPoints_"+i);
		
	}

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Checks if chasing, changes speed accordingly
		if (chasingPlayer)
			setSpeed (speedRun);
		else
			setSpeed (speedWander);

		//Checks to see if yeti is traversing a path
		//If there is no new path, a new random target is set
		if(!agent.pathPending)
			currentTarget = targets[Random.Range(minWayPoints,maxWayPoints)];
		//Otherwise it continues on the path it is on
		else
			agent.SetDestination (currentTarget.transform.position);
	
	}

	//The Colliders will be the Yeti's field of view

	//An Object's enters yetis field of view
	void OnTriggerEnter(Collider other)
	{
		//If player is found, chase after the player
		if (other.transform.tag == "Player"){
			currentTarget = other.gameObject;
			chasingPlayer = true; 
		}
	}

	//Return to wander speed if player is out of sight i.e. leaves collider
	void OnTriggerExit(Collider other)
	{
		if (other.transform.tag == "Player")
			chasingPlayer = false;
	}

	//Sets the speed depending on condition of the yeti
	void setSpeed(float currentSpeed)
	{
		agent.speed = currentSpeed;
	}
}
