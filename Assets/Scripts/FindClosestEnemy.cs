using UnityEngine;
using System.Collections;

public class FindClosestEnemy : MonoBehaviour {
	
	public float maxDistToTarget = 50f;
	public string TargetTag;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public GameObject FindClosest(Vector3 pos)
	{
		GameObject[] targets;
		targets = GameObject.FindGameObjectsWithTag(TargetTag);
		GameObject closest = null;	
		float dist = Mathf.Infinity;
		foreach (GameObject target in targets)
		{
			Vector3 diff = target.transform.position - pos;
			float curDistance = diff.magnitude;			// for production, use sqrMagnitude, it's cheaper
			if (curDistance < dist && curDistance <= maxDistToTarget)
			{
				closest = target;
				dist = curDistance;
			}
		}
		return closest;
	}
	
}
