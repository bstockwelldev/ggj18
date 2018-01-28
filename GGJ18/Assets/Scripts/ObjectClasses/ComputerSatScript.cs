using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSatScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D coll) {
		//		Debug.Log ("Object is within the trigger");
		if(coll.gameObject.tag == "Player") {
			GameObject Player = GameObject.FindGameObjectWithTag("Player");
			Player.GetComponent<SpriteRenderer> ().enabled = false;


			GameObject Satelite = GameObject.FindGameObjectWithTag ("Satelite");

			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(Satelite.transform.position.x,transform.position.y, -1f), 10f);

		}
	}
}
