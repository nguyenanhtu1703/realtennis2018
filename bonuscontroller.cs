using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bonuscontroller: MonoBehaviour {

	// Use this for initialization
	public int bonus;

	public Text pointleveltext, bonusexp, leveltext, bonuscoinstext; 
	public Image barlevel;
	public int currentpoint, level, levelpoint, bonuscoins;
	public Button closebutton;

	public void Start2() {
		Time.timeScale = 1;
		bonus = PlayerPrefs.GetInt ("bonusexp");
		bonuscoins = PlayerPrefs.GetInt ("bonuscoins");
		GameManager tmp = GameObject.Find ("GameManager").GetComponent<GameManager>();
		int z = 0;

		if (tmp.isOnline == false) bonuscoinstext.text = " + " + bonuscoins.ToString ();
		else bonuscoinstext.text = " + " + bonuscoins.ToString () + " ( " + z.ToString() + " from bet" + " )";
		if (bonuscoins < 0) bonuscoinstext.text = bonuscoins.ToString ();
		level = PlayerPrefs.GetInt("ProfileLevel");
		leveltext.text = level.ToString ();
		Derpointlevel (level, ref levelpoint);
		currentpoint = PlayerPrefs.GetInt ("currentpointlevel");
		bonusexp.text = " + " + bonus.ToString ();
		barlevel.transform.localScale = new Vector3 (currentpoint  * 1.0f / levelpoint, 1f, 1f);
		StartCoroutine ("runbar");
	}

	// Update is called once per frame
	void Update () {
	}

	public void close(){
		Time.timeScale = 1;
		AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.negativetap);
		Application.LoadLevel (10);
	}

	IEnumerator runbar()
	{
		int time = 50;
		int tmp = PlayerPrefs.GetInt ("mycoins");
		tmp += bonuscoins;
		PlayerPrefs.SetInt ("mycoins", tmp);
		if (bonus == 0) {
			closebutton.gameObject.SetActive (true);
		}
		float per2 = bonus * 1.0f / time, currentpoint2 = currentpoint;
		for (int i = 1; i <= 50; i++) {
			currentpoint2 += per2;
			currentpoint = (int) currentpoint2;
			if (currentpoint >= levelpoint) {
				currentpoint -= levelpoint;
				currentpoint2 -= levelpoint;
				level++;
				leveltext.text = level.ToString ();
				leveltext.GetComponent<textanimationchange> ().starttextanimation ();
				Derpointlevel (level, ref levelpoint);
			}
			barlevel.transform.localScale = new Vector3 (currentpoint  * 1.0f / levelpoint, 1f, 1f);
			pointleveltext.text = currentpoint.ToString() + " / " + levelpoint.ToString ();
			yield return new WaitForSeconds (0.01f);
		}
		closebutton.gameObject.SetActive (true);
		PlayerPrefs.SetInt ("currentpointlevel", currentpoint);
		PlayerPrefs.SetInt("ProfileLevel", level);
		PlayerPrefs.Save ();
		PlayerPrefs.SetInt ("bonusexp", 0);
	}

	void Derpointlevel(int myprofilelevel, ref int tmp){
		if (myprofilelevel == 0) {
			tmp = 100;
		} else if (myprofilelevel == 1) {
			tmp = 300;
		} else if (myprofilelevel == 2) {
			tmp = 500;
		} else if (myprofilelevel == 3) {
			tmp = 700;
		} else if (myprofilelevel == 4) {
			tmp = 900;
		} else tmp = 1200;
	}
}
