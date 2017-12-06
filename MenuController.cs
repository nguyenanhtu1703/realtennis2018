using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	public Text coins, energy, level, pointlevel, myname, myinfo, time, mymoney, thetext;
	string mycountry;
	int currentpointlevel;
	public Image flag, p1speed, p1strong, p1goal, barlevel, nameset1, nameset2, energyempty1, energyempty2;
	public Slider music, sound;

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

	void musicvolumechanged(){
		AudioManager.instance.MUSIC.volume = music.value;
		AudioManager.instance.MUSIC2.volume = music.value;
		AudioManager.instance.CROWD.volume = music.value;
		AudioManager.instance.INFO.volume = music.value;
		PlayerPrefs.SetFloat ("musicvolume", music.value);
	}
		
	void soundvolumechanged(){
		AudioManager.instance.SFX.volume = sound.value;
		PlayerPrefs.SetFloat ("soundvolume", sound.value);
	}

	void Start () {
		AdMobBanner.instance.ShowBanner ();
		foreach (Transform ttt in GameObject.Find("Canvas").transform) if(ttt.name == "loev"){
				if(PlayerPrefs.GetInt ("loev") == 2)
					ttt.gameObject.SetActive(true);
		}
		if (PlayerPrefs.GetInt ("feeads") == 1) {
			thetext.gameObject.SetActive (false);
		} else thetext.gameObject.SetActive (false);
		//AdmobVNTIS._showBanner ();
		//AdmobVNTIS_Interstitial._showInterstitial();
		music.value = PlayerPrefs.GetFloat ("musicvolume");
		sound.value = PlayerPrefs.GetFloat ("soundvolume");
		music.onValueChanged.AddListener (delegate {
			musicvolumechanged();
		});
		sound.onValueChanged.AddListener (delegate {
			soundvolumechanged();
		});

		coins.text = PlayerPrefs.GetInt ("mycoins").ToString ();
		energy.text = PlayerPrefs.GetInt ("myenergy").ToString();
		if (PlayerPrefs.GetInt ("myenergy") <= 100) {
			//energyempty1.gameObject.SetActive (true);
			//energyempty1.gameObject.SetActive (true);
		}
		mymoney.text = formart(PlayerPrefs.GetInt ("mymoney"));
		myname.text = PlayerPrefs.GetString ("myname");
		mycountry = (PlayerPrefs.GetString ("mycountry"));
		if (myname.text == "" || mycountry == null) {
			nameset1.gameObject.SetActive (true);
			nameset2.gameObject.SetActive (true);
		}
		myinfo.text = PlayerPrefs.GetString ("myinfo");
		if (myinfo.text == "") {
			myinfo.text = "No info given.";
		}
		int myprofilelevel = PlayerPrefs.GetInt ("ProfileLevel");
		level.text = myprofilelevel.ToString();
		currentpointlevel = PlayerPrefs.GetInt ("currentpointlevel");
		int z;
		if (myprofilelevel == 0) {
			z = 100;
		} else if (myprofilelevel == 1) {
			z = 300;
		} else if (myprofilelevel == 2) {
			z = 500;
		} else if (myprofilelevel == 3) {
			z = 700;
		} else if (myprofilelevel == 4) {
			z = 900;
		} else z = 1200;
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent(typeof(GameManager)) as GameManager;
		CharacterCustom CCustom = GameObject.Find ("CharacterCustom").GetComponent(typeof(CharacterCustom)) as CharacterCustom;
		CCustom.Up (1);
		p1speed.transform.localScale = new Vector3 (Mathf.Min (1, GAMEMANAGER.Player1_Speed / 100), 1, 1);
		p1speed.transform.GetChild (0).transform.localScale = new Vector3 (1 / Mathf.Max (0.01f, p1speed.transform.localScale.x), 1, 1);
		p1goal.transform.localScale = new Vector3 (Mathf.Min (1, GAMEMANAGER.Player1_Goal / 100), 1, 1);
		p1goal.transform.GetChild (0).transform.localScale = new Vector3 (1 / Mathf.Max (0.01f, p1goal.transform.localScale.x), 1, 1);
		p1strong.transform.localScale = new Vector3 (Mathf.Min (1, GAMEMANAGER.Player1_Strong / 100), 1, 1);
		p1strong.transform.GetChild (0).transform.localScale = new Vector3 (1 / Mathf.Max (0.01f, p1strong.transform.localScale.x), 1, 1);

		pointlevel.text = currentpointlevel.ToString() + " / " + z.ToString();
		barlevel.transform.localScale = new Vector3 (currentpointlevel * 1.0f / z, 1, 1);
		if (mycountry != null) flag.sprite = (Sprite)(Resources.Load ("flag-of-" + (mycountry), typeof(Sprite)) as Sprite);
	}
	
	// Update is called once per frame
	void Update () {
		time.text = System.DateTime.Now.ToBinary().ToString();
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit ();
		}
	//	if (PlayerPrefs.GetInt ("myenergy") <= 100) {
	//		energyempty1.gameObject.SetActive (true);
	//		energyempty2.gameObject.SetActive (true);
	//	} else {
	//		energyempty1.gameObject.SetActive (false);
		//	energyempty2.gameObject.SetActive (false);
		//
		//}
	}
}
