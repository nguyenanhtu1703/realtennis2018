using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CharacterSpawner : NetworkBehaviour {

	// Use this for initialization

	GameObject mycharacter;
	CharacterCustom CCustom;
	GameManager GManager;


	void Start () {
		CCustom = GameObject.Find ("CharacterCustom").GetComponent(typeof(CharacterCustom)) as CharacterCustom;
		GManager = GameObject.Find ("GameManager").GetComponent(typeof(GameManager)) as GameManager;
		for (int i = 1; i <= 29; i++) {
			CCustom.p1 [i - 1] = PlayerPrefs.GetInt (CCustom.nameItems[i - 1] + "_Player");
			PlayerPrefs.SetInt (CCustom.nameItems[i - 1], CCustom.p1[i - 1]);
		}
		CCustom.MakeCharacter (ref mycharacter);
		CCustom.Up (1);
	}

	public void OnStartClient()
	{
		Debug.Log ("Yeah");
		ClientScene.RegisterPrefab(mycharacter);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
