using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
public class Selectable : MonoBehaviour {
    public bool hi; //test bool [DEPRECIATED]
    public cakeslice.Outline booltest; //The script which creates a outline of a province
    public string name; //Name of this gameobject
    public GameObject panel; //the panel which shows the province info
    public int selected; //wether or not the prov is selected [TO BE DEPRECATED]
    public TextMesh provinceNameText; //The text gamemobject which shows the province name
    public TextMesh provinceOwnerText; //The text gameobject which shows the province owner [DEPRECEATED]
    public Text provinceNameTextUI; //The UI which shows the name of the province in the panel
    public Text provinceOwnerTextUI; //The UI which shows the owner of the province in the panel
    public string Name; //[DEPRECEATED]
    string path; //The path to the json file
    string jsonString; //a string variable which contains the plain text from the json file
    public List<string> provinceNames = new List<string>(); //list of all the province names
    public Provinces Provinces; //the scripted "Provinces"
    
    public GameObject ProvincesHolder; //gameobject which holds the provinces script
    void Start()
    {
        
        
        
        string daname; //name variable [TO BE RENAMED]
        name = gameObject.name; //sets the "name" variable to the gameobjects name

        //panel = go.GetComponent<Image>();
        string filePath = Application.streamingAssetsPath + "/Provinces/";
		string[] files = System.IO.Directory.GetFiles(filePath);
        for (int i = 0; i < files.Length; i++)
		{
			if (files[i].EndsWith("json"))
			{
				//Debug.Log("Grabbing " + files[i]);
				string dataAsJson = File.ReadAllText(files[i]); // Read the json from the filePath into a string.
				//EventFromJson provinceData = JsonUtility.FromJson<EventFromJson>(dataAsJson); //Store that json into a provinceData struct.
				//daname = Path.GetFileName(files[i]);
				//daname = daname.Substring(0, daname.Length - 5);
				CProv provData = JsonUtility.FromJson<CProv>(dataAsJson); //Store that json into a provinceData struct.
				daname = provData.name;
				//Debug.Log(daname);
				//Add a new Province object to the provinces List, giving it the JSON data grabbed from the aforementioned file.
				provinceNames.Add(daname);
				//eventIds.Add(placeholderint);
				//Debug.Log(placeholderint);

			}
			
		}
        /*for (int i = 0; i < files.Length; i++){
            provinceNames.add(Province.)
        }*/
        //Sets a var "g" to the current game object
        GameObject g = gameObject;
        //Debug.Log(g);
        //Gets bool from script: Outline.cs
        booltest = g.GetComponent<cakeslice.Outline>(); //enables the outline of the provinces
        booltest.eraseRenderer = true; //same as above
       // Debug.Log(booltest);
        //Debug.Log("This may work");
    }
    void Update()
    {
        //Checks if mouse clicks
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse is down");
            //sets hitinfo variabble
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            //check if mouse hit something
            if (hit)
            {
                //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                //check if mouse hit object with tag "construction
                if (hitInfo.transform.gameObject.name == name)
                {
                    selected = 1;
                    Debug.Log(name);
                    //Debug.Log("It's working!");
                    booltest.eraseRenderer = false;
                    //panel.enabled = true;
                    panel.SetActive(true);
                    checkProvince(name);
                    
		    //The folowing lines set the UI and TEXT gameobject's text to what the json file said	
                    Debug.Log(path);
                    jsonString = File.ReadAllText(path);
                    Debug.Log(jsonString);
                    Province IRELAND = JsonUtility.FromJson<Province>(jsonString);
                    provinceNameText = provinceNameText.GetComponent<TextMesh>();
                    provinceNameTextUI = provinceNameTextUI.GetComponent<Text>();
                    provinceNameText.text = IRELAND.name;
                    provinceNameTextUI.text = IRELAND.name;
                    provinceOwnerTextUI.text = IRELAND.owner;
                    Debug.Log(provinceNameTextUI.text);
                    Debug.Log(provinceNameText.text);
                    Debug.Log(IRELAND.name);
                    //GetComponent<cakeslice.Outline>().enabled = true;

                    //Debug.Log("This works two");
                }
                else //If hit something else
                {
                  //Debug.Log("nopz");
                  booltest.eraseRenderer = true;
                  selected = 0;
                  panel.SetActive(true);
                }
            }
            else //if did not hit anything at all
            {
                //Debug.Log("No hit");
                booltest.eraseRenderer = true;
                panel.SetActive(false);
                selected = 0;
            }
            //Debug.Log("Mouse is down");
        }
    }

    
    void checkProvince(string provName){ //Check which province's path should be used
        path = Application.streamingAssetsPath + "/provinceController.json";
		jsonString = File.ReadAllText(path);
		CRootProv root = JsonUtility.FromJson<CRootProv>(jsonString);
        //var provs;
        
        
        /*foreach(int str in Provinces.provints)
		{
			//Debug.Log(str);
			if(provName == root.provinces[str].name){
                path = Application.streamingAssetsPath + root.provinces[str].path;
            }
		}*/
	//The folowing lines should be removed and replaced with a foreach loop like the one above [HIGH PRIORITY]
        if(provName == "Province ireland"){
            path = Application.streamingAssetsPath + "/Provinces/Ireland.json";
        }
        if(provName == "Province wales"){
            path = Application.streamingAssetsPath + "/Provinces/Wales.json";
        }
        if(provName == "Province england"){
            path = Application.streamingAssetsPath + "/Provinces/England.json";
        }
        if(provName == "Province wyoming"){
            path = Application.streamingAssetsPath + "/Provinces/Wyoming.json";
        }
        if(provName == "Province colorado"){
            path = Application.streamingAssetsPath + "/Provinces/Colorado.json";
        }
        if(provName == "Province greenland"){
            path = Application.streamingAssetsPath + "/Provinces/Greenland.json";
        }
        if(provName == "Province michigan"){
            path = Application.streamingAssetsPath + "/Provinces/Michigan.json";
        }
    } 
}

//The class which holds the province data
[System.Serializable]
 public class CProv 
 {
     public int id;
     public string name;
     public string path;
	 public int time;
 }
 //the class which compiles the class above
 [System.Serializable]
 public class CRootProv
 {
     
     public CProv[] provinces;
 }
