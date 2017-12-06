using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InterfaceDatas : NetworkBehaviour {

	Datas datas;
	//public static float yCollision;
	SceneControllerOnlineFinal SC;
	bool up;
	public bool iamlocalplayer;

	void Awake(){
		
		DontDestroyOnLoad (this.gameObject);
	}

	void Start () {
		up = false;
		if (isLocalPlayer)
			iamlocalplayer = true;
		else
			iamlocalplayer = false;
	}

	[Command]
	public void CmdUpdate(){
		if (isServer == false)
			return;
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		SC.timedidupdate = Time.time;
	}

	[Command]
	public void CmdUpdate2(){
		RpcUpdate2 ();
	}

	[ClientRpc]
	public void RpcUpdate2()
	{
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (isServer == true)
			return;
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		SC.timedidupdate = Time.time;
	}

	[Command]
	public void Cmdmatchreadyclient(){
		GameObject.Find ("Datas").GetComponent<Datas> ().matchreadyclient = true;
	}

	// Update is called once per frame
	void Update () {
		if (datas != null && datas.ServerReady && datas.ClientReady)
			return;
		if (ClientScene.ready) {
			if (GameObject.Find ("Datas") != null && GameObject.Find("Datas").gameObject.activeInHierarchy) {
				datas = GameObject.Find ("Datas").GetComponent<Datas> ();
			}
		}
		if (isLocalPlayer) {
			if (isServer) {
				if (ClientScene.ready == true && datas != null && datas.ServerReady == false) {
					GameManager GManager = GameObject.Find ("GameManager").GetComponent(typeof(GameManager)) as GameManager;
					GManager.WhoIAm = 1;
					datas.ServerReady = true;
					datas.p1name = PlayerPrefs.GetString ("myname");
					datas.p1country = PlayerPrefs.GetString ("mycountry");
					CharacterCustom CCustom = GameObject.Find ("CharacterCustom").GetComponent(typeof(CharacterCustom)) as CharacterCustom;
					for (int i = 1; i <= 29; i++) {
						datas.p1.Add(PlayerPrefs.GetInt (CCustom.nameItems[i - 1] + "_Player"));
					}
				}
			} else {
				if (ClientScene.ready == true && datas != null && datas.ClientReady == false && up == false) {
					GameManager GManager = GameObject.Find ("GameManager").GetComponent(typeof(GameManager)) as GameManager;
					GManager.WhoIAm = 2;
					up = true;
					CharacterCustom CCustom = GameObject.Find ("CharacterCustom").GetComponent(typeof(CharacterCustom)) as CharacterCustom;
					int[] t =  new int[29];
					for (int i = 1; i <= 29; i++) {
						t[i - 1] = PlayerPrefs.GetInt (CCustom.nameItems[i - 1] + "_Player");
					}
					Cmdp2inforjoined (PlayerPrefs.GetString ("myname"), PlayerPrefs.GetString ("mycountry"), t);
				}
			}
		}
	}

	[ClientRpc]
	public void Rpcwin1(){
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (SC.ANIMATEDWON == false) return;
		SC.audience = true;
		if (SC.Player1HittingTurn)
			SC.persionisgonnatowin = 2;
		else
			SC.persionisgonnatowin = 1;
		AudioManager.instance.MUSIC.PlayOneShot (AudioManager.instance.cheer);
		SC.showmessagebutton ();
		if (SC.Player1HittingTurn) {

			if (SC.isServe) {
				GAMEMANAGER.p2acecount++;
			}
			if (Random.Range (0, 10) >= 5)
				SC.PLAYER2.GetComponent<Animator> ().Play ("Fun");
			else
				SC.PLAYER2.GetComponent<Animator> ().Play ("Fun2");	
			SC.PLAYER1.GetComponent<Animator> ().Play ("Idle");
			SC.PLAYER1.GetComponent<Animator> ().SetFloat ("Speed", 0);
			if (Random.Range (0, 10) >= 5)
				SC.PLAYER1.GetComponent<Animator> ().Play ("Angry2");
			else if (Random.Range (0, 10) >= 5)
				SC.PLAYER1.GetComponent<Animator> ().Play ("Angry");
			SC.PLAYER1.transform.rotation = Quaternion.LookRotation (Vector3.forward);
		}
	}

	[ClientRpc]
	public void Rpcwin1_1(){
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (GAMEMANAGER.WhoIAm == 2)
			return;
		if (SC.ANIMATEDWON == false) return;
		SC.audience = true;
		if (SC.Player1HittingTurn)
			SC.persionisgonnatowin = 2;
		else
			SC.persionisgonnatowin = 1;
		AudioManager.instance.MUSIC.PlayOneShot (AudioManager.instance.cheer);
		if (GAMEMANAGER.isOnline)
			SC.showmessagebutton ();
		if (SC.isServe) {
			GAMEMANAGER.p1acecount++;
		}
		if (Random.Range (0, 10) >= 5)
			SC.PLAYER1.GetComponent<Animator> ().Play ("Fun");
		else
			SC.PLAYER1.GetComponent<Animator> ().Play ("Fun2");	
		SC.PLAYER2.GetComponent<Animator> ().Play ("Idle");
		SC.PLAYER2.GetComponent<Animator> ().SetFloat ("Speed", 0);
		if (Random.Range (0, 10) >= 5)
			SC.PLAYER2.GetComponent<Animator> ().Play ("Angry2");
		else if (Random.Range (0, 10) >= 5)
			SC.PLAYER2.GetComponent<Animator> ().Play ("Angry");
		SC.PLAYER2.transform.rotation = Quaternion.LookRotation (Vector3.back);
	}

	[Command]
	public void Cmdwin1(){
		Rpcwin1_1 ();
	}

	[ClientRpc]
	public void Rpcwin2(){
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (SC.ANIMATEDWON == false) return;
		if (SC.isServe) {
			GAMEMANAGER.p1acecount++;
		}
		if (Random.Range (0, 10) >= 5)
			SC.PLAYER1.GetComponent<Animator> ().Play ("Fun");
		else
			SC.PLAYER1.GetComponent<Animator> ().Play ("Fun2");	
		SC.PLAYER2.GetComponent<Animator> ().Play ("Idle");
		SC.PLAYER2.GetComponent<Animator> ().SetFloat ("Speed", 0);
		if (Random.Range (0, 10) >= 7)
			SC.PLAYER2.GetComponent<Animator> ().Play ("Angry2");
		else if (Random.Range (0, 10) >= 7)
			SC.PLAYER2.GetComponent<Animator> ().Play ("Angry");
		SC.PLAYER2.transform.rotation = Quaternion.LookRotation (Vector3.back);
	}

	[ClientRpc]
	public void Rpcwin2_2(){
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (GAMEMANAGER.WhoIAm == 2)
			return;
		if (SC.ANIMATEDWON == false) return;
		if (SC.isServe) {
			GAMEMANAGER.p1acecount++;
		}
		if (Random.Range (0, 10) >= 5)
			SC.PLAYER1.GetComponent<Animator> ().Play ("Fun");
		else
			SC.PLAYER1.GetComponent<Animator> ().Play ("Fun2");	
		SC.PLAYER2.GetComponent<Animator> ().Play ("Idle");
		SC.PLAYER2.GetComponent<Animator> ().SetFloat ("Speed", 0);
		if (Random.Range (0, 10) >= 7)
			SC.PLAYER2.GetComponent<Animator> ().Play ("Angry2");
		else if (Random.Range (0, 10) >= 7)
			SC.PLAYER2.GetComponent<Animator> ().Play ("Angry");
		SC.PLAYER2.transform.rotation = Quaternion.LookRotation (Vector3.back);
	}

	[Command]
	public void Cmdwin2(){
		Rpcwin2_2 ();
	}

	[ClientRpc]
	public void Rpcwin3_3(){
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (GAMEMANAGER.WhoIAm == 2)
			return;
		SC.ANIMATEDWON = false;	
	}

	[Command]
	public void Cmdwin3(){
		Rpcwin3_3();
	}

	[ClientRpc]
	public void Rpcwin3(){
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		SC.ANIMATEDWON = false;
	}

	[ClientRpc]
	public void Rpcwin4_4(){
		Debug.Log ("yayaya");
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (GAMEMANAGER.WhoIAm == 2)
			return;
		if (SC.ANIMATEDWON == true) return;
		SC.faultRemember = false;
		if (SC.Player1HittingTurn)
			GAMEMANAGER.WhoWinLastPoint = 2;
		else
			GAMEMANAGER.WhoWinLastPoint = 1;
	}

	[Command]
	public void Cmdwin4(){
		Rpcwin4_4 ();
	}


	[ClientRpc]
	public void Rpcwin4(){
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (SC.ANIMATEDWON == true) return;
		SC.faultRemember = false;
		if (SC.Player1HittingTurn)
			GAMEMANAGER.WhoWinLastPoint = 2;
		else
			GAMEMANAGER.WhoWinLastPoint = 1;
	}

	[Command]
	void Cmdp2inforjoined(string name, string country, int[] tmp){
		datas.ClientReady = true;
		datas.p2name = name;
		datas.p2country = country;
		for (int i = 0; i <= 28; i++)
			datas.p2.Add (tmp [i]);
	}

	[ClientRpc]
	public void Rpcplayer1toss()
	{
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (GAMEMANAGER.WhoIAm == 1)
			return;
		
		SC.atbeginingstage = false;
		SC.click_toss = true;
		SC.t1 = Time.time;
		SC.rb.isKinematic = false;
		SC.rb.velocity = Vector3.zero;
		SC.BALL.transform.position = SC.default_position;
		SC.rb.AddForce (new Vector3 (0, 5.9f, 0), ForceMode.Impulse);
		SC.PERFECTTIME = Time.time + 0.852f - 0.25f;
		SC.PLAYER1.GetComponent<Animator> ().SetBool ("Click", true);
	}

	[Command]
	public void Cmdplayer2toss()
	{
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		SC.atbeginingstage = false;
		SC.click_toss = true;
		SC.t1 = Time.time;
		SC.rb.isKinematic = false;
		SC.rb.velocity = Vector3.zero;
		SC.BALL.transform.position = SC.default_position;
		SC.rb.AddForce (new Vector3 (0, 5.9f, 0), ForceMode.Impulse);
		SC.PERFECTTIME = Time.time + 0.852f - 0.25f;
		SC.PLAYER2.GetComponent<Animator> ().SetBool ("Click", true);
	}

	[Command]
	public void Cmdplayer2serve()
	{
		Debug.Log ("OKIEEEE");
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		SC.TIMEDIDANIMATED = Time.time;
		AudioManager.instance.MUSIC.PlayOneShot (AudioManager.instance.serve);
		SC.PLAYER2.GetComponent<Animator> ().SetBool ("Serve", true);
	}


	[ClientRpc]
	public void Rpcplayer1serve()
	{
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (GAMEMANAGER.WhoIAm == 1)
			return;
		
		SC.TIMEDIDANIMATED = Time.time;
		AudioManager.instance.MUSIC.PlayOneShot (AudioManager.instance.serve);
		SC.PLAYER1.GetComponent<Animator> ().SetBool ("Serve", true);
	}

	[ClientRpc]
	public void Rpcplayer1serve5()
	{
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (GAMEMANAGER.WhoIAm == 1)
			return;
		SC.FIRST_STAGE = false;
	}

	[Command]
	public void Cmdplayer2serve5()
	{
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal>();
		SC.FIRST_STAGE = false;
	}

	[ClientRpc]
	public void Rpcplayer1serve6()
	{	
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal> ();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (GAMEMANAGER.WhoIAm == 1)
			return;
		SC.FAILED = true;
		SC.time_detect_out_or_fail = Time.time;
		SC.number_of_fail++;
		if (SC.number_of_fail >= 2) {
			SC.audience = true;
			AudioManager.instance.MUSIC.PlayOneShot (AudioManager.instance.cheer);
			SC.fault_text.text = "Double Fault";
		} else
			SC.fault_text.text = "Fault";
		SC.INFO.gameObject.SetActive (true);
		SC.timelastclick = Time.time;
	}


	[Command]
	public void Cmdplayer2serve6()
	{
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal> ();

		SC.FAILED = true;
		SC.time_detect_out_or_fail = Time.time;
		SC.number_of_fail++;
		if (SC.number_of_fail >= 2) {
			SC.audience = true;
			AudioManager.instance.MUSIC.PlayOneShot (AudioManager.instance.cheer);
			SC.fault_text.text = "Double Fault";
		} else
			SC.fault_text.text = "Fault";
		SC.timelastclick = Time.time;
		SC.INFO.gameObject.SetActive (true);
	}

	[ClientRpc]
	public void Rpcplayer1serve7(float TIME_TRAVEL, Vector3 TARGET, bool OUT, bool isgonnacollidewithnet, Vector3 DES, Vector3 P1DES, Vector3 P2DES, float PERF)
	{
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal> ();
		SC.timelastclick = Time.time;
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (GAMEMANAGER.WhoIAm == 1)
			return;
		if (OUT || isgonnacollidewithnet)
			SC.FAILED = true;
		SC.PLAYER1.GetComponent<Animator> ().SetBool ("First_Stage", false);
		SC.isServe = true;
		SC.SpeedBoard.GetComponent<SpeedBoard> ().time = Time.time + 0.25f;
		if (SC.number_of_fail == 0) {
			GAMEMANAGER.p1firstservecount += 1;
		} else {
			GAMEMANAGER.p1firstservesuccesscount -= 1;
		}
		SC.rb.velocity = SC.BallisticVelocity_time (TARGET, TIME_TRAVEL);
		SC.SpeedText.text = (System.Math.Round (SC.rb.velocity.magnitude * 2.25f, 2)).ToString () + " mph";
		SC.OUT = OUT;
		SC.gonnaToCollideWithNet = isgonnacollidewithnet;
		if (OUT == false && SC.gonnaToCollideWithNet == false) {
			if (SC.rb.velocity.magnitude * 2.25f > GAMEMANAGER.p1fastestspeed) {
				GAMEMANAGER.p1fastestspeed = (float)System.Math.Round (SC.rb.velocity.magnitude * 2.25f, 2);
			}
		}
		/*
		yCollision = SC.rb.velocity.y - 9.81f * TIME_TRAVEL;
		yCollision *= -.75f;
		float t = yCollision / 9.81f;
		if (t > 0.17f) {
			SC.H1 = yCollision * 0.17f -	0.17f * 0.17f * 9.81f * 0.5f;
		} else {
			SC.H1 = t * yCollision - t * t * 0.5f * 9.81f;
			SC.H1 -= (0.17f - t) * (0.17f - t) * 0.5f * 9.81f;
		}
		t = 0.17f;
		float yt = SC.H1, xt = SC.rb.velocity.x * t * 0.750f, zt = SC.rb.velocity.z * t * 0.750f;
		SC.DESTINATION = new Vector3 (TARGET.x + xt, yt, TARGET.z + zt);

		SC.PERFECTTIME = Time.time + TIME_TRAVEL + t - 0.1667f;
		SC.timeToCollide = Time.time + TIME_TRAVEL;
		*/
		SceneControllerOnlineFinal.yCollision = SC.rb.velocity.y - 9.81f * TIME_TRAVEL;
		SceneControllerOnlineFinal.yCollision *= -.75f;
		SceneControllerOnlineFinal.hitted = true;
		SC.PERFECTTIME = Time.time + TIME_TRAVEL + PERF - 0.1667f;
		SC.timeToCollide = Time.time + TIME_TRAVEL;
		float t, yt;
		SC.t1 = Mathf.Abs (SC.BALL.transform.position.z / SC.rb.velocity.z);
		if (SC.gonnaToCollideWithNet == true) {
			while (true) {
				t = SC.rb.velocity.y / 9.81f;
				if (t < 0 || t >= SC.t1) {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * SC.t1 - 9.81f * SC.t1 * SC.t1 * 0.5f;
				} else {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t - 9.81f * t * t * 0.5f - (SC.t1 - t) * (SC.t1 - t) * 9.81f * 0.5f;
				} 
				if (yt - 0.9 >= 0) {
					if (t > 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y / 1.1f, SC.rb.velocity.z);
					else
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y / 0.9f, SC.rb.velocity.z);
					if (SC.rb.velocity.y < 0.1f && SC.rb.velocity.y >= 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, -0.5f, SC.rb.velocity.z);
				} else {
					break;
				}
			}	
		} else {
			while (true) {
				t = SC.rb.velocity.y / 9.81f;
				if (t < 0 || t >= SC.t1) {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * SC.t1 - 9.81f * SC.t1 * SC.t1 * 0.5f;
				} else {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t - 9.81f * t * t * 0.5f - (SC.t1 - t) * (SC.t1 - t) * 9.81f * 0.5f;
				} 
				if (yt - 1.18 <= 0) {
					if (t > 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y * 1.2f, SC.rb.velocity.z);
					else
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y * 0.8f, SC.rb.velocity.z);
					if (SC.rb.velocity.y > -0.5f && SC.rb.velocity.y < 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, 0.5f, SC.rb.velocity.z);
				} else {
					break;
				}
			}
		}

		SC.didAdjustBall = false;
		SC.isReachedDestination = false;
		SC.PLAYER2.GetComponent<CharacterController> ().Move (Vector3.zero);
		SC.click_toss = false;
		SC.DESTINATION.y = 0;
		SC.HAVECLICKEDINNEWPHASE = false;
		SC.isReachedDestination = false;
		SC.DIDANIMATED = false;
		SC.DONE = false;
		SC.Player1HittingTurn = !SC.Player1HittingTurn;
		if (GAMEMANAGER.isPlayer2Computer) {
			SC.TIMEATCLICK = SC.PERFECTTIME;
			SC.HAVECLICKEDINNEWPHASE = true;
		}
		SC.DESTINATION = DES;
		SC.PLAYER2DESTINATION = P2DES;
		SC.PLAYER1DESTINATION = P1DES;/*
		if (SC.PLAYER2.GetComponent<CharacterController> ().transform.position.x < SC.DESTINATION.x) {
			SC.PLAYER2DESTINATION = SC.DESTINATION + new Vector3 (-0.9f, 0, 0.8f);
			SC.PLAYER2DESTINATION.y = SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y;
			if (SC.Player1NetRushing.isOn == false)
				SC.PLAYER1DESTINATION = new Vector3 (0, SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y, -12);
			else
				SC.PLAYER1DESTINATION = new Vector3 (0, SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y, -1.5f);
		} else {
			SC.PLAYER2DESTINATION = SC.DESTINATION + new Vector3 (0.85f, 0, 0.85f);
			SC.PLAYER2DESTINATION.y = SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y;
			if (SC.Player1NetRushing.isOn == false)
				SC.PLAYER1DESTINATION = new Vector3 (0, SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y, -12);
			else
				SC.PLAYER1DESTINATION = new Vector3 (0, SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y, -1.5f);
		}*/

		Debug.DrawRay (new Vector3 (SC.DESTINATION.x, -2, SC.DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.blue, 1.5f);
		Debug.DrawRay (new Vector3 (SC.DESTINATION.x, -2, SC.DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.green, 0.5f);
		SC.PLAYER2.transform.rotation = Quaternion.LookRotation (SC.PLAYER2DESTINATION - SC.PLAYER2.transform.position);
		SC.PLAYER1.transform.rotation = Quaternion.LookRotation (SC.PLAYER1DESTINATION - SC.PLAYER1.transform.position);
	}

	[Command]
	public void Cmdtest(){
		Debug.Log ("OKIeee tested");
	}

	[Command]
	public void Cmdplayer2serve7(float TIME_TRAVEL, Vector3 TARGET, bool OUT, bool isgonnacollidewithnet, Vector3 DES, Vector3 P1DES, Vector3 P2DES, float PERF)
	{
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal> ();
		SC.timelastclick = Time.time;
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (OUT || isgonnacollidewithnet)
			SC.FAILED = true;
		SC.PLAYER2.GetComponent<Animator> ().SetBool ("First_Stage", false);
		SC.isServe = true;
		SC.SpeedBoard.GetComponent<SpeedBoard> ().time = Time.time + 0.25f;
		if (SC.number_of_fail == 0) {
			GAMEMANAGER.p2firstservecount += 1;
		} else {
			GAMEMANAGER.p2firstservesuccesscount -= 1;
		}
		SC.rb.velocity = SC.BallisticVelocity_time (TARGET, TIME_TRAVEL);
		SC.SpeedText.text = (System.Math.Round (SC.rb.velocity.magnitude * 2.25f, 2)).ToString () + " mph";
		SC.OUT = OUT;
		SC.gonnaToCollideWithNet = isgonnacollidewithnet;
		if (OUT == false && SC.gonnaToCollideWithNet == false) {
			if (SC.rb.velocity.magnitude * 2.25f > GAMEMANAGER.p2fastestspeed) {
				GAMEMANAGER.p2fastestspeed = (float)System.Math.Round (SC.rb.velocity.magnitude * 2.25f, 2);
			}
		}
		/*
		yCollision = SC.rb.velocity.y - 9.81f * TIME_TRAVEL;
		yCollision *= -.75f;
		float t = yCollision / 9.81f;
		if (t > 0.17f) {
			SC.H1 = yCollision * 0.17f -	0.17f * 0.17f * 9.81f * 0.5f;
		} else {
			SC.H1 = t * yCollision - t * t * 0.5f * 9.81f;
			SC.H1 -= (0.17f - t) * (0.17f - t) * 0.5f * 9.81f;
		}
		t = 0.17f;
		float yt = SC.H1, xt = SC.rb.velocity.x * t * 0.750f, zt = SC.rb.velocity.z * t * 0.750f;
		SC.DESTINATION = new Vector3 (TARGET.x + xt, yt, TARGET.z + zt);

		SC.PERFECTTIME = Time.time + TIME_TRAVEL + t - 0.1667f;
		SC.timeToCollide = Time.time + TIME_TRAVEL;

		*/
		SceneControllerOnlineFinal.yCollision = SC.rb.velocity.y - 9.81f * TIME_TRAVEL;
		SceneControllerOnlineFinal.yCollision *= -.75f;
		SceneControllerOnlineFinal.hitted = true;
		SC.PERFECTTIME = Time.time + PERF - 0.1667f + TIME_TRAVEL;
		SC.timeToCollide = Time.time + TIME_TRAVEL;
		SC.t1 = Mathf.Abs (SC.BALL.transform.position.z / SC.rb.velocity.z);
		float t, yt;
		if (SC.gonnaToCollideWithNet == true) {
			while (true) {
				t = SC.rb.velocity.y / 9.81f;
				if (t < 0 || t >= SC.t1) {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * SC.t1 - 9.81f * SC.t1 * SC.t1 * 0.5f;
				} else {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t - 9.81f * t * t * 0.5f - (SC.t1 - t) * (SC.t1 - t) * 9.81f * 0.5f;
				} 
				if (yt - 0.9 >= 0) {
					if (t > 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y / 1.1f, SC.rb.velocity.z);
					else
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y / 0.9f, SC.rb.velocity.z);
					if (SC.rb.velocity.y < 0.1f && SC.rb.velocity.y >= 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, -0.5f, SC.rb.velocity.z);
				} else {
					break;
				}
			}	
		} else {
			while (true) {
				t = SC.rb.velocity.y / 9.81f;
				if (t < 0 || t >= SC.t1) {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * SC.t1 - 9.81f * SC.t1 * SC.t1 * 0.5f;
				} else {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t - 9.81f * t * t * 0.5f - (SC.t1 - t) * (SC.t1 - t) * 9.81f * 0.5f;
				} 
				if (yt - 1.18 <= 0) {
					if (t > 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y * 1.2f, SC.rb.velocity.z);
					else
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y * 0.8f, SC.rb.velocity.z);
					if (SC.rb.velocity.y > -0.5f && SC.rb.velocity.y < 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, 0.5f, SC.rb.velocity.z);
				} else {
					break;
				}
			}
		}

		SC.didAdjustBall = false;
		SC.isReachedDestination = false;
		//SC.PLAYER2.GetComponent<CharacterController> ().Move (Vector3.zero);
		SC.click_toss = false;
		SC.DESTINATION.y = 0;
		SC.HAVECLICKEDINNEWPHASE = false;
		SC.isReachedDestination = false;
		SC.DIDANIMATED = false;
		SC.DONE = false;
		SC.Player1HittingTurn = !SC.Player1HittingTurn;
		SC.PLAYER1DESTINATION = P1DES;
		SC.PLAYER2DESTINATION = P2DES;
		SC.DESTINATION = DES;
		/*
		if (SC.PLAYER1.GetComponent<CharacterController> ().transform.position.x < SC.DESTINATION.x) {
			SC.PLAYER1DESTINATION = SC.DESTINATION + new Vector3 (-0.9f, 0, 0.8f);
			SC.PLAYER1DESTINATION.y = SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y;
			if (SC.PLayer2NetRushing.isOn == false)
				SC.PLAYER2DESTINATION = new Vector3 (0, SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y, 12);
			else
				SC.PLAYER2DESTINATION = new Vector3 (0, SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y, 1.5f);
		} else {
			SC.PLAYER1DESTINATION = SC.DESTINATION + new Vector3 (0.85f, 0, 0.85f);
			SC.PLAYER1DESTINATION.y = SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y;
			if (SC.PLayer2NetRushing.isOn == false)
				SC.PLAYER2DESTINATION = new Vector3 (0, SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y, 12);
			else
				SC.PLAYER2DESTINATION = new Vector3 (0, SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y, 1.5f);
		}*/

		Debug.DrawRay (new Vector3 (SC.DESTINATION.x, -2, SC.DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.blue, 1.5f);
		Debug.DrawRay (new Vector3 (SC.DESTINATION.x, -2, SC.DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.green, 0.5f);
		SC.PLAYER2.transform.rotation = Quaternion.LookRotation (SC.PLAYER2DESTINATION - SC.PLAYER2.transform.position);
		SC.PLAYER1.transform.rotation = Quaternion.LookRotation (SC.PLAYER1DESTINATION - SC.PLAYER1.transform.position);
	}

	[ClientRpc]
	public void Rpcplayer1return()
	{
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal> ();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		SC.timeAtClick.text = SC.TIMEATCLICK.ToString ();
		SC.perfectTime.text = SC.PERFECTTIME.ToString ();
		SC.deltaTime.text = (SC.PERFECTTIME - SC.TIMEATCLICK).ToString ();
		SC.DIDANIMATED = true;
		SC.TIMEDIDANIMATED = Time.time;
		if (SC.PLAYER1.transform.position.x > SC.DESTINATION.x) {
			SC.PLAYER1.GetComponent<Animator> ().Play ("Hit1");
		} else {
			SC.PLAYER1.GetComponent<Animator> ().Play ("Hit2");
		}
	}

	[Command]
	public void Cmdplayer2return()
	{
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal> ();
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		SC.timeAtClick.text = SC.TIMEATCLICK.ToString ();
		SC.perfectTime.text = SC.PERFECTTIME.ToString ();
		SC.DIDANIMATED = true;
		SC.TIMEDIDANIMATED = Time.time;
		SC.deltaTime.text = (SC.PERFECTTIME - SC.TIMEATCLICK).ToString ();
		if (SC.PLAYER2.transform.position.x > SC.DESTINATION.x) {
			SC.PLAYER2.GetComponent<Animator> ().Play ("Hit2");
		} else {
			SC.PLAYER2.GetComponent<Animator> ().Play ("Hit1");
		}
	}

	[ClientRpc]
	public void Rpcplayer1return2(float TIME_TRAVEL, Vector3 Target, bool OUT, bool isgonnacolidewithnet, Vector3 DES, Vector3 P1DES, Vector3 P2DES, float PERF){
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal> ();
		SC.timelastclick = Time.time;
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		if (GAMEMANAGER.WhoIAm == 1)
			return;
		SC.rb.velocity = SC.BallisticVelocity_time (Target, TIME_TRAVEL);
		SC.OUT = OUT;
		if (OUT)
			SC.persionisgonnatowin = 2;
		SC.gonnaToCollideWithNet = isgonnacolidewithnet;

		SC.timeToCollide = Time.time + TIME_TRAVEL;	

		SceneControllerOnlineFinal.yCollision = SC.rb.velocity.y - 9.81f * TIME_TRAVEL;
		SceneControllerOnlineFinal.yCollision *= -.75f;
		SceneControllerOnlineFinal.hitted = true;
		SC.isServe = false;
		/*
		float t = yCollision / 9.81f;
		if (t > 0.17f) {
			SC.H1 = yCollision * 0.17f -	0.17f * 0.17f * 9.81f * 0.5f + 0.07f;
		} else {
			SC.H1 = t * yCollision - t * t * 0.5f * 9.81f + 0.07f;
			SC.	H1 -= (0.17f - t) * (0.17f - t) * 0.5f * 9.81f;
		} 
		t = 0.17f;
		float yt = SC.H1, xt = SC.rb.velocity.x * t * 0.750f, zt = SC.rb.velocity.z * t * 0.750f;
		SC.DESTINATION = new Vector3 (Target.x + xt, yt, Target.z + zt);
		SC.isReachedDestination = false;
		SC.PERFECTTIME = Time.time + TIME_TRAVEL + t - 0.1667f;

		if (SC.DESTINATION.z > 17.5f) {
			float t2 = (17.5f - Target.z) / Mathf.Abs (SC.rb.velocity.z * 0.75f), t3 = yCollision / 9.81f;
			Vector3 DESTINATION2;
			if (t3 > t2) {
				DESTINATION2 = new Vector3 (Target.x + SC.rb.velocity.x * t2 * 0.75f, yCollision * t2 - t2 * t2 * 9.81f / 2 + 0.07f, Target.z + SC.rb.velocity.z * t2 * 0.75f);
			} else {
				DESTINATION2 = new Vector3 (Target.x + SC.rb.velocity.x * t2 * 0.75f, yCollision * t3 - t3 * t3 * 9.81f / 2 + 0.07f - (t2 - t3) * (t2 - t3) * 9.81f / 2, Target.z + SC.rb.velocity.z * t2 * 0.75f);
			}
			SC.DESTINATION = DESTINATION2;
			SC.PERFECTTIME = Time.time + t2 - 0.1667f + TIME_TRAVEL;	
		}

		if (((Vector3.Distance (SC.PLAYER2.transform.position, SC.DESTINATION) / SC.Player2_Speed) > (SC.PERFECTTIME - Time.time + 0.1667f)) || SC.computerNetRushing) {
			float t2 = TIME_TRAVEL - 0.175f, t3 = SC.rb.velocity.y / 9.81f;	
			Vector3 DESTINATION2 = new Vector3 (SC.BALL.transform.position.x + SC.rb.velocity.x * t2, SC.BALL.transform.position.y + SC.rb.velocity.y * t3 - 0.5f * t3 * t3 * 9.81f -
				(t2 - t3) * (t2 - t3) * 9.81f * 0.5f, SC.BALL.transform.position.z + SC.rb.velocity.z * t2);
			t3 = Vector3.Distance (SC.PLAYER2.transform.position, DESTINATION2) / SC.Player2_Speed;
			if (t3 <= t2 + 0.1667f) {
				SC.DESTINATION = DESTINATION2;
				SC.PERFECTTIME = Time.time + t2 - 0.1667f;	
			}
		}
		////////////Debug.Log(DESTINATION);
		float t4 = (Mathf.Abs (SC.BALL.transform.position.z) + 0.5f) / Mathf.Abs (SC.rb.velocity.z);
		float t5 = SC.rb.velocity.y / 9.81f;
		float tmpy;
		if (t5 > t4)
			tmpy = SC.rb.transform.position.y + SC.rb.velocity.y * t4 - t4 * t4 * 0.5f * 9.81f;
		else
			tmpy = SC.rb.transform.position.y + SC.rb.velocity.y * t5 - t5 * t5 * 0.5f * 9.81f - (t4 - t5) * (t4 - t5) * 0.5f * 9.81f;
		Vector3 DESTINATION3 = new Vector3 (SC.rb.transform.position.x + SC.rb.velocity.x * t4, tmpy, SC.rb.transform.position.z + SC.rb.velocity.z * t4);
		if (Vector3.Distance (SC.PLAYER2.transform.position, DESTINATION3) < Vector3.Distance (SC.PLAYER2.transform.position, SC.DESTINATION)) {
			SC.DESTINATION = DESTINATION3;
			SC.PERFECTTIME = Time.time + t4 - 0.1667f;
		}
		*/
		SC.PERFECTTIME = Time.time + PERF - 0.16667f + TIME_TRAVEL;
		float t1 = Mathf.Abs (SC.BALL.transform.position.z / SC.rb.velocity.z);
		float t, yt;
		if (SC.gonnaToCollideWithNet == true) {
			while (true) {
				t = SC.rb.velocity.y / 9.81f;
				////////////Debug.Log (rb.velocity.y);
				if (t < 0 || t >= t1) {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t1 - 9.81f * t1 * t1 * 0.5f;
				} else {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t - 9.81f * t * t * 0.5f - (t1 - t) * (t1 - t) * 9.81f * 0.5f;
				} 
				if (yt - 0.9 >= 0) {
					if (t > 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y / 1.1f, SC.rb.velocity.z);
					else
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y / 0.9f, SC.rb.velocity.z);
					if (SC.rb.velocity.y < 0.1f && SC.rb.velocity.y >= 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, -0.5f, SC.rb.velocity.z);
				} else {
					break;
				}
			}	
		} else {
			while (true) {
				t = SC.rb.velocity.y / 9.81f;
				if (t < 0 || t >= t1) {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t1 - 9.81f * t1 * t1 * 0.5f;
				} else {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t - 9.81f * t * t * 0.5f - (t1 - t) * (t1 - t) * 9.81f * 0.5f;
				} 
				if (yt - 1.18 <= 0) {
					if (t > 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y * 1.2f, SC.rb.velocity.z);
					else
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y * 0.8f, SC.rb.velocity.z);
					if (SC.rb.velocity.y > -0.5f && SC.rb.velocity.y < 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, 0.5f, SC.rb.velocity.z);
				} else {
					break;
				}
			}
		}
		//	Debug.DrawRay (new Vector3 (DESTINATION.x, -H1, DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.blue, 1.5f);
		//	Debug.DrawRay (new Vector3 (DESTINATION.x, H1, DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.green, 0.5f);
		SC.DESTINATION.y = 0;
		SC.mx = -10;
		SC.my = -10;
		SC.HAVECLICKEDINNEWPHASE = false;
		SC.didCollideWithNet = false;
		SC.didAdjustBall = false;
		SC.isReachedDestination = false;
		SC.DIDANIMATED = false;
		SC.DONE = false;
		SC.Player1HittingTurn = !SC.Player1HittingTurn;
		SC.PLAYER1DESTINATION = P1DES;
		SC.PLAYER2DESTINATION = P2DES;
		SC.DESTINATION = DES;
		/*
		if (SC.PLAYER2.GetComponent<CharacterController> ().transform.position.x < SC.DESTINATION.x) {
			SC.PLAYER2DESTINATION = SC.DESTINATION + new Vector3 (-0.9f, 0, 0.8f);
			SC.PLAYER2DESTINATION.y = SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y;
			if (SC.Player1NetRushing.isOn == false)
				SC.PLAYER1DESTINATION = new Vector3 (0, SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y, -12);
			else
				SC.PLAYER1DESTINATION = new Vector3 (0, SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y, -1.5f);
		} else {
			SC.PLAYER2DESTINATION = SC.DESTINATION + new Vector3 (0.85f, 0, 0.85f);
			SC.PLAYER2DESTINATION.y = SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y;
			if (SC.Player1NetRushing.isOn == false)
				SC.PLAYER1DESTINATION = new Vector3 (0, SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y, -12);
			else
				SC.PLAYER1DESTINATION = new Vector3 (0, SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y, -1.5f);
		}*/

		Debug.DrawRay (new Vector3 (SC.DESTINATION.x, -2, SC.DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.blue, 1.5f);
		Debug.DrawRay (new Vector3 (SC.DESTINATION.x, -2, SC.DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.green, 0.5f);
		SC.PLAYER2.transform.rotation = Quaternion.LookRotation (SC.PLAYER2DESTINATION - SC.PLAYER2.transform.position);
		SC.PLAYER1.transform.rotation = Quaternion.LookRotation (SC.PLAYER1DESTINATION - SC.PLAYER1.transform.position);
	}

	[Command]
	public void Cmdplayer2return2(float TIME_TRAVEL, Vector3 Target, bool OUT, bool isgonnacolidewithnet, Vector3 DES, Vector3 P1DES, Vector3 P2DES, float PERF){
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal> ();
		SC.timelastclick = Time.time;
		GameManager GAMEMANAGER = GameObject.Find ("GameManager").GetComponent (typeof(GameManager)) as GameManager;
		SC.rb.velocity = SC.BallisticVelocity_time (Target, TIME_TRAVEL);
		SC.OUT = OUT;
		if (OUT)
			SC.persionisgonnatowin = 1;
		
		SC.gonnaToCollideWithNet = isgonnacolidewithnet;

		SC.timeToCollide = Time.time + TIME_TRAVEL;	

		SceneControllerOnlineFinal.yCollision = SC.rb.velocity.y - 9.81f * TIME_TRAVEL;
		SceneControllerOnlineFinal.yCollision *= -.75f;
		SceneControllerOnlineFinal.hitted = true;
		SC.isServe = false;
		SC.PERFECTTIME = TIME_TRAVEL +  PERF - 0.16667f + Time.time;
		/*
		float t = yCollision / 9.81f;
		if (t > 0.17f) {
			SC.H1 = yCollision * 0.17f -	0.17f * 0.17f * 9.81f * 0.5f + 0.07f;
		} else {
			SC.H1 = t * yCollision - t * t * 0.5f * 9.81f + 0.07f;
			SC.	H1 -= (0.17f - t) * (0.17f - t) * 0.5f * 9.81f;
		} 
		t = 0.17f;
		float yt = SC.H1, xt = SC.rb.velocity.x * t * 0.750f, zt = SC.rb.velocity.z * t * 0.750f;
		SC.DESTINATION = new Vector3 (Target.x + xt, yt, Target.z + zt);
		SC.isReachedDestination = false;
		SC.PERFECTTIME = Time.time + TIME_TRAVEL + t - 0.1667f;

		if (SC.DESTINATION.z > 17.5f) {
			float t2 = (17.5f - Target.z) / Mathf.Abs (SC.rb.velocity.z * 0.75f), t3 = yCollision / 9.81f;
			Vector3 DESTINATION2;
			if (t3 > t2) {
				DESTINATION2 = new Vector3 (Target.x + SC.rb.velocity.x * t2 * 0.75f, yCollision * t2 - t2 * t2 * 9.81f / 2 + 0.07f, Target.z + SC.rb.velocity.z * t2 * 0.75f);
			} else {
				DESTINATION2 = new Vector3 (Target.x + SC.rb.velocity.x * t2 * 0.75f, yCollision * t3 - t3 * t3 * 9.81f / 2 + 0.07f - (t2 - t3) * (t2 - t3) * 9.81f / 2, Target.z + SC.rb.velocity.z * t2 * 0.75f);
			}
			SC.DESTINATION = DESTINATION2;
			SC.PERFECTTIME = Time.time + t2 - 0.1667f + TIME_TRAVEL;	
		}

		if (((Vector3.Distance (SC.PLAYER1.transform.position, SC.DESTINATION) / SC.Player1_Speed) > (SC.PERFECTTIME - Time.time + 0.1667f)) || SC.computerNetRushing) {
			float t2 = TIME_TRAVEL - 0.175f, t3 = SC.rb.velocity.y / 9.81f;	
			Vector3 DESTINATION2 = new Vector3 (SC.BALL.transform.position.x + SC.rb.velocity.x * t2, SC.BALL.transform.position.y + SC.rb.velocity.y * t3 - 0.5f * t3 * t3 * 9.81f -
				(t2 - t3) * (t2 - t3) * 9.81f * 0.5f, SC.BALL.transform.position.z + SC.rb.velocity.z * t2);
			t3 = Vector3.Distance (SC.PLAYER1.transform.position, DESTINATION2) / SC.Player1_Speed;
			if (t3 <= t2 + 0.1667f) {
				SC.DESTINATION = DESTINATION2;
				SC.PERFECTTIME = Time.time + t2 - 0.1667f;	
			}
		}
		////////////Debug.Log(DESTINATION);
		float t4 = (Mathf.Abs (SC.BALL.transform.position.z) + 0.5f) / Mathf.Abs (SC.rb.velocity.z);
		float t5 = SC.rb.velocity.y / 9.81f;
		float tmpy;
		if (t5 > t4)
			tmpy = SC.rb.transform.position.y + SC.rb.velocity.y * t4 - t4 * t4 * 0.5f * 9.81f;
		else
			tmpy = SC.rb.transform.position.y + SC.rb.velocity.y * t5 - t5 * t5 * 0.5f * 9.81f - (t4 - t5) * (t4 - t5) * 0.5f * 9.81f;
		Vector3 DESTINATION3 = new Vector3 (SC.rb.transform.position.x + SC.rb.velocity.x * t4, tmpy, SC.rb.transform.position.z + SC.rb.velocity.z * t4);
		if (Vector3.Distance (SC.PLAYER1.transform.position, DESTINATION3) < Vector3.Distance (SC.PLAYER1.transform.position, SC.DESTINATION)) {
			SC.DESTINATION = DESTINATION3;
			SC.PERFECTTIME = Time.time + t4 - 0.1667f;
		}
		*/
		float t1 = Mathf.Abs (SC.BALL.transform.position.z / SC.rb.velocity.z);
		float t, yt;
		if (SC.gonnaToCollideWithNet == true) {
			while (true) {
				t = SC.rb.velocity.y / 9.81f;
				////////////Debug.Log (rb.velocity.y);
				if (t < 0 || t >= t1) {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t1 - 9.81f * t1 * t1 * 0.5f;
				} else {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t - 9.81f * t * t * 0.5f - (t1 - t) * (t1 - t) * 9.81f * 0.5f;
				} 
				if (yt - 0.9 >= 0) {
					if (t > 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y / 1.1f, SC.rb.velocity.z);
					else
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y / 0.9f, SC.rb.velocity.z);
					if (SC.rb.velocity.y < 0.1f && SC.rb.velocity.y >= 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, -0.5f, SC.rb.velocity.z);
				} else {
					break;
				}
			}	
		} else {
			while (true) {
				t = SC.rb.velocity.y / 9.81f;
				if (t < 0 || t >= t1) {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t1 - 9.81f * t1 * t1 * 0.5f;
				} else {
					yt = SC.BALL.transform.position.y + SC.rb.velocity.y * t - 9.81f * t * t * 0.5f - (t1 - t) * (t1 - t) * 9.81f * 0.5f;
				} 
				if (yt - 1.18 <= 0) {
					if (t > 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y * 1.2f, SC.rb.velocity.z);
					else
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, SC.rb.velocity.y * 0.8f, SC.rb.velocity.z);
					if (SC.rb.velocity.y > -0.5f && SC.rb.velocity.y < 0)
						SC.rb.velocity = new Vector3 (SC.rb.velocity.x, 0.5f, SC.rb.velocity.z);
				} else {
					break;
				}
			}
		}
		//	Debug.DrawRay (new Vector3 (DESTINATION.x, -H1, DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.blue, 1.5f);
		//	Debug.DrawRay (new Vector3 (DESTINATION.x, H1, DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.green, 0.5f);
		SC.DESTINATION.y = 0;
		SC.mx = -10;
		SC.my = -10;
		SC.HAVECLICKEDINNEWPHASE = false;
		SC.didCollideWithNet = false;
		SC.didAdjustBall = false;	
		SC.isReachedDestination = false;
		SC.DIDANIMATED = false;
		SC.DONE = false;
		SC.Player1HittingTurn = !SC.Player1HittingTurn;
		/*
		if (SC.PLAYER1.GetComponent<CharacterController> ().transform.position.x < SC.DESTINATION.x) {
			SC.PLAYER1DESTINATION = SC.DESTINATION + new Vector3 (-0.9f, 0, 0.8f);
			SC.PLAYER1DESTINATION.y = SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y;
			if (SC.PLayer2NetRushing.isOn == false)
				SC.PLAYER2DESTINATION = new Vector3 (0, SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y, 12);
			else
				SC.PLAYER2DESTINATION = new Vector3 (0, SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y, 1.5f);
		} else {
			SC.PLAYER1DESTINATION = SC.DESTINATION + new Vector3 (0.85f, 0, 0.85f);
			SC.PLAYER1DESTINATION.y = SC.PLAYER1.GetComponent<CharacterController> ().transform.position.y;
			if (SC.PLayer2NetRushing.isOn == false)
				SC.PLAYER2DESTINATION = new Vector3 (0, SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y, 12);
			else
				SC.PLAYER2DESTINATION = new Vector3 (0, SC.PLAYER2.GetComponent<CharacterController> ().transform.position.y, 1.5f);
		}*/
		SC.PLAYER1DESTINATION = P1DES;
		SC.PLAYER2DESTINATION = P2DES;
		SC.DESTINATION = DES;		
		Debug.DrawRay (new Vector3 (SC.DESTINATION.x, -2, SC.DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.blue, 1.5f);
		Debug.DrawRay (new Vector3 (SC.DESTINATION.x, -2, SC.DESTINATION.z), new Vector3 (0, 10, 0) * 10, Color.green, 0.5f);


		SC.PLAYER2.transform.rotation = Quaternion.LookRotation (SC.PLAYER2DESTINATION - SC.PLAYER2.transform.position);
		SC.PLAYER1.transform.rotation = Quaternion.LookRotation (SC.PLAYER1DESTINATION - SC.PLAYER1.transform.position);
	}

	[Command]
	public void Cmdmessage(int a, int b){
		Rpcmessage (a, b);
	}

	[ClientRpc]
	public void Rpcmessage(int a, int b){
		string[] winmessage = {"Ohhhhh", "perfect", "i am so good", "that was my real skill", "you are unlucky", "better next time", "sorry", "i am crazy",
			"you should play more", "i am very good", "my shot is unbelieveable", "it is unreturnable", "you need more level bro",
			"i am the champion", "i am the best", "your fault", "not my fault bro", "don't give up", "you are very chicken bro", "you are too easy bro"
		};
		string[] losemessage = {"Hmnmmmmmmmmmm", "it was a nice shot", "it was close", "i am unlucky", "i will try next time", "it was bad", "why u so good bro",
			"i should play more", "you are good bro", "your shot is unbelievealbe bro", "my bad", "i need more level",
			"i am never the loser", "this is not easy bro", "it is my fault", "not my fault bro", "i never give up", "not me for now", "it was too hard bro", 
			"nothing is impossible bro"
		};

		GameManager GAMEMANAGER;
		GAMEMANAGER = GameObject.Find ("GameManager").GetComponent<GameManager>();
		if (GAMEMANAGER != null && GAMEMANAGER.WhoIAm == 1)
			return;
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal> ();


		Image msg = (Image) Instantiate (SC.message, Vector3.zero, Quaternion.identity);
		msg.gameObject.transform.SetParent (SC.canvas1.transform);
		if (a == 1) {
			msg.gameObject.transform.GetChild (0).GetComponent<Text> ().text = winmessage [b];
		} else {
			msg.gameObject.transform.GetChild (0).GetComponent<Text> ().text = losemessage [b];
		}
		Vector2 tmp = Camera.main.WorldToScreenPoint (SC.PLAYER1.transform.position);
		if (SC.PLAYER1.transform.position.x > 0) {
			msg.transform.position = new Vector3 (tmp.x - 140, tmp.y + 100);
		} else {
			msg.transform.position = new Vector3 (tmp.x + 140, tmp.y + 100);
		}

		Destroy (msg.gameObject, 3.5f);
	}

	[Command]
	public void Cmdmessage2(int a, int b){
		SceneControllerOnlineFinal SC = GameObject.Find ("SceneController").GetComponent<SceneControllerOnlineFinal> ();
		string[] winmessage = {"Ohhhhh", "perfect", "i am so good", "that was my real skill", "you are unlucky", "better next time", "sorry", "i am crazy",
			"you should play more", "i am very good", "my shot is unbelieveable", "it is unreturnable", "you need more level bro",
			"i am the champion", "i am the best", "your fault", "not my fault bro", "don't give up", "you are very chicken bro", "you are too easy bro"
		};
		string[] losemessage = {"Hmnmmmmmmmmmm", "it was a nice shot", "it was close", "i am unlucky", "i will try next time", "it was bad", "why u so good bro",
			"i should play more", "you are good bro", "your shot is unbelievealbe bro", "my bad", "i need more level",
			"i am never the loser", "this is not easy bro", "it is my fault", "not my fault bro", "i never give up", "not me for now", "it was too hard bro", 
			"nothing is impossible bro"
		};
		GameManager GAMEMANAGER;
		GAMEMANAGER = GameObject.Find ("GameManager").GetComponent<GameManager>();
		if (GAMEMANAGER != null && GAMEMANAGER.WhoIAm == 2)
			return;
		Image msg = (Image) Instantiate (SC.message, Vector3.zero, Quaternion.identity);
		msg.gameObject.transform.SetParent (SC.canvas1.transform);
		if (a == 1) {
			msg.gameObject.transform.GetChild (0).GetComponent<Text> ().text = winmessage [b];
		} else {
			msg.gameObject.transform.GetChild (0).GetComponent<Text> ().text = losemessage [b];
		}
		Vector2 tmp = Camera.main.WorldToScreenPoint (SC.PLAYER2.transform.position);
		if (SC.PLAYER2.transform.position.x > 0) {
			msg.transform.position = new Vector3 (tmp.x - 140, tmp.y + 100);
		} else {
			msg.transform.position = new Vector3 (tmp.x + 140, tmp.y + 100);
		}

		Destroy (msg.gameObject, 3.5f);
	}

}
