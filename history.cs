using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class history : MonoBehaviour {
	
	public Text ace, breakpoint, game, match, point, fastest, monney;
	// Use this for initialization
	void Start () {
		int tmp3 = PlayerPrefs.GetInt ("numberofmatches");
		int tmp4 = PlayerPrefs.GetInt ("numberofmatcheswon");
		match.text = System.Math.Round (tmp4 * 1.0 / tmp3, 2).ToString() + "% ( " + tmp4.ToString () + " / " + tmp3.ToString () + " ) ";


		tmp3 = PlayerPrefs.GetInt ("numberofgames");
		tmp4 = PlayerPrefs.GetInt ("numberofgameswon");
		game.text = System.Math.Round (tmp4 * 1.0 / tmp3, 2).ToString() + "% ( " + tmp4.ToString () + " / " + tmp3.ToString () + " ) ";

		tmp3 = PlayerPrefs.GetInt ("numberofpoints");
		tmp4 = PlayerPrefs.GetInt ("numberofpointswon");
		point.text = System.Math.Round (tmp4 * 1.0 / tmp3, 2).ToString() + "% ( " + tmp4.ToString () + " / " + tmp3.ToString () + " ) ";

		tmp3 = PlayerPrefs.GetInt ("numberofaces");
		ace.text = tmp3.ToString ();

		float tmp5 = PlayerPrefs.GetFloat ("thefastestspeed");
		fastest.text = tmp5.ToString ();

		tmp3 = PlayerPrefs.GetInt ("numberofbreakingpoint");
		tmp4 = PlayerPrefs.GetInt ("numberofbreakingpointwon");
		breakpoint.text = System.Math.Round (tmp4 * 1.0 / tmp3, 2).ToString() + "% ( " + tmp4.ToString () + " / " + tmp3.ToString () + " ) ";

		tmp3 = PlayerPrefs.GetInt ("moneyearned");
		monney.text = tmp3.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
