using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public UILabel P1HP;
	public UILabel P2HP;
	public UILabel P1Score;
	public UILabel P2Score;
	public GameObject P1Heart1;
	public GameObject P1Heart2;
	public GameObject P1Heart3;
	public GameObject P2Heart1;
	public GameObject P2Heart2;
	public GameObject P2Heart3;
	private GameObject[] Players;
	private GameObject Player1;
	private GameObject Player2;
	public int Player1Score;
	public int Player2Score;
	public AudioClip PlayerDeath;
	public AudioClip CreepDeath;
	public AudioClip PlayerHit;

	// Use this for initialization
	void Start () {
		Players = GameObject.FindGameObjectsWithTag("Target");
		foreach (GameObject go in Players) {
			if (go.GetComponent<CharacterVariables>().team == 1)
				Player1 = go;
			else if (go.GetComponent<CharacterVariables>().team == 2)
			    Player2 = go;
		}
		Player1Score = 0;
		Player2Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player1) {
			if (Player1.GetComponent<CharacterVariables>().hp == 6)
				P1Heart3.SetActive(false);
			if (Player1.GetComponent<CharacterVariables>().hp == 3)
				P1Heart2.SetActive(false);
			if (Player1.GetComponent<CharacterVariables>().hp == 0)
				P1Heart1.SetActive(false);
			P1Score.text = Player1Score.ToString();
		}
		if (Player2) {
			if (Player2.GetComponent<CharacterVariables>().hp == 6)
				P2Heart3.SetActive(false);
			if (Player2.GetComponent<CharacterVariables>().hp == 3)
				P2Heart2.SetActive(false);
			if (Player2.GetComponent<CharacterVariables>().hp == 0)
				P2Heart1.SetActive(false);
			P2Score.text = Player2Score.ToString();
		}
	}

	public void PlayCreepDeath()
	{
		audio.PlayOneShot(CreepDeath);
	}
	public void PlayPlayerDeath()
	{
		audio.PlayOneShot(PlayerDeath);
	}
	public void PlayPlayerHit()
	{
		audio.PlayOneShot(PlayerHit);
	}
}
