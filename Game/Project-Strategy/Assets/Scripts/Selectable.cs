using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
public class Selectable : MonoBehaviour {
    public bool hi;
    public cakeslice.Outline booltest;
    public string name;
    public GameObject panel;
    public int selected;
    public TextMesh provinceNameText;
    public TextMesh provinceOwnerText;
 	public Text provinceNameTextUI;
    public Text provinceOwnerTextUI;
    public string Name;
    string path;
	string jsonString;
    public Provinces Provinces;
    void Start()
    {
        //Selectable[] selectabless = FindObjectsOfType(typeof(Selectable)) as Selectable[];
        //foreach(Selectable str in selectabless)
		//{
		//	Debug.Log(str);
		//}
        name = gameObject.name;
        //GameObject go = GameObject.Find("Canvas");
        //if (!go)
            //return;

        //panel = go.GetComponent<Image>();

        //Sets a var "g" to the current game object
        GameObject g = gameObject;
        //Debug.Log(g);
        //Gets bool from script: Outline.cs
        booltest = g.GetComponent<cakeslice.Outline>();
        booltest.eraseRenderer = true;
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
                    if(name == "Province ireland"){
                        path = Application.streamingAssetsPath + "/Provinces/Ireland.json";
                    }
                    if(name == "Province wales"){
                        path = Application.streamingAssetsPath + "/Provinces/Wales.json";
                    }
                    if(name == "Province england"){
                        path = Application.streamingAssetsPath + "/Provinces/England.json";
                    }
                    if(name == "Province wyoming"){
                        path = Application.streamingAssetsPath + "/Provinces/Wyoming.json";
                    }
                    if(name == "Province colorado"){
                        path = Application.streamingAssetsPath + "/Provinces/Colorado.json";
                    }
                    if(name == "Province greenland"){
                        path = Application.streamingAssetsPath + "/Provinces/Greenland.json";
                    }
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
                else
                {
                  //Debug.Log("nopz");
                  booltest.eraseRenderer = true;
                  selected = 0;
                  panel.SetActive(true);
                }
            }
            else
            {
                //Debug.Log("No hit");
                booltest.eraseRenderer = true;
                panel.SetActive(false);
                selected = 0;
            }
            //Debug.Log("Mouse is down");
        }
    }
}