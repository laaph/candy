using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float  movementSpeed;
	string playerNum;
	Vector3 oldPosition;

	string moveHoriz;
	string moveVert;

	CharacterVariables charScript;
	// Use this for initialization
	void Start () {
		charScript = gameObject.GetComponent<CharacterVariables>();
		playerNum  = charScript.team.ToString();
		movementSpeed = charScript.moveSpeed;

		moveHoriz = "Player" + playerNum + "MoveHoriz";
		moveVert  = "Player" + playerNum + "MoveVert";
	}

<<<<<<< HEAD
		if(charScript.isAttacking) {
			// We can't move if we are attacking
			return;
		}

		oldPosition = transform.position;
		float   x =  Input.GetAxis(moveHoriz) * movementSpeed;
		float   y =  0; // For consistency
		float   z =  Input.GetAxis(moveVert)  * movementSpeed;
	
		Vector3 p = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
		transform.position = p;
=======
	void FixedUpdate() {
		moveHoriz = "Player" + playerNum + "MoveHoriz";
		moveVert  = "Player" + playerNum + "MoveVert";
		
		
		//oldPosition = transform.position;
		float   x =  Input.GetAxis(moveHoriz) * movementSpeed;
		float   y =  0; // For consistency
		float   z =  Input.GetAxis(moveVert)  * movementSpeed;
		rigidbody.AddForce(x, y, z);
>>>>>>> d5f42c0ac4d48eb4e0b5983e77d237dd6b62f6d8
	}
	
	// Update is called once per frame
	void Update () {

<<<<<<< HEAD
	void OnCollisionEnter2D(Collision2D c) {
		if(c.gameObject.tag == "Wall") {
			transform.position = oldPosition;
		}
=======
//		// Temporarily put here so that live updating works - meant to be in Start()
//		moveHoriz = "Player" + playerNum + "MoveHoriz";
//		moveVert  = "Player" + playerNum + "MoveVert";
//
//
//		oldPosition = transform.position;
//		float   x =  Input.GetAxis(moveHoriz) * movementSpeed;
//		float   y =  0; // For consistency
//		float   z =  Input.GetAxis(moveVert)  * movementSpeed;
//
//		// Debug.Log("x = " + x + " y = " + y);
//
//		Vector3 p = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
//		transform.position = p;
>>>>>>> d5f42c0ac4d48eb4e0b5983e77d237dd6b62f6d8
	}

//	void OnCollisionEnter(Collision c) {
//		 Debug.Log("Collision info " + c.contacts[0].point);
//		if(c.gameObject.tag == "Wall") {
//			transform.position = oldPosition;
//		}
//	}
}
