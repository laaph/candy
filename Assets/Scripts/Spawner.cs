using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject CreepPrefab;
	public float SpawnRate;			// spawn a creep once evey this many seconds
	public int NumCreepsSpawned;
	//public UILabel LabelCreepsSpawned;
	private float _spawnInterval;				// time since last spawn
	private bool _isActive;

	// Use this for initialization
	void Start () {
		_spawnInterval = 0;
		_isActive = true;
		NumCreepsSpawned = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (_isActive)
		{
			_spawnInterval = _spawnInterval + Time.deltaTime;
			if (_spawnInterval >= SpawnRate)
			{
				SpawnCreep();
				_spawnInterval = 0;
			}
		}
	}


	void SpawnCreep()
	{
		GameObject creep;
		creep = GameObject.Instantiate(CreepPrefab, this.transform.position, Quaternion.identity) as GameObject;
		NumCreepsSpawned++;
		//LabelCreepsSpawned.text = NumCreepsSpawned.ToString();
	}

}
