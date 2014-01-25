using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float  movementSpeed = 0.1f;
	public string playerNum = "1";
	Vector3 oldPosition;

	string moveHoriz;
	string moveVert;
	// Use this for initialization
	void Start () {


	}

	void FixedUpdate() {
		moveHoriz = "Player" + playerNum + "MoveHoriz";
		moveVert  = "Player" + playerNum + "MoveVert";
		
		
		//oldPosition = transform.position;
		float   x =  Input.GetAxis(moveHoriz) * movementSpeed;
		float   y =  0; // For consistency
		float   z =  Input.GetAxis(moveVert)  * movementSpeed;
		rigidbody.AddForce(x, y, z);
	}
	
	// Update is called once per frame
	void Update () {

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
	}

//	void OnCollisionEnter(Collision c) {
//		 Debug.Log("Collision info " + c.contacts[0].point);
//		if(c.gameObject.tag == "Wall") {
//			transform.position = oldPosition;
//		}
//	}
}
