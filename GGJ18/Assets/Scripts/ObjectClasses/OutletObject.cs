using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutletObject : HackableObject {

	/* Object methods:
	 * - responding to dynamic object interaction with a given function
	 * - collision interactions (basic) -- transport user from one location to another on level
	 * - input value from user when the player object is colliding with the outlet or door
	 * - node connections between outlets and doors of a level
	*/



	// Use this for initialization
	void Start () {
		//		GameObject player = GameObject.FindGameObjectWithTag ("Player");

	}

	// Update is called once per frame
	void Update () {
		// check for collision with player
		//		OnCollisionEnter2D(collider);
	}

	//	void OnCollisionEnter2D(Collision2D coll) {
	//		if (coll.gameObject.tag == "Player")
	//			coll.gameObject.SendMessage("Transmit", "ActOnOutlet");
	//
	//	}

	void AllowAction(string message,GameObject player) {
		if (message == "Transmit" && Input.GetKey (KeyCode.LeftShift)) {
			Debug.Log ("Transmitting...");
			player.GetComponent<Transform> ().localPosition = new Vector3(3,5,0);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		//		Debug.Log ("Object Entered the trigger");
	}

	void OnTriggerStay2D(Collider2D coll) {
		//		Debug.Log ("Object is within the trigger");
		if(coll.gameObject.tag == "Player")
			AllowAction ("Transmit",GameObject.FindGameObjectWithTag("Player"));
	}

	void OnTriggerExit2D(Collider2D coll) {
		Debug.Log ("Object Exited the trigger");
	}
}
