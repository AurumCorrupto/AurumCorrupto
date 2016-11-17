using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	public float resetDoor;
	public bool readyToOpen;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (readyToOpen && Input.GetKey (KeyCode.A)) {
			Open ();
		}


		if (resetDoor > 0) {
			resetDoor--;
		}

		if (resetDoor <= 0) {
			Close ();
		}
	}

	public void Open(){
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		resetDoor = 100;
		readyToOpen = false;
	}

	void Close(){
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		this.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		resetDoor = 0;
	}
}
