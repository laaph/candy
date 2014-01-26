using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float  movementSpeed;
	string playerNum;
	Vector3 oldPosition;
	public Sprite[]  sprites;

	public SpriteRenderer mySprite;

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

	void FixedUpdate() {

		if(charScript.isAttacking) {
			// We can't move if we are attacking
			return;
		}

		float   x =  Input.GetAxis(moveHoriz) * movementSpeed;
		float   y =  0; // For consistency
		float   z =  Input.GetAxis(moveVert)  * movementSpeed;

		if(Mathf.Sqrt(x  * x + z * z) < 0.5f) {
			return;
		} 
		
		float   angle = Mathf.Atan2 (z, x) * (180f/Mathf.PI);  // Degrees will be easier to mentally handle

		// The following could be done with a lot of math rather than these if/then checks.
		float chunksize = 360/8;
		int index = 0;
		if(angle > -chunksize/2 && angle < chunksize / 2) {
			index = 0;
		}
		if(angle > 0.5 * chunksize && angle < 1.5 * chunksize) {
			index = 1;
		}
		if(angle > 1.5 * chunksize && angle < 2.5 * chunksize) {
			index = 2;
		}
		if((angle > 2.5 * chunksize) && (angle < 3.5 * chunksize)) {
			index = 3;
		}
		if((angle > 3.5 * chunksize) || (angle < -3.5 * chunksize)) {
			index = 4;
		}
		if(angle > -3.5 * chunksize && angle < -2.5 * chunksize) {
			index = 5;
		}
		if(angle > -2.5 * chunksize && angle < -1.5 * chunksize) {
			index = 6;
		}
		if(angle > -1.5 * chunksize && angle < -0.5 * chunksize) {
			index = 7;
		}
		mySprite.GetComponent<SpriteRenderer>().sprite = sprites[index];

		
		rigidbody.AddForce(x, y, z);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
