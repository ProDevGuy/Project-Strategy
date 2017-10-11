using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
//using JsonFX.Json;
using System;
using System.Text;
using System.Reflection;

//using Newtonsoft.Json.Linq;
public class initialization : MonoBehaviour {
	//public Text province;
	public string provinceName;
	string path;
	string jsonString;
	public TextMesh provinceNameText;
	public TextMesh provinceOwnerText;
	public Text provinceNameTextUI;
	public Text provinceOwnerTextUI;
	public GameObject camera;
	public Image countryFlag;
	List<string> selection;
	List<int> provIds = new List<int>();
	int daInt = 1;
	//public int timeRunning = 1;
	string theText;
	public string Country_Name;
	public string jsonText;
	public GameObject countryselect;
	public GameObject timeholder;
	int theTextint;
	public Text countryNameTextUI;
	public Text countryMoneyText;
	public Text countryMenText;
	public Sprite ukflag;
	public Sprite usflag;
	changeTime changetime;
	//public Aprovince[] provinces;
	// Use this for initialization
	void Start () {
		//StartCoroutine( HandleIt() );
		//Load();
		PlayerPrefs.SetString("countryName", "United_Kingdom"); //For testing
		changetime = timeholder.GetComponent<changeTime>();
		
		
		Provinces provinces = camera.GetComponent<Provinces>();
		checkCountry();
		countryNameTextUI = countryNameTextUI.GetComponent<Text>();
		countryMoneyText = countryMoneyText.GetComponent<Text>();
		countryMenText = countryMenText.GetComponent<Text>();
		Debug.Log(path);
		jsonString = File.ReadAllText(path);
		Country test = JsonUtility.FromJson<Country>(jsonString);
		countryNameTextUI.text = test.name;
		float tostr = test.money;
		countryMoneyText.text = tostr.ToString();
		int inttostr = test.manpower;
		countryMenText.text = inttostr.ToString();
		/*countryNameTextUI = countryNameTextUI.GetComponent<Text>();
		countryMoneyText = countryMoneyText.GetComponent<Text>();
		Debug.Log(path);
		jsonString = File.ReadAllText(path);
		Country test = JsonUtility.FromJson<Country>(jsonString);
		countryNameTextUI.text = test.name;
		float tostr = test.money;
		countryMoneyText.text = tostr.ToString();*/
		provIds.Add(1);
		provIds.Add(2);
		provIds.Add(3);
		provIds.Add(4);
		provIds.Add(5);
		provIds.Add(6);
		provIds.Add(7);
		//addtoArray("test");
		
		/*path = Application.streamingAssetsPath + "/Provinces/Provinces.json";
		jsonString = File.ReadAllText(path);
		Province IRELAND = JsonUtility.FromJson<Province>(jsonString);
		provinceNameText = provinceNameText.GetComponent<TextMesh>();
		provinceNameTextUI = provinceNameTextUI.GetComponent<Text>();
		provinceNameText.text = IRELAND.name;
		provinceNameTextUI.text = IRELAND.name;*/
		provincesList myprovinceStatsList = new provincesList();
		
		JsonUtility.FromJsonOverwrite (jsonText, myprovinceStatsList);
		Debug.Log(jsonText);
		
		//countryFlag = countryFlag.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		//checkCountry();
		
		
	}
	/*void Load(int provID){
		path = Application.streamingAssetsPath + "/Provinces/Provinces.json";
		jsonString = File.ReadAllText(path);
		JArray a = JArray.Parse(jsonString);
		foreach (JObject o in a.Children<JObject>())
		{
			foreach (JProperty p in o.Properties())
			{
				string name = p.Name;
				string value = (string)p.Value;
				debug.log(name + " -- " + value);
			}
		}
		
		Province IRELAND = JsonUtility.FromJson<Province>(jsonString);
		provinceNameText = provinceNameText.GetComponent<TextMesh>();
		provinceNameTextUI = provinceNameTextUI.GetComponent<Text>();
		provinceNameText.text = IRELAND.name;
		provinceNameTextUI.text = IRELAND.name;
		
	}*/

	//void addtoArray(string toAdd){
	//	selection.Add(toAdd);
	//}

	/*private IEnumerator HandleIt(){
		
			theText = time.text;

			int.TryParse(theText, out theTextint);
			daInt = theTextint + 1;
			yield return new WaitForSeconds(2f);
			time.text = daInt.ToString();
			
		}
		
		
	}
	*/
	void checkCountry(){
		//changetime.isPaused = true;
        //path = Application.streamingAssetsPath + "/provinceController.json";
		//jsonString = File.ReadAllText(path);
		//CRootProv root = JsonUtility.FromJson<CRootProv>(jsonString);
        //var provs;
        
        
        /*foreach(int str in Provinces.provints)
		{
			//Debug.Log(str);
			if(provName == root.provinces[str].name){
                path = Application.streamingAssetsPath + root.provinces[str].path;
            }
		}*/
        if(PlayerPrefs.GetString("countryName") == "United_Kingdom"){
            path = Application.streamingAssetsPath + "/Countrys/uk.json";
			GetComponent<Image>().sprite = ukflag;
        }
		if(PlayerPrefs.GetString("countryName") == "United_States"){
            path = Application.streamingAssetsPath + "/Countrys/us.json";
			GetComponent<Image>().sprite = usflag;
        }
		
        
    }
	

	

	
}

 [System.Serializable]
public class provincesList{
	public List <provinces> province;
}


 [System.Serializable]
public class provinces{
	public int id;
	public string name;
	public string owner;
}
