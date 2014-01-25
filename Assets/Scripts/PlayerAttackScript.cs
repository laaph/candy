using UnityEngine;

public class PlayerAttackScript : MonoBehaviour {

    public float AttackSpeed = 0.25f;
    
    // keeps track of current cooldown
    private float cooldown;

    void Start()
    {
        cooldown = 0f;
    }
    
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
    
    public bool CanAttack
    {
        get
        {
            return cooldown <= 0f;  // Whoever wrote this - don't check in broken code!
        }
    }

    public void Attack() {
        
        if (CanAttack) { // based on cooldown
            
            //Transform attackTransform = Instantiate()
        }
    }
}
