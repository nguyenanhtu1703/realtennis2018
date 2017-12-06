using UnityEngine;
using System.Collections;

public class SpeedBoard : MonoBehaviour {

	public float time;
	Vector3 origin;
	bool start, move;
	// Use this for initialization
	void Start () {
		time = 0;
		origin = transform.position;
		start = move = false;
	}

	IEnumerator letswait(){
		yield return new WaitForSeconds (0.7f);
		move = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (time <= Time.time) {
			if (move) {
				transform.position = new Vector3 (transform.position.x + 20, transform.position.y, transform.position.z);
			}
			if (start == false) {
				StartCoroutine ("letswait");	
				start = true;
			}
			return;
		}
		start = move = false;
		transform.position = origin;
		gameObject.transform.localScale = new Vector3 ((0.5f - Mathf.Max(0, time - Time.time)) * 2, 1, 1);
	}


}
