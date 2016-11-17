using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool playerDeath;

	// Use this for initialization
	void Start () {


		playerDeath = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (playerDeath == true) {
			//SceneManager.LoadScene (0);
		}
	
	}
}
