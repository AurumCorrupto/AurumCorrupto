using UnityEngine;
using System.Collections;

public class TextSpawn : MonoBehaviour {

	public GameObject Text;

	public bool textTime;

	public GameObject Camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A) && textTime == true){
			Instantiate (Text, new Vector3 (Camera.transform.position.x, Camera.transform.position.y - 10, 0), Quaternion.identity);
			textTime = false;
			Debug.Log ("Firing");
		}

		if (Input.GetKeyUp (KeyCode.A) && textTime == false) {
			Destroy(GameObject.FindWithTag("Text"));
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			textTime = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			textTime = false;
		}
	}
}
