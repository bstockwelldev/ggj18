using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackableObject : StaticObject {

	/* Object methods:
	 * - responding to dynamic object interaction with a given function
	 * - collision interactions (basic) -- generic interaction input from user in UI
	*/

	public string hackMessage;
	public string hackDestination;
	public Sprite responseSprite;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D coll) {
		//		Debug.Log ("Object is within the trigger");
		if(coll.gameObject.tag == "Player") {
			GameObject actions = GameObject.FindGameObjectWithTag("Actions");
			ActionController actionController = actions.GetComponent<ActionController>();
			actionController.message = hackMessage;
			actionController.targetTag = hackDestination;
			actionController.newSprite = responseSprite;
		}
	}


}
