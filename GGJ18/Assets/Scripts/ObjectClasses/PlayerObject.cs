using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : DynamicObject {

	public float speed;             //Floating point variable to store the player's movement speed.
	public float MaxSpeed;
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
		////////////////////////////
		/// Handles Movements
		////////////////////////////
		int jump = 0;
		//GetAll floors

		GameObject[] floors = GameObject.FindGameObjectsWithTag ("Floor");
		bool IsTouchingFloor = false;
		foreach(GameObject item in floors)
		{
			//Collider.IsTouching (floor)
			IsTouchingFloor = Collider.GetComponent<Collider2D>().IsTouching(item.GetComponent<Collider2D>());
			if (IsTouchingFloor)
				break;
		}


		if (Input.GetKey(KeyCode.Space)) {


			Debug.Log ("tryjump");
			if (IsTouchingFloor) {
				jump = 1;
				Debug.Log ("jump");
			}

		}
		Vector2 WalkVector = new Vector2(0,0);
		rb2d.GetVector(WalkVector);
		double CurrentSpeed = WalkVector.x;
		//Debug.Log (CurrentSpeed);


		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			double moveScale = 1.0;
			if (!IsTouchingFloor && CurrentSpeed < 0) {
				moveScale = 0.25;
			}
			CurrentSpeed -= 2*moveScale;
			if (CurrentSpeed < -MaxSpeed) {
				CurrentSpeed = 0;
			}
		
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			double moveScale = 1.0;
			if (!IsTouchingFloor && CurrentSpeed > 0) {
				moveScale = 0.25;
			}
			CurrentSpeed += 2*moveScale;
			if (CurrentSpeed > MaxSpeed) {
				CurrentSpeed = 0;
			}
		}

		//Store the current vertical input in the float moveVertical.
		WalkVector.x +=(float)CurrentSpeed;

		//Use the two store floats to create a new Vector2 variable movement.

		
		Vector2 JumpVect = new Vector2 (0, jump);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (JumpVect*jumpForce); // jump
		rb2d.AddForce (WalkVector*speed);//Walk

		if(Input.GetKey(KeyCode.LeftShift)){
			
			Debug.Log("OMGHAX!!!");
			rb2d.transform.position.Set(10f,10f,0);
	
		}

	}
}