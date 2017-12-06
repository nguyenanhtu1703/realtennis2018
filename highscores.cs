using UnityEngine;
using System.Collections;
using System;

public class highscores : MonoBehaviour {
	public Highscore2[] liveatp = new Highscore2[]{
		new Highscore2("Andy Murray", 11540, "UK"),
		new Highscore2("Novak Djokovic", 9825, "serbia"),
		new Highscore2("Milos Raonic", 4930, "canada"),
		new Highscore2("Stan Wawrinka", 5695, "suinia"),
		new Highscore2("Kei Nishikori", 4625, "japan"),
		new Highscore2("Gael Mofils", 3145, "france"),
		new Highscore2("Marin Cilic", 3320, "croatia"),
		new Highscore2("Dominic Thiem", 3375, "austria"),
		new Highscore2("Rafael Nadal", 4115, "spain"),
		new Highscore2("Tomas Berdych", 2745, "czech"),
		new Highscore2("David Goffin", 3035, "belgium"),
		new Highscore2("Jo-Wilfried Tsonga", 2730, "france"),
		new Highscore2("Roberto Bautista Agut", 2190, "spain"),
		new Highscore2("Nick Kyrgios", 2165, "austriallian"),
		new Highscore2("Lucas Pouille", 2131, "france"),
		new Highscore2("Grigor Dimitrov", 2925, "bulgari"),
		new Highscore2("Roger Federer", 3260, "suinia"),
		new Highscore2("Richard Gasquet", 1830,  "france"),
		new Highscore2("John Isner", 1715, "usa"),
		new Highscore2("Ivo Karlovic", 1875, "croatia"),
		new Highscore2("David Ferrer", 1310, "spain"),
		new Highscore2("Pablo Cuevas", 1290, "uruway"),
		new Highscore2("Jack Sock", 1855, "usa"),
		new Highscore2("Alexander Zverev", 1895, "germany"),
		new Highscore2("Gilles Simon", 1470, "france"),
		new Highscore2("Bernard Tomic", 1285, "austria"),
		new Highscore2("Albert Ramos Vinolas", 1400, "espain"),
		new Highscore2("Feliciano Lopez", 1330, "espain"),
		new Highscore2("Viktor Troicki", 1075, "serbia"),
		new Highscore2("Pablo Carreno Busta", 1450, "espain"),
		new Highscore2("Sam Querrey", 1135, "usa"),
		new Highscore2("Philipp Kohlschreiber", 1270, "germany"),
		new Highscore2("Steve Johnson", 1345, "usa"),
		new Highscore2("Gilles Muller", 1370, "lux"),
		new Highscore2("Martin Klizan", 685, "slovakia"),
		new Highscore2("Marcos Beghdatis", 1195, "cyprys"),
		new Highscore2("Marcel Granollers", 1068, "spain"),
		new Highscore2("Nicolas Mahut", 850, "italia"),
		new Highscore2("Juan Martin del Potro", 1020, "aghentia"),
		new Highscore2("Fernando Verdasco", 1070, "spain"),
		new Highscore2("Paolo Lorenzi", 1052, "italia"),
		new Highscore2("Nicolas Almagro", 845, "spain"),
		new Highscore2("Federico Delbonis", 860, "aghentia"),
		new Highscore2("Joao Sousa", 1055, "portugal"),
		new Highscore2("Kyle Edmund", 898, "uk"),
		new Highscore2("Benoit Paire", 1040, "france"),
		new Highscore2("Fabio Fognini", 955, "italia"),
		new Highscore2("Andrey Kuznetsov", 790, "russia"),
		new Highscore2("Florian Mayer", 913, "germany"),
		new Highscore2("Mischa Zverev", 1216, "germany"),
		new Highscore2("Karen Khachanov", 904, "russia"),
		new Highscore2("Diego Schwartzman", 845, "aghentina"),
		new Highscore2("Stephane Robert", 660, "france"),
		new Highscore2("Jiri Vesely", 848, "czech"),
		new Highscore2("Facundo Bagnis", 657, "aghentina"),
		new Highscore2("Malek Jaziri", 908, "tusinia"),
		new Highscore2("Borna Coric", 750, "croatia"),
		new Highscore2("Robin Haase", 833, "nadeland"),
		new Highscore2("Mikhail Youzhny", 631, "russia"),
		new Highscore2("Yen Hsun Lu", 780, "taipen"),
		new Highscore2("Thomaz Bellucci", 676, "brazil"),
		new Highscore2("Alexandr Dolgopplov", 925, "ukraina"),
		new Highscore2("Jan Lennard Struff", 786, "germany"),
		new Highscore2("Adrian Mannarino", 791, "germany"),
		new Highscore2("Juan Monaco", 720, "argentina"),
		new Highscore2("Daniel Evans", 971, "uk"),
		new Highscore2("Kevin Anderson", 680, "uk"),
		new Highscore2("Horacio Zeballos", 686, "arghentina"),
		new Highscore2("Dustin Brown", 651, "germany"),
		new Highscore2("Denis Istomin", 718, "Uzuberkistan"),
		new Highscore2("Jeremy Chardy", 670, "france"),
		new Highscore2("Adam Pavlasek", 659, "czech"),
		new Highscore2("Guillermo Garcia Lopez", 595, "spain"),
		new Highscore2("Jordan Thompson", 744, "austria"),
		new Highscore2("Pierre Hugues Herbert", 698, "france"),
		new Highscore2("Damir Dzumhur", 637, "bih"),
		new Highscore2("Daniil Medvedev", 779, "russia"),
		new Highscore2("Paul Henri Mathieu", 578, "france"),
		new Highscore2("Renzo Olivo", 605, "arghentina"),
		new Highscore2("Guido Pella", 685, "arghentina"),
		new Highscore2("Steve Darcis", 822, "belgium"),
		new Highscore2("Gastao Elias", 641, "portugal"),
		new Highscore2("Thiago Monteiro", 608, "brazil"),
		new Highscore2("Gerald Melzer", 497, "austria"),
		new Highscore2("John Millman", 655, "austria"),
		new Highscore2("Andreas Sippe", 700, "italia"),
		new Highscore2("Donald Young", 656, "usa"),
		new Highscore2("Dudi Sela", 686, "irsarel"),
		new Highscore2("Ryan Harrison", 746, "usa"),
		new Highscore2("Santiago Giraldo", 567, "columpia"),
		new Highscore2("Taylor Fritz", 513, "usa"),
		new Highscore2("Dusan Lajovic", 597, "serbia"),
		new Highscore2("Konstantin Kravchuk", 604, "uk"),
		new Highscore2("Illya Marchenko", 604, "ukraina"),
		new Highscore2("Nikoloz Basilashvili", 714, "geo"),
		new Highscore2("Carlo Berlocq", 668, "arghentina"),
		new Highscore2("Rogerio Dutra Silva", 628, "brazil"),
		new Highscore2("Mikhail Kukushkin", 573, "kazaktan"),
		new Highscore2("Radu Albot", 623, "mda"),
		new Highscore2("Ricardas Berankis", 490, "lutina"),
		new Highscore2("Yoshihito Nishioka", 609, "japan"),
		new Highscore2("Hyeon Chung", 653, "korea"),
		new Highscore2("Frances tiafoe", 614, "usa"),
		new Highscore2("Victor Estrella Burgos", 604, "unknow"),
		new Highscore2("Janko Tipsarevic", 603, "czech"),
		new Highscore2("Radek Stepanek", 595, "france"),

	};

