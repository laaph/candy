using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public UILabel P1HP;
	public UILabel P2HP;
	private GameObject[] Players;
	private GameObject Player1;
	private GameObject Player2;

	// Use this for initialization
	void Start () {
		Players = GameObject.FindGameObjectsWithTag("Target");
		foreach (GameObject go in Players) {
			if (go.GetComponent<CharacterVariables>().team == 1)
				Player1 = go;
			else if (go.GetComponent<CharacterVariables>().team == 2)
			    Player2 = go;
		}
	}
	
	// Update is called once per frame
	void Update () {
		P1HP.text = Player1.GetComponent<CharacterVariables>().hp.ToString();
		P2HP.text = Player2.GetComponent<CharacterVariables>().hp.ToString();
	}
}
