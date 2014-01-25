using UnityEngine;
using System.Collections;

public class LevelVariables : MonoBehaviour {

	// NOTE: defaults are completely arbitrary for now

	// minimum time before a new unit spawns
	public float SpawnRateMin = 5f;

	// maximum time before a new unit spawns
	public float SpawnRateMax = 10f;

	// amount of units spawned at once
	public int SpawnDensityMin = 5;
	public int SpawnDensityMax = 10;

	// max amount of units to spawn
	public int SpawnTotal = 50;

	// pickup chances -- chance that pickups will spawn
	// number between 0.0 and 1.0 for comparison with Unity's Random
	public float SoundwaveChance = .2f;
	public float InvertChance = .2f;
	public float SpeedupChance = .2f;

	void Start () {

	}

	void Update () {
	
	}
}
