using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PrematchOnline : NetworkBehaviour {
	// Use this for initialization

	GameObject P1, P2;
	CharacterCustom CCustom;
	GameManager GManager;
	public Text p1name, p2name, p1namecountry, p2namecountry;
	public Image sp, ac, str, sp2, ac2, str2, p1country, p2country;
	float time;
	Datas datas; 
	dataplayers dapl;

	void Start() {
		CCustom = GameObject.Find ("CharacterCustom").GetComponent(typeof(CharacterCustom)) as CharacterCustom;
		GManager = GameObject.Find ("GameManager").GetComponent(typeof(GameManager)) as GameManager;
		dapl = GameObject.Find ("DataPlayer").GetComponent<dataplayers>();
		AdMobBanner.instance.HideBanner ();
	}

	void Update() {
		if (GManager.isOnline)
			return;
		if (GManager.fakeOnline == true) {
			if (Random.Range (0, 10) > 5)
				GManager.Player1Turn = false;
			else
				GManager.Player1Turn = true;
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
			GManager.typeOfCourt = 3;
			GManager.reachToWin = 3;
			GManager.isOnline = true;

			GManager.Player1_Name = PlayerPrefs.GetString("myname");
			GManager.Player1_Country = PlayerPrefs.GetString ("mycountry");
			for (int i = 1; i <= 28; i++) {
				PlayerPrefs.SetInt (CCustom.nameItems [i], PlayerPrefs.GetInt(CCustom.nameItems[i] + "_Player"));
			}
			CCustom.MakeCharacter (ref P1);
			CCustom.Up (1);
			P1.transform.position = new Vector3 (-200f, 0, 0);
			P1.transform.rotation = Quaternion.LookRotation (Vector3.back);
			p1name.text = GManager.Player1_Name;
			p1namecountry.text = GManager.Player1_Country;
			p1country.GetComponent<Image> ().sprite = (Sprite)Resources.Load ("flag-of-" + p1namecountry.text, typeof(Sprite));
			sp.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player1_Speed / 100), 1, 1);
			ac.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player1_Goal / 100), 1, 1);
			str.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player1_Strong / 100), 1, 1);

			GManager.Player1CurrentCharacter = P1;
			DontDestroyOnLoad (P1);

			int level;
			if(PlayerPrefs.GetInt("ProfileLevel") <= 200) level = (int)Random.Range (0, 30);
			else level = (int)Random.Range (20, 60);
			int speed = 1, goal = 1, strong = 1;
			dapl.starts (level, ref speed, ref goal, ref strong);

			Debug.Log ("level " + level);

			GManager.Player2_Goal = goal;
			GManager.Player2_Strong = strong;
			GManager.Player2_Speed = speed;
			ac2.transform.localScale = new Vector3 (goal / 100f, 1, 1);
			sp2.transform.localScale = new Vector3 (speed / 100f, 1, 1);
			str2.transform.localScale = new Vector3 (strong / 100f, 1, 1);

			if (PlayerPrefs.GetInt ("isBoy_Player") == 1) {
				GManager.Player2_Name = dapl.wta [(int)Random.Range (120, 299.99f)];
			} else {
				GManager.Player2_Name = dapl.atp [(int)Random.Range (120, 299.99f)];
			}
			GManager.Player2_Country = dapl.countries [(int)Random.Range (0, 196.99f)];

			int k = (int)(level / 60.0f * 12 + 1);
			if (k > 12)
				k = 12;
			if (k == 0)
				k = 1;
			Debug.Log (k +  " k ");
			CCustom.p2 [0] = (int)Random.Range (0, 1.99f);
			PlayerPrefs.SetInt (CCustom.nameItems [0], CCustom.p2 [0]);
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
				CCustom.p2 [i] = (int) Random.Range (1, k);
				if (i == 6)
					CCustom.p2 [i] = (int)Random.Range (1, 5.99f);
				if (i == 2) CCustom.p2 [i] = (int)Random.Range (2, k);
				else if (i == 10) {
					if (Random.Range (0, 10) > 8) {
						CCustom.p2 [i] = 2;
					} else CCustom.p2 [i] = 1;
				}
				PlayerPrefs.SetInt (CCustom.nameItems [i], CCustom.p2 [i]);
			}

			CCustom.MakeCharacter (ref P2);
			CCustom.Up (2);
			P2.transform.position = new Vector3 (200f, 0, 0);
			P2.transform.rotation = Quaternion.LookRotation (Vector3.back);
			p2name.text = GManager.Player2_Name;
			p2namecountry.text = GManager.Player2_Country;
			p2country.GetComponent<Image> ().sprite = (Sprite)Resources.Load ("flag-of-" + p2namecountry.text, typeof(Sprite));

			sp2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Speed / 100), sp2.transform.localScale.y, sp2.transform.localScale.z);
			ac2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Goal / 100), ac2.transform.localScale.y, ac2.transform.localScale.z);
			str2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Strong / 100), str2.transform.localScale.y, str2.transform.localScale.z);

			GManager.Player2CurrentCharacter = P2;
			DontDestroyOnLoad (P2);

			GManager.isOnline = true;
			return;
		}
		if (GameObject.Find ("Datas") != null && GameObject.Find("Datas").gameObject.activeInHierarchy)
				datas = GameObject.Find ("Datas").GetComponent (typeof(Datas)) as Datas;
		if (datas != null) {
			GManager.NewPoint = true;
			GManager.typeOfCourt = 1;
			GManager.Player1Turn = true;
			GManager.reachToWin = 3;
			GManager.isOnline = true;
			if (GManager.Player1CurrentCharacter == null) {
				GManager.Player1_Name = datas.p1name;
				GManager.Player1_Country = datas.p1country;
				for (int i = 1; i <= 29; i++) {
					PlayerPrefs.SetInt (CCustom.nameItems [i - 1], datas.p1 [i - 1]);
				}
				CCustom.MakeCharacter (ref P1);
				CCustom.Up (1);
				p1name.text = GManager.Player1_Name;
				p1namecountry.text = GManager.Player1_Country;
				sp.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player1_Speed / 100), 1, 1);
				ac.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player1_Goal / 100), 1, 1);
				str.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player1_Strong / 100), 1, 1);
				P1.transform.position = new Vector3 (-2f, 0, 0);
				P1.transform.rotation = Quaternion.LookRotation (Vector3.back);
				GManager.Player1CurrentCharacter = P1;
				DontDestroyOnLoad (P1);
			}
			if (GManager.Player2CurrentCharacter == null) {
				GManager.Player2_Name = datas.p2name;
				GManager.Player2_Country = datas.p2country;
				for (int i = 1; i <= 29; i++) {
					PlayerPrefs.SetInt (CCustom.nameItems [i - 1], datas.p2 [i - 1]);
				}
				CCustom.MakeCharacter (ref P2);
				CCustom.Up (2);
				p2name.text = GManager.Player2_Name;
				p2namecountry.text = GManager.Player2_Country;
				sp2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Speed / 100), sp2.transform.localScale.y, sp2.transform.localScale.z);
				ac2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Goal / 100), ac2.transform.localScale.y, ac2.transform.localScale.z);
				str2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Strong / 100), str2.transform.localScale.y, str2.transform.localScale.z);
				P2.transform.position = new Vector3 (200f, 0, 0);
				P2.transform.rotation = Quaternion.LookRotation (Vector3.back);
				GManager.Player2CurrentCharacter = P2;
				DontDestroyOnLoad (P2);
			}
			p1country.sprite = Resources.Load (p1namecountry.text, typeof(Sprite)) as Sprite;
			p2country.sprite = Resources.Load (p2namecountry.text, typeof(Sprite)) as Sprite;
		}
	}
}
