using UnityEngine;
using System.Collections;

public class CameraController1 : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	void Start () 
	{

		offset = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;
	}
}
