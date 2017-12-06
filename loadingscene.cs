using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loadingscene : MonoBehaviour {

	// Use this for initialization
	public float time;
	void Start () {
		StartCoroutine ("loadingrun");
	}

	IEnumerator loadingrun(){
		yield return new WaitForSeconds (time);
		gameObject.GetComponent<Image> ().CrossFadeAlpha (0, 0.2f, true);
		gameObject.transform.GetChild (0).GetComponent<Text> ().CrossFadeAlpha (0, 0.2f, true);
		yield return new WaitForSeconds (0.2f);
		gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
