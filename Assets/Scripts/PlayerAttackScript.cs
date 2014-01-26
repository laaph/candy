using UnityEngine;

public class PlayerAttackScript : MonoBehaviour {
    
	public Transform sword;

    CharacterVariables charVars;

	public AudioClip[] swordNoises;

	// The following are set to public so I can watch them in the inspector
	public float cooldown; // keeps track of current cooldown
    
	string horizInputString = "Player1ShootHoriz";    // input strings based on player number
    string vertInputString = "Player1ShootVert";
    
    public float startingAngle; // Where we are attacking from
	public float endingAngle;
	float attackArc;
	public float currentAngle;
	float attackSpeed;
	private GameMaster _gmScript;

    void Start() {
		charVars = gameObject.GetComponent<CharacterVariables>();
		cooldown = charVars.attackCooldown;

		// change input strings based on player variable
		horizInputString = "Player" + charVars.team.ToString() + "ShootHoriz";
		vertInputString  = "Player" + charVars.team.ToString() + "ShootVert";

		attackArc   = charVars.attackArc;
		attackSpeed = charVars.attackSpeed;

		sword.gameObject.SetActive(false);

		_gmScript = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    void Update() {
        
        if (cooldown > 0) {
			// waiting for cooldown time
            cooldown -= Time.deltaTime;
			return;
        }
		if(charVars.isAttacking) {
			currentAngle = currentAngle - (attackSpeed * Time.deltaTime);
			sword.localEulerAngles = new Vector3(0, 0, currentAngle);

			if(currentAngle < endingAngle) {
				charVars.isAttacking = false;
				cooldown = charVars.attackCooldown;
				sword.gameObject.SetActive(false);
			}
			// in mid attack
			return;
		}

		// Check for attack
        float attackX = Input.GetAxis(horizInputString);
        float attackY = Input.GetAxis(vertInputString);
        
		if(Mathf.Sqrt(attackX  * attackX + attackY * attackY) < 0.8f) {
			return;
		} 

		//  All that follows implies we are starting the attack

		startingAngle = Mathf.Atan2(attackY, attackX) * (180f/Mathf.PI);
		endingAngle = startingAngle - attackArc;
        
        // attack
		charVars.isAttacking = true;
		currentAngle = startingAngle;
		sword.localEulerAngles = new Vector3(0, 0, startingAngle);
		sword.gameObject.SetActive(true);
		audio.Play();

    }

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Attacker" && charVars.isAttacking)
		{
			// players can't kill enemies of the same color as themselves
			if (col.gameObject.GetComponent<CharacterVariables>().team == this.gameObject.GetComponent<CharacterVariables>().team)
				return;

			// play death PFX and SFX
			col.gameObject.GetComponent<NavigationAgentComponent>().CancelActiveRequest();
			Destroy(col.gameObject);

			if (this.GetComponent<CharacterVariables>().team == 1)
				_gmScript.GetComponent<GameMaster>().Player1Score++;
			else
				_gmScript.GetComponent<GameMaster>().Player2Score++;
		}
	}
}
