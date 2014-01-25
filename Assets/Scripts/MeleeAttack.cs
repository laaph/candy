using UnityEngine;
using System.Collections;
using SimpleAI.Navigation;

	[RequireComponent(typeof(FindClosestEnemy))]
	[RequireComponent(typeof(NavigationAgentComponent))]
public class MeleeAttack : MonoBehaviour {

	public float attackRate = 1f;				// how frequently to strike the target
	public int attackDamage = 1;
	private float nextAttack = 0f;
	public bool isAttacking = false;
	
	public bool hasTarget = false;
	public GameObject curTarget = null; 		// temp setting public for debug, make private when done debugging.
	
	public float							m_replanInterval = 0.5f;
	private NavigationAgentComponent 		m_navigationAgent;
	private bool							m_bNavRequestCompleted;
	
	public GameObject damagePFX;
	
	void Awake()
	{
		m_bNavRequestCompleted = true;
		m_navigationAgent = GetComponent<NavigationAgentComponent>();
	}
	
	void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, GetComponent<FindClosestEnemy>().maxDistToTarget);
    }
	
	// Update is called once per frame
	void Update () {

		if (!hasTarget)
		{
			curTarget = GetComponent<FindClosestEnemy>().FindClosest(this.transform.position);
			if (curTarget != null)
			{
				hasTarget = true;
				curTarget.renderer.material.color = Color.red;
			}
		}
		
		if (hasTarget)
		{
			// test if target has been destroyed
			if (curTarget == null)
			{
				hasTarget = false;
				isAttacking = false;
				this.GetComponent<PathAgentComponent>().CancelActiveRequest();
				return;
			}	
			if (curTarget != null)
			{	
				// initiate chase behavior if not already attacking
				if (!isAttacking)
				{
					if ( m_bNavRequestCompleted)
					{
						if ( m_navigationAgent.MoveToGameObject(curTarget, m_replanInterval) )
						{
							m_bNavRequestCompleted = false;
						}
					}
				}
				// damage target if attacking
				if (isAttacking)
				{
					if (Time.time > nextAttack)
					{
						nextAttack = Time.time + attackRate;
						this.GetComponent<PathAgentComponent>().CancelActiveRequest();	// trying to fix MissingRefereneException
						curTarget.GetComponent<CharacterVariables>().hp -= attackDamage;
						//if (curTarget.GetComponent<CharacterVariables>().Hitpoints <= 0)
							//Destroy (curTarget);
						//Instantiate(damagePFX, curTarget.transform.position, Quaternion.identity);
					}
				}
			}
		}
	}
	
	void OnCollisionStay (Collision col)	// was OnTriggerStay, but Creeps didn't collide with Merc
	{
		if (col.gameObject == curTarget)
		{
			isAttacking = true;
		}
	}
	
	#region Messages
	private void OnNavigationRequestSucceeded()
	{
		m_bNavRequestCompleted = true;
	}
	
	private void OnNavigationRequestFailed()
	{
		m_bNavRequestCompleted = true;
	}
	#endregion
}
