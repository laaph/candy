using UnityEngine;
using System.Collections;

public class MoveToPoint : MonoBehaviour {

	private SteeringAgentComponent _steerScript;
	private NavigationAgentComponent _navScript;
	public float MoveSpeed;
	public GameObject MoveTarget;

	void Awake(){
		_steerScript = this.GetComponent<SteeringAgentComponent>();
		_navScript = this.GetComponent<NavigationAgentComponent>();
		MoveTarget = GameObject.FindGameObjectWithTag("InitialMoveTarget");
	}

	void Start () {
		_steerScript.m_maxSpeed = MoveSpeed;
		_navScript.MoveToGameObject(MoveTarget, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
