using UnityEngine;
using System.Collections;

public class findplayer : MonoBehaviour {

	// Use this for initialization
	public int whichplayer;

	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3((GameObject.FindGameObjectsWithTag ("Player")) [whichplayer + 2].gameObject.transform.position.x, 0.01f, (GameObject.FindGameObjectsWithTag ("Player")) [whichplayer + 2].gameObject.transform.position.z);
	}
}
