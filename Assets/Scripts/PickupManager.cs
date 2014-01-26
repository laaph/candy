using UnityEngine;
using System.Collections;

public class PickupManager : MonoBehaviour {

	public float pickupRateMin = 2f;
	public float pickupRateMax = 4f;
	public float pickupChance = 0.5f;
	public int spawnsLeft = 3;
	public Pickup pickup;

	public bool isAlreadySpawned = false;
	private float spawnTimer;

	void Start () {

		spawnTimer = RandomizeSpawnTime();
	}

	void Update () {

		if (spawnTimer > 0) {
			spawnTimer -= Time.deltaTime;
		}
		// time ran out, make roll at a spawn chance
		else {
			if (!isAlreadySpawned && spawnsLeft > 0 && pickupChance >= Random.value) {
				Debug.Log("spawn pickup here");
				pickup.Spawn();
				isAlreadySpawned = true;
			}
			spawnTimer = RandomizeSpawnTime();
		}
	}

	float RandomizeSpawnTime () {
		return Random.value * (pickupRateMax - pickupRateMin) + pickupRateMin;
	}
}
