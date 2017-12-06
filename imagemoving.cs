using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class imagemoving : MonoBehaviour {

	// Use this for initialization
	public GameObject canvas;
	public Image ima1;
	bool did;
	public int type, x, y, w, h;
	public Vector3 origin;
	float tmpx, tmpy; 
	float tmp;

	void Start () {
		origin = transform.position;
		if (type == 1) {
			tmpx = 1;
			tmpy = 1;
			if (w > 0)
				x = 1;
			else
				x = -1;
			if (h > 0)
				y = 1;
			else
				y = -1;
			
		}
		if (type == 2) tmp = 0.04f;
		if (type == 3) {
				tmpx = 5.5f;
				tmpy = 5.5f;
				if (w > 0)
					x = 1;
				else
					x = -1;
				if (h > 0)
					y = 1;
				else
					y = -1;
		}
		did = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (type == 1) {
			transform.position = new Vector3 (transform.position.x + tmpx * x, transform.position.y + tmpy * y, transform.position.z);
			if (Mathf.Abs(-transform.position.x + w + origin.x) < 1e5 && did == false) {
				Image tmptmp = (Image) Instantiate (ima1, new Vector3(transform.position.x + 70 * x, transform.position.y + 70 * y, transform.position.z), Quaternion.identity);
				tmptmp.gameObject.transform.SetParent (canvas.transform);
				tmptmp.CrossFadeAlpha (0, 0.5f, false);
				did = true;
				tmpx = 1;
				tmpy = 1;
			}
			if (x > 0 && transform.position.x > w + 10 + origin.x) {
				transform.position = origin;
				did = false;
			}
			if (x < 0 && transform.position.x < w + 10 + origin.x) {
				transform.position = origin;
				did = false;
			}
		}
		if (type == 2) {
			transform.localScale = new Vector3 (transform.localScale.x + tmp, transform.localScale.y + tmp, 1);
			//transform.gameObject.GetComponent<Image> ().color.a -= 0.05f;
			tmp -= 0.0005f;
			if (transform.localScale.x > 1.75f) {
				Destroy (transform.gameObject);
				tmp = 0.04f;
				return;
				transform.localScale = new Vector3 (1, 1, 1);
			}
		}
		if (type == 3) {
			transform.position = new Vector3 (transform.position.x + tmpx * x, transform.position.y + tmpy * y, transform.position.z);
			if (Mathf.Abs(-transform.position.x + w + origin.x) < 1e5 && did == false) {
				Image tmptmp = (Image) Instantiate (ima1, new Vector3(transform.position.x + 150 * x, transform.position.y + 150 * y, transform.position.z), Quaternion.identity);
				tmptmp.gameObject.transform.SetParent (canvas.transform);
				tmptmp.CrossFadeAlpha (0, 0.5f, false);
				did = true;
				tmpx = 5.5f;
				tmpy = 5.5f;
			}
			if (x > 0 && transform.position.x > w + 20 + origin.x) {
				transform.position = origin;
				did = false;
			}
			if (x < 0 && transform.position.x < w + 20 + origin.x) {
				transform.position = origin;
				did = false;
			}
		}
		if (type == 4) {
			transform.position = new Vector3 (transform.position.x + tmpx * x, transform.position.y + tmpy * y, transform.position.z);
		/*	if (Mathf.Abs(-transform.position.x + w + origin.x) < 1e5 && did == false) {
				Image tmptmp = (Image) Instantiate (ima1, new Vector3(transform.position.x + 150 * x, transform.position.y + 150 * y, transform.position.z), Quaternion.identity);
				tmptmp.gameObject.transform.SetParent (canvas.transform);
				tmptmp.CrossFadeAlpha (0, 0.5f, false);
				did = true;
				tmpx = 2.5f;
				tmpy = 2.5f;
			}*/
			if (x > 0 && transform.position.x > w + 20 + origin.x) {
				transform.position = origin;
				did = false;
			}
			if (x < 0 && transform.position.x < w + 20 + origin.x) {
				transform.position = origin;
				did = false;
			}
		}
		if (type == 5) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + tmpy * y, transform.position.z);
			/*	if (Mathf.Abs(-transform.position.x + w + origin.x) < 1e5 && did == false) {
				Image tmptmp = (Image) Instantiate (ima1, new Vector3(transform.position.x + 150 * x, transform.position.y + 150 * y, transform.position.z), Quaternion.identity);
				tmptmp.gameObject.transform.SetParent (canvas.transform);
				tmptmp.CrossFadeAlpha (0, 0.5f, false);
				did = true;
				tmpx = 2.5f;
				tmpy = 2.5f;
			}*/
			if (y > 0 && transform.position.y > h + 20 + origin.y) {
				transform.position = origin;
				did = false;
			}
			if (x < 0 && transform.position.x < w + 20 + origin.x) {
				transform.position = origin;
				did = false;
			}
		}

		if (type == 6) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + tmpy * y, transform.position.z);
			/*	if (Mathf.Abs(-transform.position.x + w + origin.x) < 1e5 && did == false) {
				Image tmptmp = (Image) Instantiate (ima1, new Vector3(transform.position.x + 150 * x, transform.position.y + 150 * y, transform.position.z), Quaternion.identity);
				tmptmp.gameObject.transform.SetParent (canvas.transform);
				tmptmp.CrossFadeAlpha (0, 0.5f, false);
				did = true;
				tmpx = 2.5f;
				tmpy = 2.5f;
			}*/
			if (y < 0 && transform.position.y < - h - 20 + origin.y) {
				transform.position = origin;
				did = false;
			}
			if (x < 0 && transform.position.x < w + 20 + origin.x) {
				transform.position = origin;
				did = false;
			}
		}
	}
}
