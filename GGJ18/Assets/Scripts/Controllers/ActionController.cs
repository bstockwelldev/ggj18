using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {

	public string message;
	public string targetTag;

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
			AllowAction (message, GameObject.FindGameObjectWithTag ("Player"),targetTag);
	}

	void AllowAction(string currentMsg,GameObject player, string currentTargetTag) {
		if(Input.GetKey (KeyCode.LeftShift)) {
			if (currentMsg == "Transmit") {
				Debug.Log ("Transmitting...");
				player.GetComponent<Transform> ().position = new Vector3 (
					GameObject.FindGameObjectWithTag(currentTargetTag).GetComponent<Transform>().position.x,
					GameObject.FindGameObjectWithTag(currentTargetTag).GetComponent<Transform>().position.y,
					GameObject.FindGameObjectWithTag(currentTargetTag).GetComponent<Transform>().position.z
				);

			} else if (message == "Open Door") {
				Debug.Log ("Opening door to next room...");
				player.GetComponent<Transform> ().position = new Vector3 (
					GameObject.FindGameObjectWithTag(currentTargetTag).GetComponent<Transform>().position.x,
					GameObject.FindGameObjectWithTag(currentTargetTag).GetComponent<Transform>().position.y,
					GameObject.FindGameObjectWithTag(currentTargetTag).GetComponent<Transform>().position.z
				);
			}
		}

		message = "";
		targetTag = "";
	}
}
