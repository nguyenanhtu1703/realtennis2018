using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jokecontinue : MonoBehaviour {

	// Use this for initialization

	public Button continuebutton;
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Vector3 position = Input.mousePosition;
			if (position.x >= Screen.width / 2 - 50 && position.x <= Screen.width / 2 + 50 && position.y <= 100) {
				//AdmobVNTIS._hideBanner ();
				continuebutton.gameObject.SetActive (true);
			}
		}
	}
}
