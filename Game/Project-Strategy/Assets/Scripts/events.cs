using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class events : MonoBehaviour 
{
	/*This is the list of eventss, you can't access them as individually named objects anymore (for the sake of making the code modular) but you can
	search through the list and check, for example, if provinces.name == "Ireland" exists, and then return that Province object.*/
	public List<Event> Events = new List<Event>();
	public static events Instance;
	void Awake(){
		Instance = this;
	}
	void Start()
	{
		loadJsonData();
	}

	void loadJsonData()
	{
		string filePath = Application.streamingAssetsPath + "/Events/";
		string[] files = System.IO.Directory.GetFiles(filePath);

		for (int i = 0; i < files.Length; i++)
		{
			if (files[i].EndsWith("json"))
			{
				Debug.Log("Grabbing " + files[i]);
				string dataAsJson = File.ReadAllText(files[i]); // Read the json from the filePath into a string.
				EventFromJson provinceData = JsonUtility.FromJson<EventFromJson>(dataAsJson); //Store that json into a provinceData struct.

				//Add a new Province object to the provinces List, giving it the JSON data grabbed from the aforementioned file.
				Events.Add(new Event(provinceData.name, provinceData.time, provinceData.eventTitle, provinceData.eventOption1, provinceData.eventOption2, provinceData.eventDisc));
			}
			
		}
		/*foreach(Province str in provinces)
		{
			Debug.Log(str.name);
		}*/

	}
}

//Actual Province object that will be referenced and stored inside of a List<Province>.
public class Event
{
	public string name;
	public float time;
	public string eventTitle;
	public string eventOption1;
	public string eventOption2;
	public string eventDisc;

	//Constructor, takes all the data that should be passed in from the provinceData object.
	public Event(string jsonName, float jsonTime, string jsonEventTitle, string jsoneventOption1, string jsoneventOption2, string jsonDisc)
	{
		name = jsonName;
		time = jsonTime;
		eventTitle = jsonEventTitle;
		eventOption1 = jsoneventOption1;
		eventOption2 = jsoneventOption2;
		eventDisc = jsonDisc;
		
	}
}


//Struct holding the data grabbed from the JSON file. This has to be the exact same layout as the content in the json file.
[System.Serializable]
public struct EventFromJson
{
	public string id;
	public string name;
	public float time;
	public string eventTitle;
	public string eventOption1;
	public string eventOption2;
	public string eventDisc;
}