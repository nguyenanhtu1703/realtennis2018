using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DisplayHighscores : MonoBehaviour {

	// Use this for initialization
	public Text[] highscoreText;
	highscores highscoreManager;
	public Text myrank;
	public string[] countries = {
	"Afghanistan",
	"Albania",
	"Algeria",
	"Andorra",
	"Angola",
	"Antigua",
	"Argentina",
	"Armenia",
	"Australia",
	"Austria",
	"Azerbaijan",
	"Bahamas",
	"Bahrain",
	"Bangladesh",
	"Barbados",
	"Belarus",
	"Belgium",
	"Belize",
	"Benin",
	"Bhutan",
	"Bolivia",
	"Bosnia",
	"Botswana",
	"Brazil",
	"Brunei",
	"Bulgaria",
	"Burkina Faso",
	"Burundi",
	"Cabo Verde",
	"Cambodia",
	"Cameroon",
	"Canada",
	"CAR",
	"Chad",
	"Chile",
	"China",
	"Colombia",
	"Comoros",
	"Democratic",
	"Congo",
	"Costa Rica",
	"Cote",
	"Croatia",
	"Cuba",
	"Cyprus",
	"Czech",
	"Denmark",
	"Djibouti",
	"Dominica",
	"Dominican Republic",
	"Ecuador",
	"Egypt",
	"El Salvador",
	"Equatorial Guinea",
	"Eritrea",
	"Estonia",
	"Ethiopia",
	"Fiji",
	"Finland",
	"France",
	"Gabon",
	"Gambia",
	"Georgia",
	"Germany",
	"Ghana",
	"Greece",
	"Grenada",
	"Guatemala",
	"Guinea",
	"Guinea Bissau",
	"Guyana",
	"Haiti",
	"Honduras",
	"Hungary",
	"Iceland",
	"India",
	"Indonesia",
	"Iran",
	"Iraq",
	"Ireland",
	"Israel",
	"Italy",
	"Jamaica",
	"Japan",
	"Jordan",
	"Kazakhstan",
	"Kenya",
	"Kiribati",
	"Kosovo",
	"Kuwait",
	"Kyrgyzstan",
	"Laos",
	"Latvia",
	"Lebanon",
	"Lesotho",
	"Liberia",
	"Libya",
	"Liechtenstein",
	"Lithuania",
	"Luxembourg",
	"Macedonia",
	"Madagascar",
	"Malawi",
	"Malaysia",
	"Maldives",
	"Mali",
	"Malta",
	"Marshall Islands",
	"Mauritania",
	"Mauritius",
	"Mexico",
	"Micronesia",
	"Moldova",
	"Monaco",
	"Mongolia",
	"Montenegro",
	"Morocco",
	"Mozambique",
	"Myanmar",
	"Namibia",
	"Nauru",
	"Nepal",
	"Netherlands",
	"New Zealand",
	"Nicaragua",
	"Niger",
	"Nigeria",
	"North Korea",
	"Norway",
	"Oman",
	"Pakistan",
	"Palau",
	"Palestine",
	"Panama",
	"Papua New Guinea",
	"Paraguay",
	"Peru",
	"Philippines",
	"Poland",
	"Portugal",
	"Qatar",
	"Romania",
	"Russia",
	"Rwanda",
	"Saint Kitts",
	"Saint Lucia",
	"Saint Vincent",
	"Samoa",
	"San Marino",
	"Sao Tome and Principe",
	"Saudi Arabia",
	"Senegal",
	"Serbia",
	"Seychelles",
	"Sierra Leone",
	"Singapore",
	"Slovakia",
	"Slovenia",
	"Solomon Islands",
	"Somalia",
	"South Africa",
	"South Korea",
	"South Sudan",
	"Spain",
	"Sri Lanka",
	"Sudan",
	"Suriname",
	"Swaziland",
	"Sweden",
	"Switzerland",
	"Syria",
	"Taiwan",
	"Tajikistan",
	"Tanzania",
	"Thailand",
	"Timor Leste",
	"Togo",
	"Tonga",
	"Trinidad and Tobago",
	"Tunisia",
	"Turkey",
	"Turkmenistan",
	"Tuvalu",
	"Uganda",
	"Ukraine",
	"Uae",
	"Uk",
	"Usa",
	"Uruguay",
	"Uzbekistan",
	"Vanuatu",
	"Vatican",
	"Venezuela",
	"Vietnam",
	"Yemen",
	"Zambia",
	"Zimbabwe"
};


	void Start(){
		for (int i = 0; i < highscoreText.Length; i++) {
			highscoreText [i].text = i + 1 + ". Fetching...";
		}
		highscoreManager = GetComponent<highscores> ();
		StartCoroutine ("RefreshHighscores");
	}

	public void OnHighscoreDownload(Highscore[] highscoreList){
		Debug.Log ("Okyeah " + highscoreList.Length);
		int rank = 678713;
		for (int i = 0; i < highscoreList.Length; i++) {
			if (String.Compare(highscoreList [i].username, PlayerPrefs.GetString ("myoldnamemmr")) == 0) {
				rank = i + 1;
			}
		}
		if (rank != 678713)
			myrank.text = rank.ToString ();
		else {
			for (int i = 0; i < highscoreList.Length; i++) {
				if (highscoreList [i].score == PlayerPrefs.GetInt ("mymmr")) {
					rank = i + 1;
				}
			}	
			if (rank != 678713)
				myrank.text = rank.ToString ();
		}
		for (int i = 0; i < highscoreText.Length; i++) {
			highscoreText [i].text = "";
			if (highscoreList.Length > i) {
				string tmp = highscoreList [i].username;
				int mycountry = highscoreList [i].country;
				int mmr = highscoreList [i].score;
				string tmp2 = "";
				for (int j = 0; j < tmp.Length - 1; j++)
					if (tmp [j] == '^' && tmp [j + 1] == '$')
						break;
					else {
						if (tmp [j] == '+')
							tmp2 = tmp2 + " ";
						else 
							tmp2 = tmp2 + tmp [j].ToString ();
					}
				highscoreText [i].text = tmp2;
				//Debug.Log (mycountry);
				highscoreText [i].transform.GetChild (1).GetComponent<Image> ().sprite = (Sprite)Resources.Load ("flag-of-" + countries[mycountry], typeof(Sprite));
				highscoreText [i].transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
				highscoreText [i].transform.GetChild (2).GetComponent<Text> ().text = mmr.ToString ();
			}
		}
	}

	IEnumerator RefreshHighscores(){
		while (true) {
			//if(string.Compare(Highscore.))
			highscoreManager.DownloadHighscores ();
			yield return new WaitForSeconds (30);
		}
	}
}
