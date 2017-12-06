using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterCustomSceneController : MonoBehaviour {

	public Image sp, ac, str, flag;
	public GameObject Custom;
	CharacterCustom CCustom;
	GameManager GManager;
	public int st;
	public float at;
	// Use this for initialization
	void Start () {
		//flag.sprite = (Sprite)(Resources.Load ("flag-of-" + (country.text), typeof(Sprite)) as Sprite);
		at = Time.time;
		st = 1;
		CCustom = GameObject.Find ("CharacterCustom").GetComponent(typeof(CharacterCustom)) as CharacterCustom;
		GManager = GameObject.Find ("GameManager").GetComponent(typeof(GameManager)) as GameManager;
		for (int i = 1; i <= 29; i++) {
			Debug.Log (CCustom.nameItems [i - 1] + "_Player " + PlayerPrefs.GetInt ((CCustom.nameItems[i - 1] + "_Player")));
			CCustom.p1 [i - 1] = PlayerPrefs.GetInt (CCustom.nameItems[i - 1] + "_Player");
			PlayerPrefs.SetInt (CCustom.nameItems[i - 1], CCustom.p1[i - 1]);
		}
		CCustom.MakeCharacter (ref Custom);
		CCustom.Up (1);
		sp.transform.localScale = new Vector3(Mathf.Min (1, GManager.Player1_Speed / 100), sp.transform.localScale.y, sp.transform.localScale.z);
		ac.transform.localScale = new Vector3(Mathf.Min (1, GManager.Player1_Goal / 100), ac.transform.localScale.y, ac.transform.localScale.z);
		str.transform.localScale = new Vector3(Mathf.Min (1, GManager.Player1_Strong / 100), str.transform.localScale.y, str.transform.localScale.z);
		//Custom.GetComponent<Animator> ().Play ("Stand");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - at >= 5) {
			at = Time.time;
			if (st == 1 && Custom != null) {
				Custom.GetComponent<Animator> ().Play ("Angry3");
			} else {
				if (st == 2 && Custom != null) Custom.GetComponent<Animator> ().Play ("Fun 0");
				if (st == 3 && Custom != null) Custom.GetComponent<Animator> ().Play ("Fun2 0");
				if (st == 4 && Custom != null) Custom.GetComponent<Animator> ().Play ("Fun4");
				if (st == 5 && Custom != null) Custom.GetComponent<Animator> ().Play ("Fun4");
			}
		}
	}
}
