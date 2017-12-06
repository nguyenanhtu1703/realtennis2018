using UnityEngine;
using System.Collections;

public class Url : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void voteclicked(){
		Application.OpenURL ("market://details?id=com.SCLG.realtennis2017nguyenanhtu");
	}

	public void link01game(){
		Application.OpenURL ("market://details?id=om.the01game.earnrealmoneygameappshope");
	}

	public void freakingbird(){

		Application.OpenURL ("market://details?id=com.sclgcompany.flappybird2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
