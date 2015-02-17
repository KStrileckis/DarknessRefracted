using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdjAgentSensor : MonoBehaviour {

	Vector3 heading;
	Transform subjectTransform;
	Transform agentTransform;
	//bool[] inRange = new bool[10];
	//int agentCount = 0;
	public List<Transform> agentList= new List<Transform>();
	// Use this for initialization
	void Start () {
		subjectTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		//int i = 0;
		/*foreach (bool agentPresent in inRange)
		{
			if (agentPresent) {
				Debug.Log ("Agent " + i + " Inside Collider");
				// Gets a vector that points from the player's position to the target's.
				heading = agentTransform[i].position - subjectTransform.position;
				Debug.Log ("Heading is " + heading);
			}
			i++;
		}*/
		foreach (Transform agent in agentList) {

			heading = agent.position - subjectTransform.position;

			//use heading and forward of the subject
			Vector3 front = subjectTransform.right;
			float angle = Vector3.Angle(heading, front);
			Debug.Log ("Target name: " + agent.name  + ". Distance: " + heading.magnitude + ". Heading: " + heading + ". Angle: " + angle);
			//Debug.Log ("Angle: " + angle);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.CompareTag("Agent")){
			agentList.Add (other.transform);
		}
		/*if(other.CompareTag("Agent")) {
			//inRange = true;

			inRange [agentCount] = true;
			agentTransform[agentCount] = other.transform;
			agentCount++;
			Update ();
		}*/
	}

	void OnTriggerExit2D(Collider2D other) {

		/*if(other.CompareTag("Agent")) {
			//inRange = false;
			inRange [agentCount] = false;
			Update ();			
		}*/
		//agentCount--;
		//agentList.Remove (other.transform.parent.gameObject);
			if(other.CompareTag("Agent")){
				agentList.Remove (other.transform);
			}
	}

	void OnTriggerStay2D(Collider2D other) {

		//transform.positionother.transform.parent.transform.position;
		//agentTransform  = other.transform;
		//Debug.Log ("Agent " + i + " Inside Collider");
		// Gets a vector that points from the player's position to the target's.
		//heading = agentTransform.position - subjectTransform.position;
		//Debug.Log ("Heading is " + heading);
	}
}
