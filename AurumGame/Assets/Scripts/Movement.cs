using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

	//public static Movement MT;

	private Rigidbody2D rb;

	public float maxSpeed;

	public float betterSpeed;

	public bool isEntered;

	public GameObject Camera;

	// Use this for initialization
	void Start ()
	{

		rb = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		//if (!isEntered) {

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (0, maxSpeed * Time.deltaTime, 0);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (0, -maxSpeed * Time.deltaTime, 0);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-maxSpeed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (maxSpeed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			maxSpeed = maxSpeed * 1.5f;
			Debug.Log ("True");
		}

		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			maxSpeed = maxSpeed / 1.5f;
			Debug.Log ("UP");
		}

		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			maxSpeed = maxSpeed * .4f;
			Debug.Log ("True");
		}

		if (Input.GetKeyUp (KeyCode.LeftControl)) {
			maxSpeed = maxSpeed / .4f;
			Debug.Log ("UP");
		}

		if (isEntered) {
			if (Input.GetKeyDown (KeyCode.X)) {

				maxSpeed = 0;

				this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;

				this.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			}
			if (Input.GetKeyUp (KeyCode.X)) {

				maxSpeed = 30;

				this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;

				this.gameObject.GetComponent<CircleCollider2D> ().enabled = true;

				isEntered = false;
			}
		}
		/*if (Input.GetKey (KeyCode.A) && textIsHere) {
			Destroy (gameObject.tag("Text")); 
			textIsHere = false;
		}*/
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Level") { 
			rb.velocity = Vector3.zero;
		}

		if (other.gameObject.tag == "Hideable") { 
			rb.velocity = Vector3.zero;
		}

		if (other.gameObject.tag == "Door") { 
			rb.velocity = Vector3.zero;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "Hideable") {
			isEntered = true;
		}

		if (other.gameObject.tag == "Door") {
			other.gameObject.GetComponent<Door> ().readyToOpen = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Door") {
			other.gameObject.GetComponent<Door> ().readyToOpen = false;
		}
	}

}
