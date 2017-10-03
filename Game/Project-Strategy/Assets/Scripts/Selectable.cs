using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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
    void Start()
    {


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
                    //tells game that a provinces is selected
                    selected = 1;
                    //Debug.Log("It's working!");
                    
                    //turns on the outline for the provinces script
                    booltest.eraseRenderer = false;
                    //panel.enabled = true;
                    
                    //turns on the UI panel
                    panel.SetActive(true);
                    
                    //checks the name of the provinces clicked, then changes panel info to reflect that.
                    if(Name == "Ireland"){
                        path = Application.streamingAssetsPath + "/Provinces/Ireland.json";
                    }
                    if(Name == "Wales"){
                        path = Application.streamingAssetsPath + "/Provinces/Wales.json";
                    }
                    jsonString = File.ReadAllText(path);
                    Province IRELAND = JsonUtility.FromJson<Province>(jsonString);
                    provinceNameText = provinceNameText.GetComponent<TextMesh>();
                    provinceNameTextUI = provinceNameTextUI.GetComponent<Text>();
                    provinceNameText.text = IRELAND.name;
                    provinceNameTextUI.text = IRELAND.name;
                    
                    //GetComponent<cakeslice.Outline>().enabled = true;

                    //Debug.Log("This works two");
                }
                else
                {
                  //Debug.Log("nopz");
                  //turns off the outline if player clicks provinces that is not this province
                  booltest.eraseRenderer = true;
                  selected = 0;
                  panel.SetActive(true);
                }
            }
            else
            {
                //Debug.Log("No hit");
                //turns off outline if it does not hit something
                booltest.eraseRenderer = true;
                panel.SetActive(false);
                selected = 0;
            }
            //Debug.Log("Mouse is down");
        }
    }
}
