using UnityEngine;
using System.Collections.Generic;


public class SubjectController : MonoBehaviour {
	
	public WallSensors wallSense;
	
	[SerializeField]
	public float moveSpeed;
	private Vector3 moveDirection;
	public float turnSpeed;
	
	public float speed ;
	public float rotationSpeed;
	public float[] wallDistances = new float[3];
	
	
	//transform
	Transform subjectTransform;
	//object position
	Vector3 position;
	//object rotation
	Vector3 rotation;
	//object rotation
	float angle;
	// Use this for initialization
	void Start () {
		subjectTransform = transform;
		position = subjectTransform.position;
		rotation = subjectTransform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		wallDistances = wallSense.SenseWalls (transform);
		
		//converting the object euler angle's magnitude from to Radians
		angle = subjectTransform.eulerAngles.magnitude * Mathf.Deg2Rad;
		//rotate object Right & Left
		if (Input.GetKey (KeyCode.RightArrow)) {
			rotation.z -= rotationSpeed;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rotation.z += rotationSpeed;
		}
		//move object Forward & Backward
		if (Input.GetKey (KeyCode.UpArrow)) {
			position.x += (Mathf.Cos (angle) * speed) * Time.deltaTime;
			position.y += (Mathf.Sin (angle) * speed) * Time.deltaTime;
			//EnforceBounds();
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			position.x += (Mathf.Cos (angle)* -speed) * Time.deltaTime;
			position.y += (Mathf.Sin (angle)* -speed) * Time.deltaTime;
			//EnforceBounds();
		}
		//Apply
		subjectTransform.position = position;
		subjectTransform.rotation = Quaternion.Euler (rotation);
		EnforceBounds();
		
	}
	
	private void EnforceBounds()
	{
		
		Vector3 newPosition = transform.position; 
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;
		
		float xDist = mainCamera.aspect * mainCamera.orthographicSize; 
		float xMax = cameraPosition.x + xDist;
		float xMin = cameraPosition.x - xDist;
		float yMax = mainCamera.orthographicSize;
		
		if ( newPosition.x < xMin || newPosition.x > xMax ) {
			newPosition.x = Mathf.Clamp( newPosition.x, xMin, xMax );
			moveDirection.x = -moveDirection.x;
		}
		
		
		if (newPosition.y < -yMax || newPosition.y > yMax) {
			newPosition.y = Mathf.Clamp( newPosition.y, -yMax, yMax );
			moveDirection.y = -moveDirection.y;
		}
		
		transform.position = newPosition;
		
	}
	
}