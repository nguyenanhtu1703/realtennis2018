using UnityEngine;
using System.Collections;

public class leveltounlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("ProfileLevel") >= 0) {
			gameObject.SetActive (false);
		} else {
			gameObject.SetActive (true);
		}
	}
}
