using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 0.1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float   x =  Input.GetAxis("Player1MoveHoriz") * movementSpeed;
		float   y =  0; // For consistency
		float   z =  Input.GetAxis("Player1MoveVert")  * movementSpeed;

		//Debug.Log("x = " + x + " y = " + y);

		Vector3 p = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
		transform.position = p;
	}
}
