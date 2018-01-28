using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraLOSScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D coll) {
				
		if(coll.gameObject.tag == "Player") {
			Debug.Log ("Restart");
			GameObject restarter = GameObject.FindGameObjectWithTag ("GameController");
			GameStateController next = restarter.GetComponent<GameStateController> ();
			next.RestartGame ();

		}
	}
}
