using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class buttonController : MonoBehaviour {
	
	public GameObject timeholder;
	//public GameObject initholder;
	public GameObject testEvent;
	changeTime changetime;
	//initialization init;
	
	// Use this for initialization
	void Start () {
		
		//init = initholder.GetComponent<initialization>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void test() {
		timeholder = GameObject.Find("timeButton");
		changetime = timeholder.GetComponent<changeTime>();
		testEvent.SetActive(false);
		changetime.isPaused = false;
		//Debug.Log(changetime.isPaused);
	}
	/*public void ukchoice(){
		init.Country_Name = "United_Kingdom";
		init.countryselect.SetActive(false);
		changetime.isPaused = false;
		//init.selected = false;
	}*/
	public void loadCountrySelect(){
		
		SceneManager.LoadScene("CountrySect");
	}
	public void Ukoption(){
		
		PlayerPrefs.SetString("countryName", "United_Kingdom");
		Application.LoadLevel(2);
	}
	public void USoption(){
		PlayerPrefs.SetString("countryName", "United_States");
		Application.LoadLevel(2);
	}
	

}
