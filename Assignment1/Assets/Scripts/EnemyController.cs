using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	private Transform spawnPoint;
	public float speed = -1;
	private Camera myCam;
	// Use this for initialization
	void Start () {
		myCam = Camera.main;
		rigidbody2D.velocity = new Vector2 (speed, 0);
		spawnPoint = GameObject.Find ("SpawnPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnBecameInvisible()
	{
		if (myCam == null)
			return;

		float yMax = Camera.main.orthographicSize - 0.5f;
		transform.position = new Vector3( spawnPoint.position.x, Random.Range(-yMax, yMax), transform.position.z );
	
	}
}
