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
	
	// Update is called once per frame
	void Update () {

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
	}

	void OnCollisionEnter2D(Collision2D c) {
		if(c.gameObject.tag == "Wall") {
			transform.position = oldPosition;
		}
	}
}
