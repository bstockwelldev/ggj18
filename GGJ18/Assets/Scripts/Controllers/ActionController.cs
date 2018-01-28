﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {

	public string message;
	public string targetTag;
	public Sprite newSprite;

	/* Controller methods:
	 * - Checks conditions every frame for win or lose, communicates state when triggered to GameStateController
	 * - Tracks PlayerObject throughout level every frame for change in conditions: interacting with a HackableObject
	*/

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (message != "" && targetTag != "")
			AllowAction (message, GameObject.FindGameObjectWithTag ("Player"),targetTag,newSprite);
	}

	void AllowAction(string currentMsg,GameObject player, string currentTargetTag,Sprite nextSprite) {
		if(Input.GetKey (KeyCode.LeftShift)) {
			GameObject actingObject = GameObject.FindGameObjectWithTag (currentTargetTag);
			if (currentMsg == "Transmit") {
//				Debug.Log ("Transmitting...");
				player.GetComponent<Transform> ().position = new Vector3 (
					actingObject.GetComponent<Transform>().position.x,
					actingObject.GetComponent<Transform>().position.y,
					actingObject.GetComponent<Transform>().position.z
				);

			} else if (message == "Open Door") {
//				Debug.Log ("Opening door to next room...");
				player.GetComponent<Transform> ().position = new Vector3 (
					actingObject.GetComponent<Transform>().position.x,
					actingObject.GetComponent<Transform>().position.y,
					actingObject.GetComponent<Transform>().position.z
				);
			} else if (message == "Lights Off") {
				Debug.Log ("Who turned out the lights?!");
				actingObject.GetComponent<SpriteRenderer>().sprite = nextSprite;
				actingObject.GetComponent<Animator> ().enabled = false;
			}
		}

		message = "";
		targetTag = "";
		newSprite = null;
	}
}
