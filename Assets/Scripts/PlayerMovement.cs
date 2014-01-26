using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float  movementSpeed;
	string playerNum;
	Vector3 oldPosition;
	public Sprite[]  sprites;

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
		float chunksize = 360/8; // 
		if(angle > -chunksize/2 && angle < chunksize / 2) {
			GetComponent<SpriteRenderer>().sprite = sprites[0];
		}
		if(angle > 0.5 * chunksize && angle < 1.5 * chunksize) {
			GetComponent<SpriteRenderer>().sprite = sprites[1];
		}
		if(angle > 1.5 * chunksize && angle < 2.5 * chunksize) {
			GetComponent<SpriteRenderer>().sprite = sprites[2];
		}
		if((angle > 2.5 * chunksize) && (angle < 3.5 * chunksize)) {
			GetComponent<SpriteRenderer>().sprite = sprites[3];
		}
		if((angle > 3.5 * chunksize) || (angle < -3.5 * chunksize)) {
			GetComponent<SpriteRenderer>().sprite = sprites[4];
		}
		if(angle > -3.5 * chunksize && angle < -2.5 * chunksize) {
			GetComponent<SpriteRenderer>().sprite = sprites[5];
		}
		if(angle > -2.5 * chunksize && angle < -1.5 * chunksize) {
			GetComponent<SpriteRenderer>().sprite = sprites[6];
		}
		if(angle > -1.5 * chunksize && angle < -0.5 * chunksize) {
			GetComponent<SpriteRenderer>().sprite = sprites[7];
		}
		
		rigidbody.AddForce(x, y, z);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
