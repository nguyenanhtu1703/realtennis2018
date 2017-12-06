using UnityEngine;
using System.Collections;

public class dataplayers : MonoBehaviour {

	// Use this for initialization

	public string[] atp = {
		"Andy murrai",
		"Novak Djokivi",
		"Stan Wawronk",
		"Milos Rani",
		"KeiNishoko",
		"Gael Mofi",
		"Marin Colo",
		"Rafael Nidi",
		"Dominic Thi",
		"Tomas Bird",
		"David Gefi",
		"Jo-Wied Tsog",
		"Nick Kigi",
		"Roberto Buti",
		"Lucas Puil",
		"Roger Fidir",
		"Grigor Domot",
		"Richard Gusqi",
		"John Isni",
		"Ivo Kirlivo",
		"David Firri",
		"Pablo Cevi",
		"Jack Sex",
		"Alexander Zviri",
		"Gilles Somo",
		"Bernard Time",
		"Albert Ram Vinele",
		"Feliciano Lipi",
		"Viktor Trici",
		"Pablo Carrin Busti",
		"Sam Qerri",
		"Philipp Kehlschri",
		"Steve Jehnse",
		"Gilles Muli",
		"Martin Kliri",
		"Marcos Beghdi",
		"Marcel Gronoli",
		"Juan Morton dol Potro",
		"Nicolas Maha",
		"Paolo Lorinza",
		"Federico Dilbina",
		"Fernando Virda",
		"Joao Sisi",
		"Nicolas Almigri",
		"Kyle Egmind",
		"Andrey Kiznitsex",
		"Benoit Peiri",
		"Borna Ciri",
		"Fabio Fognono",
		"Florian Miri",
		"Mischa Zviri",
		"Karen Khecene",
		"Stephane Ribit",
		"Jiri Vesolo",
		"Facundo Bini",
		"Mikheil Yuzhni",
		"Malok Jazoro",
		"Diago Schwortzmi",
		"Guido Pili",
		"Robin Hisi",
		"Adrian Mannarana",
		"Thomaz Bolloco",
		"Alexande Delgipiliv",
		"Jan Lennord Straf",
		"Yon Hson Lo",
		"Danoal Evens",
		"Dostan Brewn",
		"Juon Minici",
		"Kevon Andirsi",
		"Toyler Fratzi",
		"Gerold Melzi",
		"Jerimi Chordi",
		"Guillermi Garco Lopi",
		"Horaci Zebell",
		"Illyi Merchenku",
		"Pul Henro Mathi",
		"Adim Pivlosk",
		"Inagi Cervanti",
		"Damir Dzimhor",
		"Pierre Huges Herbert",
		"Jordin Thompsin",
		"Konstintin Krivchuk",
		"Gisti Eli",
		"Thig Mintiri",
		"Rinzi Olive",
		"Jehn Millmin",
		"Stive Dircas",
		"Andris Sippe",
		"Donald Old",
		"Dudi Solo",
		"Rian Hirrasi",
		"Mokhi Kikishku",
		"Suteago Garildi",
		"Ricirdis Berunkas",
		"Dusun Lajivi",
		"Nikoliz Basilishvala",
		"Rada Albet",
		"Dano Medvidiv",
		"Carlo Birlicq",
		"Aljiz Bedini",
		"ASASASASAAS",
		"DFASDFAD",
		"ASDFASDFA",
		"ASDFASDF76",
		"ASDFAS7DFA7",
		"ASDFA7SDFA",
		"ASDF76ASDFA",
		"ASDFASD7uFA",
		"ASDFAS67DFA",
		"ASDF6ASDFA",
		"ASDFjASDFA",
		"DFASD67FAD",
		"ASDFA67SDFA",
		"ASDFA67SDFA",
		"ASDFA7SDFA",
		"ASDFASjDFA",
		"ASDFAS76DFA",
		"ASDFAS4DFA",
		"ASDFAS4DFA",
		"ASDFAS3DFA",
		"ASDFAS4DFA",
		"ASDFA2SDFA",
		"ASDFAS2DFA",
		"ASDFASD4FA",
		"ASDFAS4DFA",
		"ASDF2ASDFA",
		"ASDFA3SDFA"
	};

