using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	// Use this for initialization
	public static AudioManager instance = null;

	public AudioSource MUSIC, MUSIC2, CROWD, SFX, COMMENDTARY, INFO;
	public AudioClip background, crowd, cheer, positivetap, negativetap, turn, serve, score15_0, score15_15, score15_30, score15_40, score30_0, score30_15, score30_30, score30_40, score40_0, score40_15, score40_30, score40_40, score40_50, score50_40, let, score0_15, score0_30, score0_40, Out, game;
	public AudioClip bonussound;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if(instance != this){
			Destroy (this.gameObject);
		}	
	}

	void Start () {
		DontDestroyOnLoad (this.gameObject);
		AudioManager.instance.MUSIC.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
