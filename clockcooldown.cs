using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clockcooldown : MonoBehaviour {

	// Use this for initialization

	public float duration;
	public Text clock;
	public int level;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		duration = duration - Time.deltaTime;
		clock.text = System.Math.Round (duration, 0).ToString(); 
		clock.GetComponent<textanimationchange> ().starttextanimation ();
		if (duration < 0) {
			if (GameObject.Find ("GameManager").GetComponent<GameManager> ().fakeOnline == true) Application.LoadLevel (level);
			else Application.LoadLevel (9);
		}
	}
}
