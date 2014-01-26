using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	// key for pickup words
	// "points"
	// "rapidfire"
	// "damage"
	// "speed"
	public string powerupType = "points";
	public int team = 1;

	// Use this for initialization
	void Start () {

		// pickup disappears after X seconds
		// disabled for easier debug
		//Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// not working
	void OnTriggerEnter(Collider collider) {

		Debug.Log("powerup collided");
	}

	public void Spawn () {
		gameObject.SetActive(true);
	}
}
