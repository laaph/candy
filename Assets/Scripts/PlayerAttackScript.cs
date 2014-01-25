using UnityEngine;

public class PlayerAttackScript : MonoBehaviour {

    // inspector variables
    public float attackSpeed = 1.2f;
    //public Transform 
    
    // keeps track of current cooldown
    private float cooldown;

    void Start() {
        cooldown = 0f;
    }
    
    void Update() {
        
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
        
		// attackX and attackY give direction of attack
		// button let's us know to attack
		// there is also Player2Fire and associated input
		// Movement is handled with Player1MoveHoriz and Player1MoveVert

        bool attackPressed = Input.GetButtonDown("Player1Fire");
		float attackX = Input.GetAxis("Player1ShootHoriz");
		float attackY = Input.GetAxis("Player1ShootVert");

		// Not sure what you aer doing here, let me know if I should add another button input.

        attackPressed |= Input.GetButtonDown("Fire2");
        
        if (attackPressed && cooldown <= 0f) {
            // to do
        }
    }
}