	public Highscore2[] livewta = new Highscore2[]{
		new Highscore2("Angelique Kerber", 8875, "germany"),
		new Highscore2("Serena Williams", 7080, "usa"),
		new Highscore2("Agnieszka Radwanska", 5420, "poland"),
		new Highscore2("Simona Halep", 5257, "romani"),
		new Highscore2("Karolina Pliskova", 4970, "czech"),
		new Highscore2("Dominika Cibulkova",  4875, "slovakia"), 
		new Highscore2("Garbine Muguruza", 4420, "spain"),
		new Highscore2("Madison Key", 4137, "usa"),
		new Highscore2("Svetlana Kuznetsova", 4115, "russia"),
		new Highscore2("Johanna Konoto", 3690, "germany"),
		new Highscore2("Petra Kvitova", 3485, "czech"),
		new Highscore2("Carla Suarez Novarro", 2985, "spain"),
		new Highscore2("Elina Svitolonona", 2895, "ukraina"),
		new Highscore2("Victoria Azarenka", 2591, "belarus"),
		new Highscore2("Timea Bacsinszky", 2347, "neitheyland"),
		new Highscore2("Venus Williams", 2240, "usa"),
		new Highscore2("Elena Vesenana", 2229, "russia"),
		new Highscore2("Roberta Vinci", 2210, "italia"),
		new Highscore2("Barbora Strycova", 2170, "czech"),
		new Highscore2("Caroline Wozniacki", 2135, "uk"),
		new Highscore2("Samantha Stosur", 2115, "austriallan"),
		new Highscore2("Kiki Bertens", 1974, "russia"),
		new Highscore2("Shuai Zhang", 1885, "china"),
		new Highscore2("Caroline Garcia", 1765, "france"),
		new Highscore2("Daria Gavrilova", 1665, "austrllian"),
		new Highscore2("Daria Kasatkina", 1655, "rusian"),
		new Highscore2("Anastasia Pavlyuchenkova", 1575, "russia"),
		new Highscore2("Timea Babos", 1545, "hun"),
		new Highscore2("Laura Siegemund", 1513, "germany"),
		new Highscore2("Irina-Camelia Begu", 1502, "romani"),
		new Highscore2("Alize Cornet", 1492, "france"),
		new Highscore2("Monica Puig", 1490, "pur"),
		new Highscore2("Ekaterina Makorovo", 1476, "russia"),
		new Highscore2("Yulia Putintseva", 1450, "kazaktan"),
		new Highscore2("Anastasija Sevastova", 1425, "latovia"),
		new Highscore2("Ana Konjuh", 1351, "croatia"),
		new Highscore2("Katerina Siniakova", 1343, "czech"),
		new Highscore2("Coco Vandeweghe", 1312, "usa"),
		new Highscore2("Jelena Ostapenko", 1305, "lativa"),
		new Highscore2("Monica Niculescu", 1300, "romani"),
		new Highscore2("Yaroslava Shvedova", 1284, "kazaktan"),
		new Highscore2("Misaki Doi", 1270, "japan"),
		new Highscore2("Christina McHale", 1250, "usa"),
		new Highscore2("Alison RiskE", 1247, "usa"),
		new Highscore2("Kristina Mladenovic", 1240, "france"),
		new Highscore2("Lauren Davis", 1226, "usa"),
		//new Highscore2("Katerina Siniakova", 1243, "czech"),
		new Highscore2("Naomi Osiki", 1203, "japan"),
		new Highscore2("Belinda Bencic", 1185, "suinia"),
		new Highscore2("Eugenie Bouchard", 1180, "canada"),
		new Highscore2("Sara Errani", 1155, "italia"),
		new Highscore2("Johanna Larsson", 1150, "sweeden"),
		new Highscore2("Sloane Stephens", 1137, "usa"),
		//new Highscore2("Lauren Davis", 1126, "usa"),
		new Highscore2("Annika Beck", 1125, "germany"),
		new Highscore2("Jelena Jonkovic", 1100, "serbia"),
		new Highscore2("Andrea Petkovic", 1045, "germany"),
		new Highscore2("Julia Goerges", 1040, "germany"),
		new Highscore2("Viktorija Golubic", 1031, "sweedent"),
		new Highscore2("Shelby Rogers", 1031, "usa"),
		new Highscore2("Yanina Wickmayer", 1013, "belgium"),
		new Highscore2("Kristyna Pliskova", 1012, "czech"),
		new Highscore2("Lesia Tsurenko", 1003, "ukraina"),
		new Highscore2("Lucie Safarova", 969, "czech"),
		new Highscore2("Tsvetana Pironkova", 961, "bulgari"),
		new Highscore2("Lara Arruabarrena", 923, "spain"),
		new Highscore2("Louisa Chirico", 908, "usa"),
		new Highscore2("Pauline Parmentier", 886, "france"),
		new Highscore2("Danka Kovinic", 885, "mne"),
		new Highscore2("Kateryna Bondarenko", 884, "ukraina"),
		new Highscore2("Madison Brengle", 875, "usa"),
		new Highscore2("Qiang Wang", 874, "china"),
		new Highscore2("Oceane Dodin", 867, "france"),
		new Highscore2("Camila Giorgi", 866, "italia"),
		new Highscore2("Kirsten Flipkini", 860, "belgium"),
		new Highscore2("Catherine Beles", 841, "usa"),
		new Highscore2("Heather Watson", 824, "germany"),
		new Highscore2("Kurumi Nara", 813, "japan"),
		new Highscore2("Anna-Lena Friedsam", 804, "germany"),
		new Highscore2("Sorana Cirstea", 799, "romani"),
		new Highscore2("Mirjana Lucici-Baroni", 798, "croatia"),
		new Highscore2("Vania King", 794, "usa"),
		new Highscore2("Kristina Kucova", 766, "slovakia"),
		new Highscore2("Shuai Peng", 763, "china"),
		new Highscore2("Saisai Zheng", 758, "china"),
		new Highscore2("Evgeniya Rodina", 756, "russia"),
		new Highscore2("Cagla Buyukakcay", 755, "turkey"),
		new Highscore2("Varvara Lepchenko", 738, "usa"),
		new Highscore2("Carina Witthoeft", 736, "usa"),
		new Highscore2("Su-Wei Hsieh", 721, "teipein"),
		new Highscore2("Denisa Allertova", 718, "czech"),
		new Highscore2("Nicole Gibbs", 696, "usa"),
		new Highscore2("Sabine Lisicki", 695, "germany"),
		new Highscore2("Irina Khromacheva", 682, "russia"),
		new Highscore2("Magda Linette", 681, "poland"),
		new Highscore2("Maria Sakkari", 678, "sweeden"),
		new Highscore2("Naomi Broady", 672, "uk"),
		new Highscore2("Francesca Schiavone", 659, "italia"),
		new Highscore2("Donna Vekic", 658, "Croania"),
		new Highscore2("Kateryna Kozlova", 654, "Ukraona"),
		new Highscore2("Nao Hibino", 652, "japan"),
		new Highscore2("Risa Ozaki", 652, "japan")
	};
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

