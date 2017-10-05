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
    //public int theTime;
	public bool startSecond;
	public Text descOfEvent;
	public Text tittleOfEvent;
	public Text option1OfEvent;
	public Text option2OfEvent;
	
	string path;
	string jsonString;
	int theTextint;
	string somestring;
	//array[] somearry;
	public string eventName;
	public GameObject event1;
	// Use this for initialization
	void Start () {
		StartCoroutine( HandleIt() );
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}


	

	private IEnumerator HandleIt(){
		if (timeRunning != 0){
			startSecond = true;
			theText = time.text;

			int.TryParse(theText, out theTextint);
			daInt = theTextint + 1;
			
			
			yield return new WaitForSeconds(1f);
			time.text = daInt.ToString();
			if(time.text == "5" && startSecond == true){
				Debug.Log("event 1 fires");
				EventChecker();
				EventChanger(eventName);
				event1.SetActive(true);
				timeRunning = 0;
				startSecond = false;
			}
			
			startSecond = false;
			StartCoroutine( HandleIt() );
		}
		
		
	}

	public void StartStopTime(){
		Debug.Log("this works");
		if (timeRunning == 1){
			Debug.Log("this also works");
			timeRunning = 0;
			Debug.Log(timeRunning);
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
		descOfEvent = descOfEvent.GetComponent<Text>();
		descOfEvent.text = "event1_discription_placholder";
	}

	public void EventChecker(){
		path = Application.streamingAssetsPath + "/Events/eventHandler.json";
		jsonString = File.ReadAllText(path);
		//Debug.Log(jsonString);
		Event eventHolder = JsonUtility.FromJson<Event>(jsonString);

		eventName = "";
	}

	
	
}
