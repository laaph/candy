using UnityEngine;

public class PlayerAttackScript : MonoBehaviour {
    
    // character variables
        //public int team = 1;
        //public int hp;
        //public int maxHp;
        //public int attackDamage;
        //public float attackRadius;
        //public float attackArc;
        //public float attackSpeed;
        //public float moveSpeed;
    public gameObject o;
    private Script cv;

    // keeps track of current cooldown
    private float cooldown;
    
    // input strings based on player number
    private string horizInputString = "Player1ShootHoriz";
    private string vertInputString = "Player1ShootVert";
    
    // (current) ending angle -- this is where the player pushed the thumbstick
    private float endingAngle;
    
    private float startingAngle;

    void Start() {

        cv = o.GetComponent<CharacterVariables>();
        cooldown = 0f;
        
        // change input strings based on player variable
        if (cv.team == 2) {
            horizInputString = "Player2ShootHoriz";
            vertInputString = "Player2ShootVert";
        }
    }

    void Update() {
        
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
        else {
            // set isAttacking here
        }

        float attackX = Input.GetAxis(horizInputString);
        float attackY = Input.GetAxis(vertInputString);
        
        endingAngle = Mathf.Atan2(attackY, attackX);
        startingAngle = endingAngle + cv.attackArc;
        
        // attack
        if (cooldown <= 0f) {
            
            // todo: rotation code, etc.

        }
    }
}
