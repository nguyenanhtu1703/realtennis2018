using UnityEngine;
using System.Collections;

public class textanimationchange : MonoBehaviour {

	// Use this for initialization

	public bool isRunning = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void starttextanimation(){
		if (isRunning == false) {
			isRunning = true;
			StartCoroutine ("textanimation");
		}
	}

	IEnumerator textanimation()
	{
		for (int i = 1; i <= 5; i++) {
			transform.localScale = new Vector3 (transform.localScale.x * 1.1f, transform.localScale.y * 1.1f, transform.localScale.z * 1.1f);
			yield return new WaitForSeconds (0.06f);
		}	
		for (int i = 1; i <= 5; i++) {
			transform.localScale = new Vector3 (transform.localScale.x / 1.1f, transform.localScale.y / 1.1f, transform.localScale.z / 1.1f);
			yield return new WaitForSeconds (0.06f);
		}	
		isRunning = false;
	}
}
