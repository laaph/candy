using UnityEngine;


public class PlayerAttackScript : MonoBehaviour {
    
    // designer variables for unity's inspector
    public float attackSpeed = 0.25f;
    public int damage = 1;

    public Transform WeaponHitBox;
    
    // keeps track of current cooldown
    private float cooldown;

    void Start() {
        cooldown = 0f;
    }
    
    void Update() {
        
        bool attackPressed = Input.GetButtonDown("Fire1");
        attackPressed |= Input.GetButtonDown("Fire2");

        if (attackPressed && CanAttack){
            // to do
        }
        
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
    }
    
    public bool CanAttack {
        get {
            return cooldown <= 0f;
        }
    }
}
