using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour {
	
	public GameObject timeholder;
	public GameObject testEvent;
	changeTime changetime;
	
	// Use this for initialization
	void Start () {
		timeholder = GameObject.Find("timeButton");
		changetime = timeholder.GetComponent<changeTime>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void test() {
		testEvent.SetActive(false);
		changetime.isPaused = false;
		//Debug.Log(changetime.isPaused);
	}
}
