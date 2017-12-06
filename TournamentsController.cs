using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TournamentsController : MonoBehaviour {

	public GameObject panel;
	public GameObject panel2;
	public GameObject panel3;
	public Text cashoutmoney, tournamentname, mymoney, tournamentprize, p2name, p2country, title, r1, r2, r3, r4, r5, warntext;
	public Image icon, flag, p2speed, p2strong, p2goal;
	public Image cup;
	public Button cashoutbutton, backbutton;

	void Start () {
		mymoney.text = formart(PlayerPrefs.GetInt ("mymoney"));
		if (PlayerPrefs.GetInt ("CurrentRound") > 1) {
			panel.gameObject.SetActive (false);
			Show ();
		}
	}

	string formart(int s)
	{
		string tmp = s.ToString ();
		int count = 0;
		for (int i = tmp.Length; i >= 1; i--) {
			count++;
			if (count >= 4) {
				tmp = tmp.Insert (i, ",");
				count = 1;
			}
		}
		return tmp;
	}

	public void cashout(){
		int n = PlayerPrefs.GetInt ("CurrentRound");
		int prize = PlayerPrefs.GetInt ("Prize");
		switch (n) {
		case 2:
			prize = prize * 5 / 100;
			break;
		case 3:
			prize = prize * 25 / 100;
			break;
		case 4:
			prize = prize * 55 / 100;
			break;
		}

		int mymoney = PlayerPrefs.GetInt ("mymoney");
		mymoney += prize;

		int tmp3 = PlayerPrefs.GetInt ("moneyearned");
		tmp3 += prize;
		PlayerPrefs.SetInt ("moneyearned", tmp3);

		PlayerPrefs.SetInt ("mymoney", mymoney);
		PlayerPrefs.SetInt ("CurrentRound", 1);
	}

	void Show(){
		int n = PlayerPrefs.GetInt ("CurrentRound");
		mymoney.text = formart(PlayerPrefs.GetInt ("mymoney"));
		tournamentname.text = PlayerPrefs.GetString ("TourName");
		tournamentprize.text = formart(PlayerPrefs.GetInt ("Prize"));
		cup.sprite = (Sprite)Resources.Load (("cup" + PlayerPrefs.GetInt("whichcup").ToString()), typeof(Sprite));
		if (n == 1) {
			r1.color = Color.red;
		} else if (n == 2) {
			r2.color = Color.red;
		} else if (n == 3) {
			r3.color = Color.red;
		} else if (n == 4) {
			r4.color = Color.red;
		} else if (n == 5) {
			r5.color = Color.red;
		}
		if (n > 1) {
			int prize = PlayerPrefs.GetInt("Prize");
			switch (n) {
			case 2:
				prize = prize * 5 / 100;
				break;
			case 3:
				prize = prize * 25 / 100;
				break;
			case 4:
				prize = prize * 55 / 100;
				break;
			}
			backbutton.gameObject.SetActive (false);
			cashoutmoney.text = "current prize: " + formart(prize);
		} else {
			cashoutmoney.gameObject.SetActive (false);
			cashoutbutton.gameObject.SetActive (false);
		}
		foreach (Transform t in panel2.transform) {
			if (t.name == "Image")
				continue;
			t.gameObject.GetComponent<Image> ().color = Color.black;
		}

		GameManager GManager = GameObject.Find ("GameManager").GetComponent(typeof(GameManager)) as GameManager;
		dataplayers dapl = GameObject.Find ("DataPlayer").GetComponent<dataplayers>();


		int minlevel, maxlevel;

		switch (PlayerPrefs.GetInt("whichtour")) {
		case 1:
			minlevel = 1;
			maxlevel = 30;
			break;
		case 2:
			minlevel = 5;
			maxlevel = 40;
			break;
		case 3:
			minlevel = 15;
			maxlevel = 50;
			break;
		case 4:
			minlevel = 20;
			maxlevel = 40;
			break;
		case 5:
			minlevel = 21;
			maxlevel = 45;
			break;
		case 6:
			minlevel = 22;
			maxlevel = 46;
			break;
		case 7:
			minlevel = 23;
			maxlevel = 47;
			break;
		case 8:
			minlevel = 24;
			maxlevel = 50;
			break;
		case 9:
			minlevel = 25;
			maxlevel = 51;
			break;
		case 10:
			minlevel = 26;
			maxlevel = 52;
			break;
		case 11:
			minlevel = 27;
			maxlevel = 50;
			break;
		case 12:
			minlevel = 28;
			maxlevel = 52;
			break;
		case 13:
			minlevel = 29;
			maxlevel = 54;
			break;
		case 14:
			minlevel = 30;
			maxlevel = 56;
			break;
		case 15:
			minlevel = 50;
			maxlevel = 60;
			break;
		default:
			minlevel = 1;
			maxlevel = 60;
			break;
		}

		int strong = 1, speed = 1, goal = 1;
		int level = (int)Random.Range (minlevel + (maxlevel - minlevel) / 4 * (n - 1), minlevel + (maxlevel - minlevel) / 4 * n);
		dapl.starts (level, ref speed, ref goal, ref strong);

		PlayerPrefs.SetInt ("BotsLevel", level);

		GManager.Player2_Goal = goal;
		GManager.Player2_Strong = strong;
		GManager.Player2_Speed = speed;
		p2goal.transform.localScale = new Vector3 (goal / 100f, 1, 1);
		p2speed.transform.localScale = new Vector3 (speed / 100f, 1, 1);
		p2strong.transform.localScale = new Vector3 (strong / 100f, 1, 1);

		int k;
		if (level <= 15) {
			k = (int) Random.Range (100, 119.99f);
			if (PlayerPrefs.GetInt ("isBoy_Player") == 1) {
				Debug.Log (k);
				Debug.Log (dapl.atp.Length);
				GManager.Player2_Name = dapl.wta [k];
				GManager.Player2_Country = PlayerPrefs.GetString ("mycountry");
			} else {
				GManager.Player2_Name = dapl.atp [k];
				GManager.Player2_Country = PlayerPrefs.GetString ("mycountry");
			}
		} else {
			k = 100 - (level - 15) / (60 - 15) * 100;
			if (k >= 98)
				k = 80;
			if (k < 0)
				k = 0;
			Debug.Log ("level + " + level + " " + k);
			int min = Mathf.Min (k + 20, 99);
			k = (int) Random.Range (k, min);
			k = Mathf.Min (k, 99);
			if (PlayerPrefs.GetInt ("isBoy_Player") == 1) {
				GManager.Player2_Name = dapl.atp [k];
				GManager.Player2_Country = dapl.modify(dapl.atpcountries[k]);
			} else {
				GManager.Player2_Name = dapl.wta [k];
				GManager.Player2_Country = dapl.modify(dapl.wtacountries[k]);
			}
		}

		flag.sprite = Resources.Load ("flag-of-" + GManager.Player2_Country, typeof(Sprite)) as Sprite;
		p2name.text = GManager.Player2_Name;
		p2country.text = GManager.Player2_Country;

		Debug.Log ("my place " + PlayerPrefs.GetInt("MyPlace"));
		Debug.Log ("n = " + n);
		for (int i = 1; i <= n; i++) {
			int[] r, rprevious;
			r = new int[17];
			rprevious = new int[17];
			if (i > 1) {
				rprevious = PlayerPrefsX.GetIntArray ("r" + (i - 1).ToString());
			}
			r = PlayerPrefsX.GetIntArray ("r" + i.ToString());
			foreach (Transform t in panel2.transform) {
				string s = t.gameObject.name;
				if (i == 1) {
					if (s[0] == '1') {
						t.gameObject.GetComponent<Image> ().color = Color.blue;
						if (PlayerPrefs.GetInt ("MyPlace") >= 10) {
							if (s.Length >= 4 && PlayerPrefs.GetInt ("MyPlace") % 10 == s [3] - '0') {
								icon.transform.position = t.transform.position;
							}
						} else {
							if (r[s[2] - '0'] == PlayerPrefs.GetInt ("MyPlace"))
								icon.transform.position = t.transform.position;
						}
						Debug.Log (s + " " + r[s[2] - '0'] + " ,,, " +  PlayerPrefs.GetInt("MyPlace"));
					}
				} else {
					if ((s [0] - '0') == i) {
						if (s [2] != '*') {
							t.gameObject.GetComponent<Image> ().color = Color.blue;
							if(r[s[2] - '0'] == PlayerPrefs.GetInt("MyPlace")) icon.transform.position = t.transform.position;
						} else {
							if (s.Length >= 6) {
								if (rprevious [(s [4] - '0') * 10 + (s [5] - '0')] == r [((s [4] - '0') * 10 + (s [5] - '0') + 1) / 2]) {
									t.gameObject.GetComponent<Image> ().color = Color.blue;
								}
							} else {
								if (rprevious [s [4] - '0'] == r [(s [4] - '0' + 1) / 2]) {
									t.gameObject.GetComponent<Image> ().color = Color.blue;
								}
							}
						}
					}
				}
			}
		}
	}

	public void back()
	{
		AudioManager.instance.SFX.PlayOneShot(AudioManager.instance.negativetap);
	}

	IEnumerator warnning(){
		warntext.gameObject.SetActive (true);
		yield return new WaitForSeconds (2);
		warntext.CrossFadeAlpha (0, 0.5f, false);
		yield return new WaitForSeconds (0.5f);
		warntext.gameObject.SetActive (false);
	}

	public void Setup(int whichone)
	{
		if (whichone > 2 && PlayerPrefs.GetInt ((whichone - 1).ToString () + "won") == 0) {
			AudioManager.instance.SFX.PlayOneShot(AudioManager.instance.negativetap);
			StartCoroutine ("warnning");
			return;
		}
		AudioManager.instance.SFX.PlayOneShot(AudioManager.instance.positivetap);
		PlayerPrefs.SetInt ("whichtour", whichone);
		if (whichone == 1) {
			PlayerPrefs.SetString ("TourName", "Neighbor");
			PlayerPrefs.SetInt ("Prize", 20000);
			PlayerPrefs.SetInt ("whichcourt", 2);
			PlayerPrefs.SetInt ("whichcup", 1);
		} else if (whichone == 2) {
			PlayerPrefs.SetString ("TourName", "City");
			PlayerPrefs.SetInt ("Prize", 100000);
			PlayerPrefs.SetInt ("whichcourt", 1);
			PlayerPrefs.SetInt ("whichcup", 1);
		} else if (whichone == 3) {
			PlayerPrefs.SetString ("TourName", "Paris");
			PlayerPrefs.SetInt ("Prize", 500000);
			PlayerPrefs.SetInt ("whichcourt", 1);
			PlayerPrefs.SetInt ("whichcup", 3);
		} else if (whichone == 4) {
			PlayerPrefs.SetString ("TourName", "Madrid");
			PlayerPrefs.SetInt ("Prize", 500000);
			PlayerPrefs.SetInt ("whichcourt", 3);
			PlayerPrefs.SetInt ("whichcup", 2);
		} else if (whichone == 5) {
			PlayerPrefs.SetString ("TourName", "London");
			PlayerPrefs.SetInt ("Prize", 600000);
			PlayerPrefs.SetInt ("whichcourt", 1);
			PlayerPrefs.SetInt ("whichcup", 4);
		} else if (whichone == 6) {
			PlayerPrefs.SetString ("TourName", "Shanghai");
			PlayerPrefs.SetInt ("Prize", 600000);
			PlayerPrefs.SetInt ("whichcourt", 1);
			PlayerPrefs.SetInt ("whichcup", 2);
		} else if (whichone == 7) {
			PlayerPrefs.SetString ("TourName", "Miami");
			PlayerPrefs.SetInt ("Prize", 800000);
			PlayerPrefs.SetInt ("whichcourt", 1);
			PlayerPrefs.SetInt ("whichcup", 3);
		} else if (whichone == 8) {
			PlayerPrefs.SetString ("TourName", "Rome");
			PlayerPrefs.SetInt ("Prize", 900000);
			PlayerPrefs.SetInt ("whichcourt", 3);
			PlayerPrefs.SetInt ("whichcup", 4);
		} else if (whichone == 9) {
			PlayerPrefs.SetString ("TourName", "Indian Wells");
			PlayerPrefs.SetInt ("Prize", 1000000);
			PlayerPrefs.SetInt ("whichcourt", 1);
			PlayerPrefs.SetInt ("whichcup", 2);
		} else if (whichone == 10) {
			PlayerPrefs.SetString ("TourName", "Monte Carlo");
			PlayerPrefs.SetInt ("Prize", 1200000);
			PlayerPrefs.SetInt ("whichcourt", 3);
			PlayerPrefs.SetInt ("whichcup", 3);
		} else if (whichone == 11) {
			PlayerPrefs.SetString ("TourName", "ATP 1000");
			PlayerPrefs.SetInt ("Prize", 1400000);
			PlayerPrefs.SetInt ("whichcourt", 1);
			PlayerPrefs.SetInt ("whichcup", 4);
		} else if (whichone == 12) {
			PlayerPrefs.SetString ("TourName", "The Championship Grand Slam");
			PlayerPrefs.SetInt ("Prize", 2000000);
			PlayerPrefs.SetInt ("whichcourt", 2);
			PlayerPrefs.SetInt ("whichcup", 2);
		} else if (whichone == 13) {
			PlayerPrefs.SetString ("TourName", "Australia Grand Slam");
			PlayerPrefs.SetInt ("Prize", 2200000);
			PlayerPrefs.SetInt ("whichcourt", 1);
			PlayerPrefs.SetInt ("whichcup", 4);
		} else if (whichone == 14) {
			PlayerPrefs.SetString ("TourName", "France Grand Slam");
			PlayerPrefs.SetInt ("Prize", 3300000);
			PlayerPrefs.SetInt ("whichcourt", 3);
			PlayerPrefs.SetInt ("whichcup", 3);
		} else if (whichone == 15) {
			PlayerPrefs.SetString ("TourName", "US Open Grand Slam");
			PlayerPrefs.SetInt ("Prize", 4000000);
			PlayerPrefs.SetInt ("whichcourt", 1);
			PlayerPrefs.SetInt ("whichcup", 2);
		}
		PlayerPrefs.SetInt ("cashoutmoney", 0);
		int[] r1;
		r1 = new int[17];
		for (int i = 1; i <= 16; i++)
			r1 [i] = i;
		PlayerPrefsX.SetIntArray ("r1", r1);
		PlayerPrefs.SetInt ("MyPlace", (int)Random.Range (1, 16.9f));
		PlayerPrefs.SetInt ("CurrentRound", 1);
		panel.gameObject.SetActive (false);
		Show ();
	}

	public void Play()
	{

	}
}
