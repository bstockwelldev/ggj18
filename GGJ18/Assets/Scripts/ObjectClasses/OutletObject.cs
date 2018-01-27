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

//	Collision2D collider;

	// Use this for initialization
	void Start () {
		
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

	void AllowAction(string message) {
//		if (message == "Transmit" && )
			
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Object Entered the trigger");
		AllowAction ("Transmit");
	}

	void OnTriggerStay2D(Collider2D other) {
		Debug.Log ("Object is within the trigger");
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Object Exited the trigger");
	}
}
