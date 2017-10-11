using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class countrys : MonoBehaviour 
{
	/*This is the list of eventss, you can't access them as individually named objects anymore (for the sake of making the code modular) but you can
	search through the list and check, for example, if provinces.name == "Ireland" exists, and then return that Province object.*/
	public List<Country> Countrys = new List<Country>();
	public static countrys Instance;
	void Awake(){
		Instance = this;
	}
	void Start()
	{
		loadJsonData();
	}

	void loadJsonData()
	{
		string filePath = Application.streamingAssetsPath + "/Countrys";
		string[] files = System.IO.Directory.GetFiles(filePath);

		for (int i = 0; i < files.Length; i++)
		{
			if (files[i].EndsWith("json"))
			{
				Debug.Log("Grabbing " + files[i]);
				string dataAsJson = File.ReadAllText(files[i]); // Read the json from the filePath into a string.
				CountryFromJson provinceData = JsonUtility.FromJson<CountryFromJson>(dataAsJson); //Store that json into a provinceData struct.

				//Add a new Province object to the provinces List, giving it the JSON data grabbed from the aforementioned file.
				Countrys.Add(new Country(provinceData.name, provinceData.money, provinceData.flagpath, provinceData.manpower));
			}
			
		}
		/*foreach(Province str in provinces)
		{
			Debug.Log(str.name);
		}*/

	}
}

//Actual Province object that will be referenced and stored inside of a List<Province>.
public class Country
{
	public string name;
	public float money;
    public string flagpath;
    public int manpower;
	//public string eventTitle;
	//public string eventOption1;
	//public string eventOption2;
	//public string eventDisc;

	//Constructor, takes all the data that should be passed in from the provinceData object.
	public Country(string jsonName, float jsonMoney, string jsonFlagPath, int jsonManpower)
	{
		name = jsonName;
		money = jsonMoney;
        flagpath = jsonFlagPath;
        manpower = jsonManpower;
		
	}
}


//Struct holding the data grabbed from the JSON file. This has to be the exact same layout as the content in the json file.
[System.Serializable]
public struct CountryFromJson
{
	public string id;
	public string name;
	public float money;
    public string flagpath;
    public int manpower;
}