	public string privateCode;
	public string privatecode1 = "ZdKBT2IEvkWy1OBQETy-dQUHiXqfEeZEKO6dHb6R-wBg", privatecode2 = "WUzbY1Ic_UCkK5nhZqZKbgeZgz1hIup0SbZpfeOBk1iQ", privatecode3 = "ssEgzioz_Uqcq4vEXraldwpu80PTxzikCIZnfXf0H7sA";
	const string publicCode = "583c2c9f8af6030f3ca19f12";
	const string webURL = "http://dreamlo.com/lb/";

	public Highscore[] highscoresList;
	DisplayHighscores highscoreDisplay;
	static highscores instance = null;
	bool didupmyscore = false;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if(instance != this){
			Destroy (this.gameObject);
		}	
		highscoreDisplay = GetComponent<DisplayHighscores> ();
		privateCode = privatecode2;
	}

	public void liveatppress(){
		privateCode = privatecode2;
		DownloadHighscores ();
	}

	public void top100press(){
		privateCode = privatecode1;
		DownloadHighscores ();
	}

	public void livewtapress(){
		privateCode = privatecode3;
		DownloadHighscores ();
	}

	public void upatp(){
		privateCode = privatecode2;
		for (int i = 0; i < liveatp.Length; i++) {
			AddNewHighScore (modify(liveatp [i].username) + "^$", liveatp [i].score, dp (liveatp [i].country));
		}
	}

	public void upwta(){
		privateCode = privatecode3;
		for (int i = 0; i < livewta.Length; i++) {
			AddNewHighScore (modify(livewta [i].username) + "^$", livewta[i].score, dp (livewta[i].country));
		}
	}

	public int dp(string tmp){
		int result = 0;
		int best = 1000;
		for (int i = 0; i <= 196; i++)
		{
			int n = countries [i].Length, m = tmp.Length;
			int[,] dp;
			dp = new int[n + 1, m + 1];
			for (int k = 0; k <= n; k++)
				dp [k, 0] = k;
			for (int k = 0; k <= m; k++)
				dp [0, k] = k;
			for (int k = 1; k <= n; k++)
				for (int l = 1; l <= m; l++) {
					dp [k, l] = dp [k - 1, l - 1] + 1;
					if (countries [i] [k - 1] == tmp [l - 1]) {
						dp [k, l] = dp [k - 1, l - 1];
					} else {
						dp [k, l] = Mathf.Min (dp [k - 1, l - 1], Mathf.Min (dp [k - 1, l], dp [k, l - 1])) + 1;
					}
				}
			if (dp [n, m] < best) {
				result = i;
				best = dp [n, m];
			}
		}
		return result;
	}

	public void set(){
		dataplayers tmp = GameObject.Find ("DataPlayer").GetComponent<dataplayers>();
		for (int i = 180; i < 200; i++) {
			PlayerPrefs.SetInt (tmp.atp[i] + "score", 3000);
			PlayerPrefs.SetInt (tmp.atp [i] + "country", (int)(UnityEngine.Random.Range(2, 180)));
		}
		for (int i = 180; i < 200; i++) {
			PlayerPrefs.SetInt (tmp.wta[i] + "score", 3000);
			PlayerPrefs.SetInt (tmp.wta [i] + "country", (int)(UnityEngine.Random.Range(2, 180)));
		}
	}

	public void refresh(){
		dataplayers tmp = GameObject.Find ("DataPlayer").GetComponent<dataplayers>();
		for (int i = 180; i < 200; i++) {
			int ttmp = PlayerPrefs.GetInt (tmp.atp[i] + "score");
			ttmp += 25 * (int)(UnityEngine.Random.Range(-10, 10));
			PlayerPrefs.SetInt (tmp.atp[i] + "score", ttmp);
			int tttmp = PlayerPrefs.GetInt (tmp.atp [i] + "country");
			StartCoroutine(deletescorebot (modify(tmp.atp[i]), ttmp, tttmp));
		}
		for (int i = 180; i < 200; i++) {
			int ttmp = PlayerPrefs.GetInt (tmp.wta[i] + "score");
			ttmp += 25 * (int)(UnityEngine.Random.Range(-10, 10));
			PlayerPrefs.SetInt (tmp.wta[i] + "score", ttmp);
			int tttmp = PlayerPrefs.GetInt (tmp.wta [i] + "country");
			StartCoroutine(deletescorebot (modify(tmp.wta[i]), ttmp, tttmp));
		}
	}

	IEnumerator deletescorebot(string myoldnamemmr, int score, int country){
		WWW www = new WWW ("http://dreamlo.com/lb/" + privateCode + "/delete/"  + (myoldnamemmr + "^$12345678"));
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			string myname;
			myname = modify (myoldnamemmr);
			myname += "^$" + "12345678";
			AddNewHighScore (myname, score, country);
		} else {
			print ("Unsuccessful delete " + myoldnamemmr);
			string myname;
			myname = modify (myoldnamemmr);
			myname += "^$" + "12345678";
			AddNewHighScore (myname, score, country);
		}
	}


	void Start(){
		uploadscore ();
	}

	public void deleteallscore(){
		StartCoroutine ("DeleteAllScore");
	}

	IEnumerator DeleteAllScore(){
		WWW www = new WWW ("http://dreamlo.com/lb/" + privateCode + "/clear");
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			print ("Delete All Score Successful");
			DownloadHighscores ();
		} else {
			print ("Delete All Score Error " + www.error);
		}
	}

	int find(string tmp){
		for (int i = 0; i < 197; i++)
			if (string.Compare (tmp, countries [i]) == 0)
				return i;
		return 0;
	}

	IEnumerator deletemyscore(string myoldnamemmr){
		WWW www = new WWW ("http://dreamlo.com/lb/" + privateCode + "/delete/" + myoldnamemmr);
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			print ("Successful delete my old name " + myoldnamemmr);
			string myname = PlayerPrefs.GetString("myname");
			myname = modify (myname);
			myname += "^$" + PlayerPrefs.GetInt ("myid").ToString();
			PlayerPrefs.SetString ("myoldnamemmr", myname);
			int mycountry = find (PlayerPrefs.GetString ("mycountry"));
			if (System.String.Compare (privateCode, privatecode1) != 0)
				yield break;
			if (didupmyscore = true)
				yield break;
			AddNewHighScore (myname, PlayerPrefs.GetInt ("mymmr"), mycountry);
			didupmyscore = true;
		} else {
			print ("Unsuccessful delete " + myoldnamemmr);
		}
	}

	string modify(string tmp){
		string result = "";
		for (int i = 0; i <= tmp.Length - 1; i++)
			if (tmp [i] == ' ')
				result = result + "+";
			else if((int)tmp[i] > 250) 
				result = result + "@";
			else
				result = result + tmp [i].ToString ();
		return result;
	}


	public void uploadscore(){
		string myoldnamemmr = PlayerPrefs.GetString("myoldnamemmr");
		if (didupmyscore == true)
			return;
		StartCoroutine (deletemyscore(myoldnamemmr));
	}

	public static void AddNewHighScore(string username,  int score, int country){
		instance.StartCoroutine (instance.UploadNewHighScore (username, score, country));
	}

	IEnumerator UploadNewHighScore(string username, int score, int country){
		WWW www = new WWW (webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score + "/" + country);
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			print ("add successufll " + username);
			DownloadHighscores ();
		} else {
			print ("Upload error " + username);
		}
	}

	public void DownloadHighscores(){
		StartCoroutine ("DownloadNewHighScoreFromDatabase");
	}

	IEnumerator DownloadNewHighScoreFromDatabase(){
		WWW www = new WWW (webURL + privateCode + "/pipe/");
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			//print (www.text);
			FormatHighscores (www.text);
			highscoreDisplay.OnHighscoreDownload (highscoresList);
		} else {
		//	print ("Upload error " + www.error);
		}
	}

	void FormatHighscores(string textStream){
		string[] entries = textStream.Split (new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];
		Debug.Log (highscoresList.Length + " NGUYEN ANH TU");
		for (int i = 0; i < entries.Length; i++) {
			string[] entryInfo = entries [i].Split (new char[] {'|'});
			string username = entryInfo [0];
			int score = int.Parse(entryInfo [1]);
			int country = int.Parse(entryInfo [2]);
			highscoresList [i] = new Highscore (username, score, country);
		//	print (highscoresList[i].username + ": " + highscoresList[i].score + ", " + highscoresList[i].country);
		}
	}
}

public struct Highscore {
	public string username;
	public int score, country;
	public Highscore(string _username, int _score, int _country){
		username = _username;
		country = _country;
		score = _score;
	}
}


public struct Highscore2{
	public string username;
	public int score;
	public string country;
	public Highscore2(string _username, int _score, string _country){
		username = _username;
		country = _country;
		score = _score;
	}
}
