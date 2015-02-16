using UnityEngine;
using System.Collections;

public class WallSensors : MonoBehaviour {

	public float senseRange;
	public RaycastHit[] sensors = new RaycastHit[3];
	public float[] distanceToWall = new float[3];

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Reset wall distances. They are set to a value far beyond the senseRange as such a value is not possible unless there are no
		//	walls within range.
		distanceToWall [0] = senseRange+10;
		distanceToWall [1] = senseRange+10;
		distanceToWall [2] = senseRange+10;

		//Check if the sensors have hit anything
			//NOTE: For the vector additions made, normalizing is not necessary as we are only using the sums for their  directions.

		if(Physics.Raycast(transform.position, Vector3(-transform.right + transform.forward), out sensors[0], senseRange) ){
			if(sensors[0].collider.CompareTag("Wall"))
				distanceToWall[0] = sensors[0].distance;
		}
		if(Physics.Raycast(transform.position, transform.forward, out sensors[1], senseRange) ){
			if(sensors[0].collider.CompareTag("Wall"))
				distanceToWall[1] = sensors[1].distance;
		}
		if(Physics.Raycast(transform.position, Vector3(transform.right + transform.forward), out sensors[2], senseRange) ){
			if(sensors[0].collider.CompareTag("Wall"))
				distanceToWall[2] = sensors[2].distance;
		}
	}


}
