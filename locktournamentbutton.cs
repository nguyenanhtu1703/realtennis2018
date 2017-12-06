using UnityEngine;
using System.Collections;

public class locktournamentbutton : MonoBehaviour {

	// Use this for initialization

	public int whichbutton;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ((whichbutton - 1).ToString () + "won") == 0) {
			gameObject.SetActive (true);
		} else gameObject.SetActive (false);
	}
}
