using UnityEngine;
using System.Collections;

public class AdsUpdate : MonoBehaviour {

	// Use this for initialization
	public float thetimeupdate;
	public float delta;

	void Start () {
		delta = thetimeupdate - 20;
	}
	
	// Update is called once per frame
	void Update () {
		delta -= Time.deltaTime;
		if (delta <= 0) {
		//	if (PlayerPrefs.GetInt ("feeads") == 0)
		//		if(Random.Range(0, 10) > 5) AdmobVNTIS_Interstitial._showInterstitial ();
		}
		if (delta <= 0)
			delta = thetimeupdate;
	}
}
