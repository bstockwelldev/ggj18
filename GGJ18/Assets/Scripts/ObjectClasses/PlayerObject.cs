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
	bool ColliderFromBottom(Collision2D collision){

		Collider2D collider = collision.collider;
		bool collideFromLeft;
		bool collideFromTop;
		bool collideFromRight;
		bool collideFromBottom = false;
		float RectWidth = this.GetComponent<Collider2D> ().bounds.size.x;
		float RectHeight = this.GetComponent<Collider2D> ().bounds.size.y;
		float circleRad = collider.bounds.size.x;

		if(collider.name == "Floor")
		{ 
			Vector3 contactPoint = collision.contacts[0].point;
			Vector3 center = collider.bounds.center;

			if (contactPoint.y > center.y && //checks that circle is on top of rectangle
				(contactPoint.x < center.x + RectWidth / 2 && contactPoint.x > center.x - RectWidth / 2)) {
				collideFromTop = true;
			}
			else if (contactPoint.y < center.y &&
				(contactPoint.x < center.x + RectWidth / 2 && contactPoint.x > center.x - RectWidth / 2)) {
				collideFromBottom = true;
			}
			else if (contactPoint.x > center.x &&
				(contactPoint.y < center.y + RectHeight / 2 && contactPoint.y > center.y - RectHeight / 2)) {
				collideFromRight = true;
			}
			else if (contactPoint.x < center.x &&
				(contactPoint.y < center.y + RectHeight / 2 && contactPoint.y > center.y - RectHeight / 2)) {
				collideFromLeft = true;
			}
		}
		return collideFromBottom;
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



			if (IsTouchingFloor) {
				jump = 1;

			}

		}
		Vector2 WalkVector = new Vector2(0,0);
		rb2d.GetVector(WalkVector);
		double CurrentSpeed = WalkVector.x;



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
			

			rb2d.transform.position.Set(10f,10f,0);
	
		}

	}
				
}