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
	}

	// Update is called once per frame
	void Update () {
		// check for collision with player
	}

	void OnTriggerEnter2D(Collider2D coll) {
		//		Debug.Log ("Object Entered the trigger");
	}

	void OnTriggerStay2D(Collider2D coll) {
		//		Debug.Log ("Object is within the trigger");
		if(coll.gameObject.tag == "Player") {
			GameObject actions = GameObject.FindGameObjectWithTag("Actions");
			ActionController actionController = actions.GetComponent<ActionController>();
			actionController.message = "Transmit";
			actionController.targetTag = "Outlet2";

		}
	}

	void OnTriggerExit2D(Collider2D coll) {
//		Debug.Log ("Object Exited the trigger");
	}


}
