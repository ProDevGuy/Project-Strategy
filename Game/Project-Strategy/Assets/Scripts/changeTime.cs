using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class changeTime : MonoBehaviour {
	public Text time;
	int daInt = 1;
	public int timeRunning = 1;
	string theText;
	string daname;
    //public int theTime;
	public bool startSecond;
	public Text descOfEvent;
	public Text tittleOfEvent;
	public Text option1OfEvent;
	public Text option2OfEvent;
	public bool isPaused = false;
	bool eventReady = false;
	string path;
	string jsonString;
	int timeint;
	int theTextint;
	public int eventID;
	
	string somestring;
	//array[] somearry;
	public string eventName;
	public GameObject event1;
	public List<string> eventNames = new List<string>();
	public List<int> eventIds = new List<int>();
	int placeholderint;
	// Use this for initialization
	void Start () {
		StartCoroutine( HandleIt() );
		string filePath = Application.streamingAssetsPath + "/Events/gameEvents";
		string[] files = System.IO.Directory.GetFiles(filePath);

		for (int i = 0; i < files.Length; i++)
		{
			if (files[i].EndsWith("json"))
			{
				//Debug.Log("Grabbing " + files[i]);
				string dataAsJson = File.ReadAllText(files[i]); // Read the json from the filePath into a string.
				//EventFromJson provinceData = JsonUtility.FromJson<EventFromJson>(dataAsJson); //Store that json into a provinceData struct.
				daname = Path.GetFileName(files[i]);
				daname = daname.Substring(0, daname.Length - 5);
				CEvent eventData = JsonUtility.FromJson<CEvent>(dataAsJson); //Store that json into a provinceData struct.
				placeholderint = eventData.id;
				//Debug.Log(daname);
				//Add a new Province object to the provinces List, giving it the JSON data grabbed from the aforementioned file.
				eventNames.Add(daname);
				eventIds.Add(placeholderint);
				Debug.Log(placeholderint);

			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		//LoadJsonData();
	}


	

	private IEnumerator HandleIt(){
		while (isPaused)
		{
			yield return null;
		}
		//if (timeRunning != 0){
		startSecond = true;
		theText = time.text;

		int.TryParse(theText, out theTextint);
		daInt = theTextint + 1;
		
		
		yield return new WaitForSeconds(1f);
		time.text = daInt.ToString();
		EventChecker();
		if(eventReady == true){
			//Debug.Log("event 1 fires");
			
			EventChanger(eventName);
			event1.SetActive(true);
			timeRunning = 0;
			startSecond = false;
			eventReady = false;
			isPaused = true;
		}
		
		startSecond = false;
		StartCoroutine( HandleIt() );
		//}
		//yield return new WaitForSeconds(1f);
		//StartCoroutine( HandleIt() );
		
	}

	public void StartStopTime(){
		Debug.Log("this works");
		if (isPaused == false){
			//Debug.Log("this also works");
			isPaused = true;
			//Debug.Log(timeRunning);
		}else{
			isPaused = false;
		}
		/*if (timeRunning == 0){
			timeRunning = 1;
		}*/
	}

	public void EventChanger(string eventToGame){
		/*foreach(somestring in somearry){
			if (someString == "blah"){
				return;
			}
		}*/
		jsonString = File.ReadAllText(path);
		//Debug.Log(jsonString);
		Event eventtest = JsonUtility.FromJson<Event>(jsonString);
		descOfEvent = descOfEvent.GetComponent<Text>();
		option1OfEvent = option1OfEvent.GetComponent<Text>();
		option2OfEvent = option2OfEvent.GetComponent<Text>();
		tittleOfEvent = tittleOfEvent.GetComponent<Text>();
		tittleOfEvent.text = eventtest.eventTitle;
		descOfEvent.text = eventtest.eventDisc;
		option1OfEvent.text = eventtest.eventOption1;
		option2OfEvent.text = eventtest.eventOption2;


	}

	public void EventChecker(){
		path = Application.streamingAssetsPath + "/Events/eventHandler.json";
		jsonString = File.ReadAllText(path);
		//Debug.Log(jsonString);
		//Event eventHolder = JsonUtility.FromJson<Event>(jsonString);
		CRoot root = JsonUtility.FromJson<CRoot>(jsonString);
		//Debug.Log(root.events[0].name);
		//string eventstring = eventNames.RandomItem();
		//eventName = root.events[].name;
		//path = Application.streamingAssetsPath + "/Events/gameEvents/event1.json";
		//&& startSecond == true
		//root.events[0].time ="5" &&
		
		string timetext = time.text;
		
		int.TryParse(timetext, out timeint);
		foreach(int str in eventIds)
		{
			//Debug.Log(str);
			if ( timeint == root.events[str].time ){ //To add an event just add the json file and edit the eventHandler
				if(startSecond = true){
					eventReady = true;
					path = Application.streamingAssetsPath + root.events[str].path;
				}
			}
		}
	
	}
	//public Random rnd = new Random();
	/*void LoadJsonData(){
		string filePath = Application.streamingAssetsPath + "/Events/gameEvents/";
		string[] files = System.IO.Directory.GetFiles(filePath);
		
		int i = Random.Range(0,1);
		//Debug.Log("Grabbing " + files[i]);
		string dataAsJson = File.ReadAllText(files[i]); // Read the json from the filePath into a string.
		CEvent eventData = JsonUtility.FromJson<CEvent>(dataAsJson); //Store that json into a provinceData struct.
		eventID = eventData.id;
		//Add a new Province object to the provinces List, giving it the JSON data grabbed from the aforementioned file.
		
	}*/
	
}

[System.Serializable]
 public class CEvent
 {
     public int id;
     public string name;
     public string path;
	 public int time;
 }
 
 [System.Serializable]
 public class CRoot
 {
     public CEvent[] events;
 }

