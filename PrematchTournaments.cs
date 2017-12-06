using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrematchTournaments : MonoBehaviour {
	// Use this for initialization

	GameObject P1, P2;
	CharacterCustom CCustom;
	GameManager GManager;
	public Text p1name, p2name, p1namecountry, p2namecountry, whoturn;
	public Image sp, ac, str, sp2, ac2, str2, p1country, p2country;

	int [ , ] bots = 
	{ { 0, 1, 0, 1, 2, 1, 0, 0, 2, 1, 1, 0, 3, 1, 3, 1, 3, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
		{ 0, 1, 0, 1, 2, 1, 0, 0, 2, 1, 1, 0, 3, 1, 3, 1, 3, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
		{ 0, 1, 0, 1, 2, 1, 0, 0, 2, 1, 1, 0, 3, 1, 3, 1, 3, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
		{ 0, 1, 0, 1, 2, 1, 0, 0, 2, 1, 1, 0, 3, 1, 3, 1, 3, 2, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
		{ 0, 1, 0, 1, 2, 1, 0, 0, 2, 1, 1, 0, 3, 1, 3, 1, 3, 2, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 0, 1, 0, 1, 2, 1, 0, 0, 2, 1, 1, 0, 3, 1, 3, 1, 3, 2, 6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } 
	};

	void Start () {
		CCustom = GameObject.Find ("CharacterCustom").GetComponent(typeof(CharacterCustom)) as CharacterCustom;
		GManager = GameObject.Find ("GameManager").GetComponent(typeof(GameManager)) as GameManager;
		GManager.isOnline = false;
		p1name.text = PlayerPrefs.GetString ("myname");
		p1namecountry.text = PlayerPrefs.GetString ("mycountry");
		p1country.sprite = (Sprite)(Resources.Load ("flag-of-" + (p1namecountry.text), typeof(Sprite)) as Sprite);
		GManager.Player1_Name = p1name.text;
		GManager.Player1_Country = p1namecountry.text;

		p2name.text = GManager.Player2_Name;
		p2namecountry.text = GManager.Player2_Country;
		p2country.sprite = (Sprite)(Resources.Load ("flag-of-" + (GManager.Player2_Country), typeof(Sprite)) as Sprite);
		for (int i = 1; i <= 28; i++) {
			//Debug.Log (CCustom.nameItems [i] + "_Player " + PlayerPrefs.GetInt ((CCustom.nameItems[i] + "_Player")));
			CCustom.p1 [i] = PlayerPrefs.GetInt (CCustom.nameItems[i] + "_Player");
			PlayerPrefs.SetInt (CCustom.nameItems[i], CCustom.p1[i]);
		}
		CCustom.MakeCharacter (ref P1);
		CCustom.Up (1);
		sp.transform.localScale = new Vector3(Mathf.Min (1, GManager.Player1_Speed / 100), sp.transform.localScale.y, sp.transform.localScale.z);
		ac.transform.localScale = new Vector3(Mathf.Min (1, GManager.Player1_Goal / 100), ac.transform.localScale.y, ac.transform.localScale.z);
		str.transform.localScale = new Vector3(Mathf.Min (1, GManager.Player1_Strong / 100), str.transform.localScale.y, str.transform.localScale.z);
		P1.transform.position = new Vector3 (-200f, 0, 0);
		P1.transform.rotation = Quaternion.LookRotation (Vector3.back);
		GManager.Player1CurrentCharacter = P1;
		DontDestroyOnLoad (P1);

		int lb = PlayerPrefs.GetInt ("BotsLevel");
		Adjust (0);
	}

	public void Adjust(int z){
		int lb = PlayerPrefs.GetInt ("BotsLevel");
		lb = lb + z;
		sp2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Speed / 100), sp2.transform.localScale.y, sp2.transform.localScale.z);
		ac2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Goal / 100), ac2.transform.localScale.y, ac2.transform.localScale.z);
		str2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Strong / 100), str2.transform.localScale.y, str2.transform.localScale.z);
		if (P2 != null)
			Destroy (P2);
		lb = (int)(lb / 60f * 12 + 1);
		lb++;
		if (lb > 12)
			lb = 12;
		if (lb < 1)
			lb = 1;
		for (int i = 1; i <= 28; i++) {
			CCustom.p2 [i] = (int) Random.Range (1, 3.99f);
			if (i == 5)
				CCustom.p2 [i] = 1;
			if (i == 3)
				CCustom.p2 [i] = 0;
			else if (i == 9) {
				CCustom.p2 [i] = 1;
			}
			PlayerPrefs.SetInt (CCustom.nameItems [i], CCustom.p2 [i]);
			i++;
			CCustom.p2 [i] = (int) Random.Range (1, lb);
			if (i == 6)
				CCustom.p2 [i] = (int)Random.Range (1, 5.99f);
			if (i == 2) CCustom.p2 [i] = (int)Random.Range (2, lb);
			else if (i == 10) {
				if (Random.Range (0, 10) > 8) {
					CCustom.p2 [i] = 2;
				} else CCustom.p2 [i] = 1;
			}
			PlayerPrefs.SetInt (CCustom.nameItems [i], CCustom.p2 [i]);
		}
		CCustom.MakeCharacter (ref P2);
		P2.transform.position = new Vector3 (200f, 0, 0);
		GManager.Player2CurrentCharacter = P2;
		DontDestroyOnLoad (P2);
		P2.transform.rotation = Quaternion.LookRotation (Vector3.back);
		GManager.reachToWin = 2;
		if (Random.Range (10, 30) > 20)
			GManager.Player1Turn = true;
		else
			GManager.Player1Turn = false;
		GManager.isPlayer2Computer = true;
		GManager.isTieBreak = false;
		GManager.Player1CurrentPoint = 0;
		GManager.Player1CurrentWonPointTieBreak = 0;
		GManager.Player1CurrentWonSets = 0;
		GManager.Player1NumberCurrentWonGames = 0;
		GManager.Player2CurrentPoint = 0;
		GManager.Player2CurrentWonPointTieBreak = 0;
		GManager.Player2CurrentWonSets = 0;
		GManager.Player2NumberCurrentWonGames = 0;
		GManager.isOnTournaments = true;
		GManager.NewPoint = true;
		GManager.typeOfCourt = PlayerPrefs.GetInt("whichcourt");
		GManager.Player1Turn = false;
		if (GManager.Player1Turn == true)
			whoturn.text = "Toss Result: You Serve First Game";
		else
			whoturn.text = "Toss Result: Player 2 Serve First Game";


	}

	void Update () {

	}
}
