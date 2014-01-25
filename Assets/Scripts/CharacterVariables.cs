using UnityEngine;
using System.Collections;

public class CharacterVariables : MonoBehaviour {

	// Fill it out with reasonable defaults
	public int team   = 1;

	public int hp     = 10;
	public int maxHp  = 10;
	public int score  = 0;

	public int   attackDamage = 1;
	public float attackRadius = 1.0f;
	public float attackArc    = 25f;
	public float attackSpeed  = 1f;

	public float moveSpeed    = 1f;

	public bool  isAttacking  = 0;
		
	// Use this for initialization
	void Start () {
		isAttacking = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(hp < 0) {
			DeathRattle();
		}
	}

	void DeathRattle() {
		DestroyObject(gameObject);
		// We will want to do animations, sounds, and respawn here
	}
}
