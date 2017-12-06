using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updatesprite : MonoBehaviour {

	// Use this for initialization

	public float howfast;
	public string name;
	float tmp;
	int last = 1;

	void Start () {
		tmp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		tmp = Time.deltaTime + tmp;
		if (tmp >= howfast) {
			tmp = 0;
			switch (last) {
			case 1:
				last = 2;
				break;
			case 2:
				last = 3;
				break;
			case 3:
				last = 1;
				break;
			}
			GetComponent<Image> ().sprite = Resources.Load (name + "_" + last.ToString(), typeof(Sprite)) as Sprite;
		}
	}
}
