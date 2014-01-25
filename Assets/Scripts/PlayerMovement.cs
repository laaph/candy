using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 0.1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float   x = Input.GetAxis("Player1MoveHoriz") * movementSpeed;
		float   y = Input.GetAxis("Player1MoveVert")  * movementSpeed;

		Debug.Log("x = " + x + " y = " + y);

		Vector3 p = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
		transform.position = p;

		if(x != 0)
		{
			float   r = 1.5f * Mathf.PI - Mathf.Atan2(10f * y, 10f * -x);
			//transform.eulerAngles = new Vector3(0f, 0f, 360-r*(180/Mathf.PI));
		} else {
			//transform.eulerAngles = new Vector3(0f, 0f, (900f * y) - 90f);
		}
	}
}
