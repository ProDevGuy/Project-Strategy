using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTime : MonoBehaviour {
	public Text time;
	int daInt = 1;
	public int timeRunning = 1;
	string theText;
    //public int theTime;
	public bool startSecond;
	int theTextint;
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
				event1.SetActive(true);
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

	
	
}
