using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : DynamicObject {

	public float speed;             //Floating point variable to store the player's movement speed.
	public float jumpForce;
	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private Collider2D Collider;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		Collider = GetComponent<Collider2D> ();
	}

	// Update is called once per frame
	void Update () {
		// check for overlap collision with other base class game object
	}
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.

		int jump = 0;

		if (Input.GetKey(KeyCode.Space)) {
			GameObject floor = GameObject.FindGameObjectsWithTag ("Floor").GetComp;
			Debug.Log (floor);
		//	if (Collider.IsTouching (floor.GetComponent<Collider2D>())) {
				jump = 1;
			//}

		}
		if(Input.GetKey(KeyCode.A)){

		}
		if(Input.GetKey(KeyCode.D)){

		}

		//Store the current vertical input in the float moveVertical.


		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (0, jump*jumpForce);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement * speed);

	}


}