	public string[] atpcountries = {
		"Uk",
		"Serbia",
		"Switzerland",
		"Canada",
		"Japan",
		"France",
		"Croatia",
		"Spain",
		"Austria",
		"Czech Republic",
		"Belgium",
		"France",
		"Australia",
		"Spain",
		"France",
		"Switzerland",
		"Bulgaria",
		"France",
		"Usa",
		"Croatia",
		"Spain",
		"Uruguay",
		"Usa",
		"Germany",
		"France",
		"Australia",
		"Spain",
		"Spain",
		"Serbia",
		"Spain",
		"Usa",
		"Germany",
		"Usa",
		"Luxembourg",
		"Slovakia",
		"Cyprus",
		"Spain",
		"Argentina",
		"France",
		"Italy",
		"Uk",
		"Argentina",
		"Spain",
		"Portugal",
		"Spain",
		"Russia",
		"France",
		"Croatia",
		"Italy",
		"Germany",
		"Germany",
		"Russia",
		"France",
		"Czech Republic",
		"Russia",
		"Tunisia",
		"Uk",
		"Argentina",
		"France",
		"Argentina",
		"Holland",
		"Brazil",
		"Ukraine",
		"Germany",
		"Taipei",
		"Argentina",
		"Germany",
		"Ukraine",
		"Argentina",
		"JAR",
		"Australia",
		"France",
		"Usa",
		"Austria",
		"France",
		"Spain",
		"Lithuania",
		"Russia",
		"Bosnia",
		"France",
		"Argentina",
		"Austria",
		"Spain",
		"Czech Republic",
		"Argentina",
		"Portugal",
		"Brazil",
		"Belgium",
		"Argentina",
		"Italy",
		"Usa",
		"Izrael",
		"Usa",
		"Kazakhstan",
		"Serbia",
		"Georgia",
		"ABC",
		"Japan",
		"Japan",
		"Japan"
	};

	public string[] wta = {
		"Angelique Kiribi",
		"Serena Walalam",
		"Agnieszka Rapwonskana",
		"Simona Halapna",
		"Dominika Cibolokovo",
		"Karolina Plaskavo",
		"Garbine Mugaraza",
		"Madison Ki",
		"Svetlana Kuzunetusuvu",
		"Johanna Konoto",
		"Petra Kvitivi",
		"Carla Suraz Novorro",
		"Victoria Ararenke",
		"Elina Svitolonona",
		"Timea Bacsanszakina",
		"Elena Vesenana",
		"Venus Wall",
		"Roberta Vonoco",
		"Caroline Wynycyky",
		"Barbora Strocovo",
		"Samantha Stusuru",
		"Kiki Bertensese",
		"Shuai Zhanaga",
		"Caroline Girici",
		"Daria Gavralava",
		"Timea Boboso",
		"Daria Kasitikini",
		"Anastasia Pavalyachankava",
		"Irina-Camelia Bogo",
		"Ekaterina Makorovo",
		"Laura Siegemenede",
		"Monica Puigigi",
		"Yulia Putintsivi",
		"Anastasija Sevesteve",
		"Sloane Stiphin",
		"Yaroslava Shvedeve",
		"Coco Vandiwighi",
		"Misaki Doiiii",
		"Monica Nicilisci",
		"Alison Risiki",
		"Kristina Mlidinivic",
		"Belinda Boncec",
		"Jelena Ostoponke",
		"Christina McaHala",
		"Alize Cornutu",
		"Eugenie Buchurdu",
		"Naomi Osiki",
		"Ana Konjihi",
		"Sara Ererene",
		"Johanna Larsson",
		"Yanina Wickmiyiri",
		"Annika Bick",
		"Katerina Sinikivi",
		"Julia Goerogos",
		"Jelena Jonkovoc",
		"Andrea Petkivi",
		"Viktorija Goloboc",
		"Lesia Tsurunki",
		"Shelby Rogorso",
		"Kristyna Pliskivi",
		"Lauren Dovos",
		"Kirsten Flipkini",
		"Lucie Saforovo",
		"Ana Ivinivi",
		"Tsvetana Pirakava",
		"Lara Arrabarrana",
		"Anna-Lena Friedsam",
		"Louisa Chiroda",
		"Oceane Dodono",
		"Kateryna Bondoronko",
		"Pauline Parmantara",
		"Danka Kovinic",
		"Qiang Wangana",
		"Madison Brengleqesten",
		"Kurumi Narabama",
		"Nicole Gibbsisisi",
		"Heather Watsisisi",
		"Cagla Buyukukcuy",
		"Vania Kong",
		"Sorana Cirsiti",
		"Mirjana Lucici-Birini",
		"Kristina Kucuvu",
		"Camila Gigi",
		"Saisai Zhingi",
		"Carina Witthifit",
		"Nao Hobono",
		"Varvara Lopchoko",
		"Naomi Brada",
		"Maria Sokoro",
		"Catherine Beles",
		"Sabine Losocko",
		"Risa Oroko",
		"Denisa Allotovo",
		"Magda Liniti",
		"Irina Khromeche",
		"Irina Falcana",
		"Jana Cepolovo",
		"Su-Wu Hsuh",
		"Kotoryno Kozlovo",
		"Frincisi Schivini",
		"DFDSFSFDS",
		"SDFSFSDFSD",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"DFDSFSFDS",
		"SDFSFSDFSD",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"fsdfsdfsdf",
		"ASDFASDFA",
		"ASDFASDFA",
		"ASDFASDFA",
		"ASDFASDFA",
		"ASDFASDFA",
		"ASDFASDFA"
	};

