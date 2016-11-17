using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Patrol pathToFollow;
	public int currentWayPointID = 0;
	public float speed;
	public float rotationSpeed = 5.0f;
	public string pathName;

	private float reachDistance = 1.0f;
	private GameManager GM;
	Vector3 last_position;
	Vector3 current_position;

	// Use this for initialization
	void Start () {

		//pathToFollow = GameObject.Find (pathName).GetComponent<Patrol> ();
		last_position = transform.position;
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance (pathToFollow.path_objs [currentWayPointID].position, transform.position);
		transform.position = Vector3.MoveTowards (transform.position, pathToFollow.path_objs [currentWayPointID].position, Time.deltaTime * speed);

		if (distance <= reachDistance) {
			currentWayPointID++;
		}

		if (currentWayPointID >= pathToFollow.path_objs.Count) {
			currentWayPointID = 0;
		}
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "Door") {
			
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Door") {
			//other.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			other.gameObject.SetActive(true);
		}
	}
}
