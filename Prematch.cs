using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Prematch : MonoBehaviour {
	// Use this for initialization

	GameObject P1, P2;
	CharacterCustom CCustom;
	GameManager GManager;
	public Text texlvl, p1name, p2name, p1namecountry, p2namecountry, t1, t2, t3;
	bool no;
	public Image sp, ac, str, sp2, ac2, str2, p1country, p2country;

	int [ , ] bots = 
	{ { 0, 1, 2, 0, 2, 1, 0, 0, 2, 1, 1, 0, 3, 1, 3, 1, 3, 2, 12, 1, 11, 1, 1, 1, 1, 1, 5, 1, 5}
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

		//p2name.text = "Your Phone";
		p2namecountry.text = p1namecountry.text;
		p1country.sprite = (Sprite)(Resources.Load ("flag-of-" + (p1namecountry.text), typeof(Sprite)) as Sprite);

		GManager.Player2_Name = p2name.text;
		GManager.Player2_Country = p2namecountry.text;

		for (int i = 1; i <= 28; i++) {
			Debug.Log (CCustom.nameItems [i] + "_Player " + PlayerPrefs.GetInt ((CCustom.nameItems[i] + "_Player")));
			CCustom.p1 [i] = PlayerPrefs.GetInt (CCustom.nameItems[i] + "_Player");
			PlayerPrefs.SetInt (CCustom.nameItems[i], CCustom.p1[i]);
		}
		CCustom.MakeCharacter (ref P1);
		CCustom.Up (1);
		sp.transform.localScale = new Vector3(Mathf.Min (1, GManager.Player1_Speed / 100), sp.transform.localScale.y, sp.transform.localScale.z);
		ac.transform.localScale = new Vector3(Mathf.Min (1, GManager.Player1_Goal / 100), ac.transform.localScale.y, ac.transform.localScale.z);
		str.transform.localScale = new Vector3(Mathf.Min (1, GManager.Player1_Strong / 100), str.transform.localScale.y, str.transform.localScale.z);
		P1.transform.position = new Vector3 (-500f, 0, 0);
		P1.transform.rotation = Quaternion.LookRotation (Vector3.back);
		GManager.Player1CurrentCharacter = P1;
		DontDestroyOnLoad (P1);

		//PlayerPrefs.SetInt ("BotsLevel", 0);
		int lb = PlayerPrefs.GetInt ("BotsLevel");
		if (lb <= 0) {
			lb = 1;
			//return;
		}
		if (lb >= 61) {
			lb = 60;
			//return;
		}
		texlvl.text = "Level " + lb.ToString ();
		AdjustBonnus ();
		PlayerPrefs.SetInt ("BotsLevel", lb);
		no = true;
		Adjust (0);
	}

	public void Adjust(int z){
		int lb = PlayerPrefs.GetInt ("BotsLevel");
		if (no == false) {
			AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		}
		lb = lb + z;
		if (lb == 0) {
			lb = 1;
			return;
		}
		if (lb == 61) {
			lb = 60;
			return;
		}

		int st, sp, go;
		st = sp = go = 0;
		starts (lb, ref sp, ref go, ref st);

		GManager.Player2_Goal = go;
		GManager.Player2_Speed = sp;
		GManager.Player2_Strong = st;
		sp2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Speed / 100), sp2.transform.localScale.y, sp2.transform.localScale.z);
		ac2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Goal / 100), ac2.transform.localScale.y, ac2.transform.localScale.z);
		str2.transform.localScale = new Vector3 (Mathf.Min (1, GManager.Player2_Strong / 100), str2.transform.localScale.y, str2.transform.localScale.z);
		if (P2 != null)
			Destroy (P2);
		for (int i = 2; i <= 29; i++) {
			CCustom.p2[i - 1] = bots [0, i - 1];
		//	Debug.Log(i + ",  " + )
			PlayerPrefs.SetInt (CCustom.nameItems [i - 1], CCustom.p2 [i - 1]);
		}
		Debug.Log (PlayerPrefs.GetInt("ColorShirt"));
		CCustom.MakeCharacter (ref P2);
		P2.transform.position = new Vector3 (500f, 0, 0);
		GManager.Player2CurrentCharacter = P2;
		DontDestroyOnLoad (P2);
		P2.transform.rotation = Quaternion.LookRotation (Vector3.back);
		StartCoroutine (changelevel(lb));

		PlayerPrefs.SetInt ("BotsLevel", lb);
	}

	IEnumerator changelevel(int lb){
		if (no == false) {
			texlvl.CrossFadeAlpha (0, 0.17f, false);
			p2name.CrossFadeAlpha (0, 0.17f, false);
			t1.CrossFadeAlpha(0, 0.17f, false);
			t2.CrossFadeAlpha(0, 0.17f, false);
			t3.CrossFadeAlpha(0, 0.17f, false);
		}
		yield return new WaitForSeconds (0.17f);
		texlvl.CrossFadeAlpha (1, 0, false);
		t1.CrossFadeAlpha(1, 0, false);
		t2.CrossFadeAlpha(1, 0, false);
		t3.CrossFadeAlpha(1, 0, false);
		if(no == false) p2name.CrossFadeAlpha (1, 0, false);
		AdjustBonnus ();
		texlvl.text = "Level " + lb.ToString ();
		p2name.text = "Bot " + texlvl.text;
		//texlvl.text = "Level " + lb.ToString () + " / 60";
		GManager.Player2_Name = "Bot " + texlvl.text;
		no = false;
	}

	void AdjustBonnus(){
		int lb = PlayerPrefs.GetInt ("BotsLevel");
		int qmg, qme;
		t2.text = "+ " + (lb * 2).ToString() + " coins"+ ",";
		t3.text = " + " + (100 * lb).ToString () + " exp";
		if (100 * lb >= 1200) {
			if (100 * lb >= 2400)
				t3.text += " ( ~ " + ((int)(100 * lb / 1200)).ToString () + " levels )";
			else
				t3.text += " ( ~ " + ((int)(100 * lb / 1200)).ToString () + " level )";
		}
		PlayerPrefs.SetInt ("qmg", lb * 2);
		PlayerPrefs.SetInt ("qme", lb * 100);
	}

	public void starts(int level, ref  int speed, ref int goal, ref int strong){
		switch (level) {
		case 1:
			speed = 0;
			goal = 0;
			strong = 5;
			break;
		case 2:
			speed = 5;
			goal = 0;
			strong = 5;
			break;
		case 3:
			speed = 5;
			goal = 5;
			strong = 5;
			break;
		case 4:
			speed = 5;
			goal = 10;
			strong = 5;
			break;
		case 5:
			speed = 10;
			goal = 10;
			strong = 5;
			break;
		case 6:
			speed = 10;
			goal = 10;
			strong = 10;
			break;
		case 7:
			speed = 15;
			goal = 5;
			strong = 15;
			break;
		case 8:
			speed = 20;
			goal = 5;
			strong = 15;
			break;
		case 9:
			speed = 5;
			goal = 15;
			strong = 25;
			break;
		case 10:
			speed = 10;
			goal = 0;
			strong = 40;
			break;
		case 11:
			speed = 15;
			goal = 20;
			strong = 20;
			break;
		case 12:
			speed = 20;
			goal = 0;
			strong = 40;
			break;
		case 13:
			speed = 10;
			goal = 0;
			strong = 55;
			break;
		case 14:
			speed = 5;
			goal = 0;
			strong = 65;
			break;
		case 15:
			speed = 35;
			goal = 20;
			strong = 20;
			break;
		case 16:
			speed = 40;
			goal = 0;
			strong = 40;
			break;
		case 17:
			speed = 10;
			goal = 65;
			strong = 10;
			break;
		case 18:
			speed = 30;
			goal = 30;
			strong = 30;
			break;
		case 19:
			speed = 35;
			goal = 35;
			strong = 25;
			break;
		case 20:
			speed = 35;
			goal = 0;
			strong = 65;
			break;
		case 21:
			speed = 35;
			goal = 35;
			strong = 35;
			break;
		case 22:
			speed = 20;
			goal = 40;
			strong = 50;
			break;
		case 23:
			speed = 50;
			goal = 0;
			strong = 65;
			break;
		case 24:
			speed = 0;
			goal = 50;
			strong = 70;
			break;
		case 25:
			speed = 70;
			goal = 0;
			strong = 55;
			break;
		case 26:
			speed = 30;
			goal = 40;
			strong = 60;
			break;
		case 27:
			speed = 35;
			goal = 75;
			strong = 25;
			break;
		case 28:
			speed = 50;
			goal = 60;
			strong = 30;
			break;
		case 29:
			speed = 45;
			goal = 50;
			strong = 50;
			break;
		case 30:
			speed = 50;
			goal = 50;
			strong = 50;
			break;
		case 31:
			speed = 25;
			goal = 30;
			strong = 100;
			break;
		case 32:
			speed = 35;
			goal = 65;
			strong = 60;
			break;
		case 33:
			speed = 65;
			goal = 50;
			strong = 50;
			break;
		case 34:
			speed = 70;
			goal = 50;
			strong = 50;
			break;
		case 35:
			speed = 55;
			goal = 40;
			strong = 80;
			break;
		case 36:
			speed = 60;
			goal = 60;
			strong = 60;
			break;
		case 37:
			speed = 40;
			goal = 60;
			strong = 85;
			break;
		case 38:
			speed = 60;
			goal = 70;
			strong = 60;
			break;
		case 39:
			speed = 65;
			goal = 65;
			strong = 75;
			break;
		case 40:
			speed = 80;
			goal = 80;
			strong = 40;
			break;
		case 41:
			speed = 85;
			goal = 80;
			strong = 40;
			break;
		case 42:
			speed = 60;
			goal = 100;
			strong = 50;
			break;
		case 43:
			speed = 65;
			goal = 80;
			strong = 70;
			break;
		case 44:
			speed = 70;
			goal = 80;
			strong = 70;
			break;
		case 45:
			speed = 85;
			goal = 70;
			strong = 70;
			break;
		case 46:
			speed = 70;
			goal = 90;
			strong = 70;
			break;
		case 47:
			speed = 95;
			goal = 75;
			strong = 65;
			break;
		case 48:
			speed = 75;
			goal = 65;
			strong = 100;
			break;
		case 49:
			speed = 75;
			goal = 100;
			strong = 70;
			break;
		case 50:
			speed = 80;
			goal = 100;
			strong = 70;
			break;
		case 51:
			speed = 85;
			goal = 80;
			strong = 90;
			break;
		case 52:
			speed = 90;
			goal = 80;
			strong = 90;
			break;
		case 53:
			speed = 95;
			goal = 80;
			strong = 90;
			break;
		case 54:
			speed = 85;
			goal = 90;
			strong = 95;
			break;
		case 55:
			speed = 90;
			goal = 95;
			strong = 90;
			break;
		case 56:
			speed = 100;
			goal = 85;
			strong = 95;
			break;
		case 57:
			speed = 100;
			goal = 85;
			strong = 100;
			break;
		case 58:
			speed = 95;
			goal = 100;
			strong = 95;
			break;
		case 59:
			speed = 100;
			goal = 100;
			strong = 95;
			break;
		case 60:
			speed = 100;
			goal = 100;
			strong = 100;
			break;
		default:
			speed = 100;
			goal = 100;
			strong = 100;
			break;
		}
	}

	// Update is called once per frame


	void Update () {
		
	}
}
