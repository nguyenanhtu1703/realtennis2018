using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Datas : NetworkBehaviour{

	[SyncVar]
	public bool ClientReady, ServerReady, readyforprematch, matchreadyclient, matchreadyserver;

	bool entermatch;

	[SyncVar]
	public string p1name, p1country, p1mmr, p2name, p2country, p2mmr;

	public SyncListInt p1 = new SyncListInt(), p2 = new SyncListInt();

	public GameObject panel1, panel2;
	GameManager GM;
	SceneControllerOnline SC;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		GM = GameObject.Find ("GameManager").GetComponent<GameManager>();
		//SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnline>();
	}
	// Update is called once per frame
	void Update () {
		if (GM.isOnline == false || GM.fakeOnline == true)
			return;
		if (entermatch)
			return;
		if (matchreadyclient && matchreadyserver) {
			entermatch = true;
			GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>().ready();
		}
	}
	public void OnClientConnected(){
		
	}
}
