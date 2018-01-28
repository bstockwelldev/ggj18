﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {

	/* Controller methods:
	 * - monitor and check game state based on user input and check on a given frame frequency
	 * - Lose State: run into danger obstacle, receive lose condition from action controller and restart game
	 * - Ongoing State: Nothing occurs, checks for action controller input
	 * - Win State: reach end of level point, receive win condition from action controller
	*/

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.Escape)) {
			RestartGame ();
		}
	}

	void RestartGame() {
		GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = new Vector3(-0.92f,1.09f,0f);
	}
}
