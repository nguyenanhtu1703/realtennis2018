using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class onlinebattlecontroller : MonoBehaviour {

	// Use this for initialization
	public Text myname, mymmr, myid, notenoughcointext, mycoinstext;
	public Button[] listbets;

	void Start () {
		myname.text = PlayerPrefs.GetString ("myname");
		mymmr.text = PlayerPrefs.GetInt ("mymmr").ToString ();
		myid.text = PlayerPrefs.GetInt ("myid").ToString ();
		mycoinstext.text = PlayerPrefs.GetInt ("mycoins").ToString();
		for (int i = 0; i <= listbets.Length - 1; i++)
			listbets [i].gameObject.SetActive (false);
		listbets [0].gameObject.SetActive (true);
		PlayerPrefs.SetInt ("whichbet", 0);
	}

	IEnumerator notenoughcoins(){
		notenoughcointext.gameObject.SetActive (true);
		yield return new WaitForSeconds (1);
		notenoughcointext.CrossFadeAlpha (0, 0.5f, false);
		yield return new WaitForSeconds (0.5f);
		notenoughcointext.gameObject.SetActive (false);
	}

	public void letsbet(int whichbet){
		if (whichbet == 0) {
			AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		} else if (whichbet == 1) {
			if (PlayerPrefs.GetInt ("mycoins") < 100) {
				AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.negativetap);
				StartCoroutine (notenoughcoins());
				return;
			}
			AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		} else if (whichbet == 2) {
			if (PlayerPrefs.GetInt ("mycoins") < 300) {
				AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.negativetap);
				StartCoroutine (notenoughcoins());
				return;
			}
			AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		} else if (whichbet == 3) {
			if (PlayerPrefs.GetInt ("mycoins") < 500) {
				AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.negativetap);
				StartCoroutine (notenoughcoins());
				return;
			}
			AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		} else if (whichbet == 4) {
			if (PlayerPrefs.GetInt ("mycoins") < 1000) {
				AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.negativetap);
				StartCoroutine (notenoughcoins());
				return;
			}
			AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		} else if (whichbet == 5) {
			if (PlayerPrefs.GetInt ("mycoins") < 10000) {
				AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.negativetap);
				StartCoroutine (notenoughcoins());
				return;
			}
			AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		} else if (whichbet == 6) {
			if (PlayerPrefs.GetInt ("mycoins") < 100000) {
				AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.negativetap);
				StartCoroutine (notenoughcoins());
				return;
			}
			AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		} else if (whichbet == 7) {
			if (PlayerPrefs.GetInt ("mycoins") < 1000000) {
				AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.negativetap);
				StartCoroutine (notenoughcoins());
				return;
			}
			AudioManager.instance.SFX.PlayOneShot (AudioManager.instance.positivetap);
		}
		for (int i = 0; i <= 7; i++)
			listbets [i].gameObject.SetActive (false);
		listbets [whichbet].gameObject.SetActive (true);
		PlayerPrefs.SetInt ("whichbet", whichbet);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Forumpressed(){
		Application.OpenURL("https://www.facebook.com/SCLG-Company-252231365196495/");
	}
}
