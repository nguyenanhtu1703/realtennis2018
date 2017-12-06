using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movingpanel : MonoBehaviour {

	// Use this for initialization
	public int type;
	public float afterhowlong, tmp, clock, duration;
	public bool run;
	Vector3 origin, start;

	void Awake(){
		origin = transform.position;
		tmp = 0;
		clock = 0;
	}

//	IEnumerator Runfade(){
		
///	}

	void Start () {
		if (type == 1) {
			start = new Vector3 (0 - transform.gameObject.GetComponent<RectTransform> ().rect.width / 2 - 60, origin.y, 0);
			transform.position = start;
		} else if (type == 2) {
			start = new Vector3 (Screen.width + transform.gameObject.GetComponent<RectTransform> ().rect.width / 2 + 30, origin.y, 0);
			transform.position = start;
		} else if (type == 3) {
			gameObject.GetComponent<Text> ().CrossFadeAlpha (0, 0, true);
		} else if (type == 4) {
			gameObject.GetComponent<Image> ().CrossFadeAlpha (0, 0, true);
		}
	}
	// Update is called once per frame
	void Update () {
		if (run == true) {
			clock += Time.deltaTime;
			if (type == 1) {
				transform.position = new Vector3 (Mathf.Lerp (start.x, origin.x, clock / duration), origin.y, 0);
			} 
			if (type == 2) {
				transform.position = new Vector3 (Mathf.Lerp (start.x, origin.x, clock / duration), origin.y, 0);
			}
		}
		if (tmp == -1)
			return;
		tmp += Time.deltaTime;
		if(tmp >= afterhowlong){
			tmp = -1;
			clock = 0;
			run = true;
			if (type == 3) {
				gameObject.GetComponent<Text> ().CrossFadeAlpha (1, duration, true);
			}
			if (type == 4) {
				gameObject.GetComponent<Image> ().CrossFadeAlpha (1, duration, true);
			}
		}
	}
}
