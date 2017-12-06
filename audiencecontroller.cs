using UnityEngine;
using System.Collections;

public class audiencecontroller : MonoBehaviour {

	public GameObject c1, c2, c3, t1, t2, t3, t4, audience, audience_1, audience_2;

	SceneController GM;
	SceneControllerOnlineFinal GM2;
	GameManager G;
	GameObject c;
	// Use this for initialization
	void Start () {
		G = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		if(G.isOnline == false || G.fakeOnline == true) GM = GameObject.Find ("SceneController").GetComponent<SceneController>();
		else GM2 = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		if (c1.activeInHierarchy == true)
			c = c1;
		if (c2.activeInHierarchy == true)
			c = c2;
		if (c3.activeInHierarchy == true)
			c = c3;
		foreach (Transform t in audience.transform) {
			if (t.GetChild (0).GetComponent<MeshFilter> () == null)
				continue;
			GameObject z = (GameObject)Instantiate (t.gameObject, t.transform.position, t.transform.rotation);
			z.transform.parent = audience_1.transform;
			int zx = Random.Range (1, 100);
			if (zx <= 25) {
				z.transform.GetChild(0).GetComponent<MeshFilter>().mesh = t1.transform.GetChild(0).GetComponent<MeshFilter>().mesh;	
				GameObject k = (GameObject)Instantiate (t.gameObject, t.transform.position, t.transform.rotation);
				k.transform.GetChild(0).GetComponent<MeshFilter>().mesh = t2.transform.GetChild(0).GetComponent<MeshFilter>().mesh;	
				k.transform.parent = audience_2.transform;
			} else if (zx <= 50) {
				z.transform.GetChild(0).GetComponent<MeshFilter>().mesh = t2.transform.GetChild(0).GetComponent<MeshFilter>().mesh;	
				GameObject k = (GameObject)Instantiate (t.gameObject, t.transform.position, t.transform.rotation);
				k.transform.GetChild(0).GetComponent<MeshFilter>().mesh = t1.transform.GetChild(0).GetComponent<MeshFilter>().mesh;	
				k.transform.parent = audience_2.transform;
			} else if (zx <= 75) {
				z.transform.GetChild(0).GetComponent<MeshFilter>().mesh = t3.transform.GetChild(0).GetComponent<MeshFilter>().mesh;	
				GameObject k = (GameObject)Instantiate (t.gameObject, t.transform.position, t.transform.rotation);
				k.transform.GetChild(0).GetComponent<MeshFilter>().mesh = t4.transform.GetChild(0).GetComponent<MeshFilter>().mesh;	
				k.transform.parent = audience_2.transform;
			} else {
				z.transform.GetChild(0).GetComponent<MeshFilter>().mesh = t4.transform.GetChild(0).GetComponent<MeshFilter>().mesh;	
				GameObject k = (GameObject)Instantiate (t.gameObject, t.transform.position, t.transform.rotation);
				k.transform.GetChild(0).GetComponent<MeshFilter>().mesh = t3.transform.GetChild(0).GetComponent<MeshFilter>().mesh;	
				k.transform.parent = audience_2.transform;
			}
		}
		if (G.typeOfCourt == 1) {
			foreach (Transform t in audience.transform) {
				if (t.gameObject.transform.position.z > 20f || t.gameObject.transform.position.z < -18f) {
					Destroy (t.gameObject);
					Debug.Log (1);
				}
			}
			foreach (Transform t in audience_1.transform) {
				if (t.gameObject.transform.position.z > 20f || t.gameObject.transform.position.z < -18f) {
					Destroy (t.gameObject);
					Debug.Log (1);
				}
			}
			foreach (Transform t in audience_2.transform) {
				if (t.gameObject.transform.position.z > 20f || t.gameObject.transform.position.z < -18f) {
					Destroy (t.gameObject);
					Debug.Log (1);
				}
			}
		}
	}

	public void delete()
	{
		foreach (Transform t in audience.transform) {
			if (t.tag != "Audience") {
				Destroy (t.gameObject);
			}
		}
		foreach (Transform t in audience_1.transform) {
			if (t.tag != "Audience") {
				Destroy (t.gameObject);
			}
		}
		foreach (Transform t in audience_2.transform) {
			if (t.tag != "Audience") {
				Destroy (t.gameObject);
			}
		}
		if (c1.activeInHierarchy == true)
			c = c1;
		if (c2.activeInHierarchy == true)
			c = c2;
		if (c3.activeInHierarchy == true)
			c = c3;
		foreach(Transform t in c.transform){
			if (t.tag == "Stadium") {
				Destroy (t.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (G.isOnline == false || G.fakeOnline == true) {
			if (GM.audience == false) return;
		} else if (GM2.audience == false) {
			return;
		}
		foreach (Transform t in transform) {
			t.gameObject.SetActive (false);
		}
		foreach (Transform t in transform) {
			if (Time.time - (int)Time.time <= .1f) {
				if (t.name == "audience_1") t.gameObject.SetActive (true);
			} else if (Time.time - (int)Time.time <= .2) {
				if (t.name == "audience_2" ) t.gameObject.SetActive (true);
			} else if (Time.time - (int)Time.time <= .3f) {
				if (t.name == "audience_1") t.gameObject.SetActive (true);
			} else if (Time.time - (int)Time.time <= .4f) {
				if (t.name == "audience_2") t.gameObject.SetActive (true);
			} else if (Time.time - (int)Time.time <= .5f) {
				if (t.name == "audience_1") t.gameObject.SetActive (true);
			} else if (Time.time - (int)Time.time <= .6f) {
				if (t.name == "audience_2") t.gameObject.SetActive (true);
			} else if (Time.time - (int)Time.time <= .7f) {
				if (t.name == "audience_1") t.gameObject.SetActive (true);
			} else if (Time.time - (int)Time.time <= .8f) {
				if (t.name == "audience_2") t.gameObject.SetActive (true);
			} else if (Time.time - (int)Time.time <= .9f) {
				if (t.name == "audience_1") t.gameObject.SetActive (true);
			} else if (Time.time - (int)Time.time <= 1f) {
				if (t.name == "audience_2") t.gameObject.SetActive (true);
			}

		}
	}
}
