using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChooseGrounds : MonoBehaviour {


	GameManager GManager;
	public Image i1, i2;
	public Button c1, c2, c3, g1, g2, g3;

	// Use this for initialization
	void Start () {
		GManager = GameObject.Find ("GameManager").GetComponent(typeof(GameManager)) as GameManager;
		if (Random.Range (10, 30) > 20)
			GManager.Player1Turn = true;
		else
			GManager.Player1Turn = false;
		//GManager.Player1Turn = true;
		GManager.STANDINRIGHT = true;
		GManager.isPlayer2Computer = true;
		GManager.isOnTournaments = false;
		GManager.isTieBreak = false;
		GManager.Player1CurrentPoint = 0;
		GManager.Player1CurrentWonPointTieBreak = 0;
		GManager.Player1CurrentWonSets = 0;
		GManager.Player1NumberCurrentWonGames = 0;
		GManager.Player2CurrentPoint = 0;
		GManager.Player2CurrentWonPointTieBreak = 0;
		GManager.Player2CurrentWonSets = 0;
		GManager.Player2NumberCurrentWonGames = 0;
		GManager.NewPoint = true;
		GManager.typeOfCourt = 1;
		GManager.reachToWin = 1;
		GManager.isOnline = false;
	}

	public void CourtPress(int n){
		AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		GManager.typeOfCourt = n;
	}

	public void GamePress(int n){
		AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		GManager.reachToWin = (n + 1) / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (GManager.typeOfCourt == 1) {
			i1.transform.position = c1.transform.position;
		} else if (GManager.typeOfCourt == 2) {
			i1.transform.position = c2.transform.position;
		} else {
			i1.transform.position = c3.transform.position;
		}
		if (GManager.reachToWin == 1) {
			i2.transform.position = g1.transform.position;
		} else if (GManager.reachToWin == 2) {
			i2.transform.position = g2.transform.position;
		} else {
			i2.transform.position = g3.transform.position;
		}
	}

	public void Play(int level){
		AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		if (level == 1 || level == 0) {
			Destroy (GameObject.Find ("GameManager"));
			Destroy (GameObject.Find ("CharacterCustom"));

			foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player")) {
				Destroy (tmp);
			}
		} else if (level == 7) {
			foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player")) {
				tmp.transform.position = new Vector3 (100, 0, 0);
			}

		}
		PlayerPrefs.Save ();
		Application.LoadLevel (level);
	}
}
