using UnityEngine;
using UnityEngine.Advertisements;

public class unityads : MonoBehaviour
{
	public static unityads instance = null;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if(instance != this){
			Destroy (this.gameObject);
			return;
		}	
		DontDestroyOnLoad (this.gameObject);
	}

	public void ShowAd()
	{
		
		if (Advertisement.IsReady())
		{
			if (PlayerPrefs.GetInt ("ads") == 0) {
				Advertisement.Show ();
			}
		}
	} 

	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			PlayerPrefs.SetInt ("myenergy", PlayerPrefs.GetInt ("myenergy") + 500);
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}