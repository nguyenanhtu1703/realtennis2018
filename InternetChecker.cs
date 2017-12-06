using UnityEngine;
using System.Collections;

public class InternetChecker : MonoBehaviour {

	public static InternetChecker instance = null;

	public bool internet, isRunning;
	public float timedis, deltatime;

	IEnumerator checkInternetConnection(){
		if(isRunning == false){
			isRunning = true;
			WWW www = new WWW("http://google.com");
			yield return www;
			if (string.IsNullOrEmpty(www.error)) {
				internet = true;
			} else {
				if(internet == true){
					timedis = Time.time;
					internet = false;
				}
			}
			isRunning = false;
		}
	} 

	void Start(){
		DontDestroyOnLoad (this.gameObject);
		deltatime = 0;
		internet = true;
		StartCoroutine(checkInternetConnection());
	}

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy (this.gameObject);
		}
	}

	void Update () {
		deltatime += Time.deltaTime;
		if (deltatime >= 1f) {
			deltatime = 0;
			StartCoroutine (checkInternetConnection());
		}
	}
}