	public string[] wtacountries = {
		"Germany",
		"Usa",
		"Poland",
		"Romania",
		"Slovakia",
		"Czech",
		"Spain",
		"Usa",
		"Russia",
		"Germany",
		"Czech",
		"Spain",
		"Belarus",
		"Ukraina",
		"Switzerland",
		"Russia",
		"Usa",
		"Italia",
		"Denmark",
		"Czech",
		"Austria",
		"Holland",
		"France",
		"China",
		"Austria",
		"Hungary",
		"Russia",
		"Russia",
		"Romania",
		"Russia",
		"Germany",
		"Puerto Rico",
		"Kazakhstan",
		"Kazakhstan",
		"Latvia",
		"Usa",
		"Usa",
		"Japan",
		"Romania",
		"Japan",
		"Usa",
		"France",
		"Switzerland",
		"Latvia",
		"Usa",
		"France",
		"Canada",
		"Hungary",
		"Czech",
		"Italia",
		"Switzerland",
		"Belgium",
		"Germany",
		"Germany",
		"Serbia",
		"Germany",
		"Switzerland",
		"Ukraina",
		"Usa",
		"Usa",
		"Czech",
		"Usa",
		"Belgium",
		"Czech",
		"Serbia",
		"Bulgaria",
		"Turkey",
		"Germany",
		"Spain",
		"China",
		"France",
		"Ukrana",
		"France",
		"ABc",
		"Usa",
		"Usa",
		"Uk",
		"Japan",
		"Usa",
		"Slovakia",
		"Romania",
		"Slovakia",
		"Italia",
		"Japan",
		"Saisai Zhwng",
		"Germany",
		"Usa",
		"Uk",
		"Greece",
		"Usa",
		"Italia",
		"Germany",
		"Russia",
		"Japan",
		"Czech",
		"Poland",
		"Taipei",
		"Ukraina",
		"Usa",
		"Slovakia"
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

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string modify(string s){
		string tmp = s;
		while (tmp.Length > 1 && tmp [0] == ' ')
			tmp = tmp.Remove (0, 1);
		while (tmp.Length > 1 && tmp [tmp.Length - 1] == ' ')
			tmp = tmp.Remove (tmp.Length - 1, 1);
		for(int i = tmp.Length - 2; i >= 0; i--) {
			if (tmp [i] == ' ' && tmp [i + 1] == ' ') {
				tmp = tmp.Remove (i + 1, 1);
			}
		}
		char[] array = tmp.ToCharArray();
		if (array.Length > 0 && array [0] >= 'a' && array [0] <= 'z')
			array [0] = (char)((int)(array[0]) - 32);
		for (int i = array.Length - 1; i >= 1; i--) {
			if (array [i] >= 'A' && array [i] <= 'Z') {
				array [i] = (char)((int)(array[i]) + 32);
			}
			if (array [i - 1] == ' ' && (array [i] >= 'a' && array [i] <= 'z')) {
				array [i] = (char)((int)(array [i]) - 32);
			}
		}
		s = new string (array);
		return s;
	}

	public string find(string s){
		string result = "";
		int best = 1000;
		for (int i = 0; i <= 196; i++)
		{
			int n = countries [i].Length, m = s.Length;
			int[,] dp;
			dp = new int[n + 1, m + 1];
			for (int k = 0; k <= n; k++)
				dp [k, 0] = k;
			for (int k = 0; k <= m; k++)
				dp [0, k] = k;
			for (int k = 1; k <= n; k++)
				for (int l = 1; l <= m; l++) {
					dp [k, l] = dp [k - 1, l - 1] + 1;
					if (countries [i] [k - 1] == s [l - 1]) {
						dp [k, l] = dp [k - 1, l - 1];
					} else {
						dp [k, l] = Mathf.Min (dp [k - 1, l - 1], Mathf.Min (dp [k - 1, l], dp [k, l - 1])) + 1;
					}
				}
			if (dp [n, m] < best) {
				result = countries [i];
				best = dp [n, m];
			}
		}
		return result;
	}

	public void starts(int level, ref  int speed, ref int goal, ref int strong){
		switch (level) {
		case 1:
			speed = 0;
			goal = 0;
			strong = 5;
			break;
		case 2:
			speed = 5;
			goal = 0;
			strong = 5;
			break;
		case 3:
			speed = 5;
			goal = 5;
			strong = 5;
			break;
		case 4:
			speed = 5;
			goal = 10;
			strong = 5;
			break;
		case 5:
			speed = 10;
			goal = 10;
			strong = 5;
			break;
		case 6:
			speed = 10;
			goal = 10;
			strong = 10;
			break;
		case 7:
			speed = 15;
			goal = 5;
			strong = 15;
			break;
		case 8:
			speed = 20;
			goal = 5;
			strong = 15;
			break;
		case 9:
			speed = 5;
			goal = 15;
			strong = 25;
			break;
		case 10:
			speed = 10;
			goal = 0;
			strong = 40;
			break;
		case 11:
			speed = 15;
			goal = 20;
			strong = 20;
			break;
		case 12:
			speed = 20;
			goal = 0;
			strong = 40;
			break;
		case 13:
			speed = 10;
			goal = 0;
			strong = 55;
			break;
		case 14:
			speed = 5;
			goal = 0;
			strong = 65;
			break;
		case 15:
			speed = 35;
			goal = 20;
			strong = 20;
			break;
		case 16:
			speed = 40;
			goal = 0;
			strong = 40;
			break;
		case 17:
			speed = 10;
			goal = 65;
			strong = 10;
			break;
		case 18:
			speed = 30;
			goal = 30;
			strong = 30;
			break;
		case 19:
			speed = 35;
			goal = 35;
			strong = 25;
			break;
		case 20:
			speed = 35;
			goal = 0;
			strong = 65;
			break;
		case 21:
			speed = 35;
			goal = 35;
			strong = 35;
			break;
		case 22:
			speed = 20;
			goal = 40;
			strong = 50;
			break;
		case 23:
			speed = 50;
			goal = 0;
			strong = 65;
			break;
		case 24:
			speed = 0;
			goal = 50;
			strong = 70;
			break;
		case 25:
			speed = 70;
			goal = 0;
			strong = 55;
			break;
		case 26:
			speed = 30;
			goal = 40;
			strong = 60;
			break;
		case 27:
			speed = 35;
			goal = 75;
			strong = 25;
			break;
		case 28:
			speed = 50;
			goal = 60;
			strong = 30;
			break;
		case 29:
			speed = 45;
			goal = 50;
			strong = 50;
			break;
		case 30:
			speed = 50;
			goal = 50;
			strong = 50;
			break;
		case 31:
			speed = 25;
			goal = 30;
			strong = 100;
			break;
		case 32:
			speed = 35;
			goal = 65;
			strong = 60;
			break;
		case 33:
			speed = 65;
			goal = 50;
			strong = 50;
			break;
		case 34:
			speed = 70;
			goal = 50;
			strong = 50;
			break;
		case 35:
			speed = 55;
			goal = 40;
			strong = 80;
			break;
		case 36:
			speed = 60;
			goal = 60;
			strong = 60;
			break;
		case 37:
			speed = 40;
			goal = 60;
			strong = 85;
			break;
		case 38:
			speed = 60;
			goal = 70;
			strong = 60;
			break;
		case 39:
			speed = 65;
			goal = 65;
			strong = 75;
			break;
		case 40:
			speed = 80;
			goal = 80;
			strong = 40;
			break;
		case 41:
			speed = 85;
			goal = 80;
			strong = 40;
			break;
		case 42:
			speed = 60;
			goal = 100;
			strong = 50;
			break;
		case 43:
			speed = 65;
			goal = 80;
			strong = 70;
			break;
		case 44:
			speed = 70;
			goal = 80;
			strong = 70;
			break;
		case 45:
			speed = 85;
			goal = 70;
			strong = 70;
			break;
		case 46:
			speed = 70;
			goal = 90;
			strong = 70;
			break;
		case 47:
			speed = 95;
			goal = 75;
			strong = 65;
			break;
		case 48:
			speed = 75;
			goal = 65;
			strong = 100;
			break;
		case 49:
			speed = 75;
			goal = 100;
			strong = 70;
			break;
		case 50:
			speed = 80;
			goal = 100;
			strong = 70;
			break;
		case 51:
			speed = 85;
			goal = 80;
			strong = 90;
			break;
		case 52:
			speed = 90;
			goal = 80;
			strong = 90;
			break;
		case 53:
			speed = 95;
			goal = 80;
			strong = 90;
			break;
		case 54:
			speed = 85;
			goal = 90;
			strong = 95;
			break;
		case 55:
			speed = 90;
			goal = 95;
			strong = 90;
			break;
		case 56:
			speed = 100;
			goal = 85;
			strong = 95;
			break;
		case 57:
			speed = 100;
			goal = 85;
			strong = 100;
			break;
		case 58:
			speed = 95;
			goal = 100;
			strong = 95;
			break;
		case 59:
			speed = 100;
			goal = 100;
			strong = 95;
			break;
		case 60:
			speed = 100;
			goal = 100;
			strong = 100;
			break;
		default:
			speed = 100;
			goal = 100;
			strong = 100;
			break;
		}
	}
}
