﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTime : MonoBehaviour {
	public Text time;
	int daInt = 1;
	public int timeRunning = 1;
	string theText;
	int theTextint;
	// Use this for initialization
	void Start () {
		StartCoroutine( HandleIt() );
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}


	private IEnumerator HandleIt(){
		if (timeRunning != 0){
			theText = time.text;

			int.TryParse(theText, out theTextint);
			daInt = theTextint + 1;
			yield return new WaitForSeconds(2f);
			time.text = daInt.ToString();
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
