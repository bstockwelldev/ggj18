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
			Debug.Log ("enteredRoom");




			Camera.main.transform.localScale = transform.localScale;

			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(transform.position.x,transform.position.y, -1f), 10f);
			

		}
	}

	void OnTriggerStay2D(Collider2D coll) {

	}

	void OnTriggerExit2D(Collider2D coll) {

	
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("leftroom");
		}
	}


		
}
