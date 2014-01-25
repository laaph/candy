using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform followTarget;
	Vector3 startLocation;
	// Use this for initialization
	void Start () {
		startLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate() {
		transform.position = followTarget.position + startLocation;
	}
}
