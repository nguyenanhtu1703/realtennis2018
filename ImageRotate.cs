using UnityEngine;
using System.Collections;

public class ImageRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.rotation = Quaternion.Euler (new Vector3 (gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z + Time.deltaTime));
		gameObject.transform.Rotate(new Vector3(0, 0, -Time.deltaTime * 70));
	}
}
