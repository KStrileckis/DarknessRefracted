using UnityEngine;
using System.Collections.Generic;


public class SubjectController : MonoBehaviour {

	[SerializeField]
	public float moveSpeed;
	private Vector3 moveDirection;
	public float turnSpeed;

	public float speed ;
	public float rotationSpeed;
	//transform
	Transform myTrans;
	//object position
	Vector3 myPos;
	//object rotation
	Vector3 myRot;
	//object rotation
	float angle;
	// Use this for initialization
	void Start () {
		myTrans = transform;
		myPos = myTrans.position;
		myRot = myTrans.rotation.eulerAngles;
	}

	// Update is called once per frame
	void Update () {
	
		//converting the object euler angle's magnitude from to Radians
		angle = myTrans.eulerAngles.magnitude * Mathf.Deg2Rad;
		//rotate object Right & Left
		if (Input.GetKey (KeyCode.RightArrow)) {
			myRot.z -= rotationSpeed;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			myRot.z += rotationSpeed;
		}
		//move object Forward & Backward
		if (Input.GetKey (KeyCode.UpArrow)) {
			myPos.x += (Mathf.Cos (angle) * speed) * Time.deltaTime;
			myPos.y += (Mathf.Sin (angle) * speed) * Time.deltaTime;
			//EnforceBounds();
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			myPos.x += (Mathf.Cos (angle)* -speed) * Time.deltaTime;
			myPos.y += (Mathf.Sin (angle)* -speed) * Time.deltaTime;
			//EnforceBounds();
		}
		//Apply
		myTrans.position = myPos;
		myTrans.rotation = Quaternion.Euler (myRot);
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
