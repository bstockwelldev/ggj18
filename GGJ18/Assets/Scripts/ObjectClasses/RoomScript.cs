using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Collision2D Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D>();


	}

	void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			Collider2D self = GetComponent<Collider2D> ();
			Camera.main.pixelRect = GetComponent<RectTransform> ().rect;
	

		}
	}

	void OnTriggerStay2D(Collider2D coll) {
		
	}

	void OnTriggerExit2D(Collider2D coll) {


		if (coll.gameObject.tag == "Player") {
			
		}
	}


		
}
