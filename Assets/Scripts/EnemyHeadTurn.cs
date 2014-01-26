using UnityEngine;
using System.Collections;

public class EnemyHeadTurn : MonoBehaviour {
	SteeringAgentComponent steerScript;
	public SpriteRenderer   mySprite;
	public Sprite[]         sprites;
	// Use this for initialization
	void Start () {
		steerScript = gameObject.GetComponent<SteeringAgentComponent>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 velocity = steerScript.velocity;

		float   angle = Mathf.Atan2 (velocity.z, velocity.x) * (180f/Mathf.PI);  // Degrees will be easier to mentally handle

		// Debug.Logging this might be a very bad idea.
		// Debug.Log (angle);
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
		

	}
}
