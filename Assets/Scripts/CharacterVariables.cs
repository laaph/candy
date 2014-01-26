using UnityEngine;
using System.Collections;

public class CharacterVariables : MonoBehaviour {

	// Fill it out with reasonable defaults
	public int team   = 1;

	public int hp     = 9;
	public int maxHp  = 9;
	public int score  = 0;

	public int   attackDamage   = 1;
	public float attackRadius   = 1.0f;
	public float attackArc      = 40f;
	public float attackSpeed    = 200f;
	public float attackCooldown = 0.5f;

	public bool  isAttacking    = false;
	
	public float moveSpeed      = 1f;
	private GameMaster _gmScript;
			
	// Use this for initialization
	void Start () {
		isAttacking = false;
		_gmScript = GameObject.Find("GameMaster").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
		if(hp <= 0) {
			DeathRattle();
		}
	}

	void DeathRattle() {
		_gmScript.PlayPlayerDeath();
		DestroyObject(gameObject);
	}
}
