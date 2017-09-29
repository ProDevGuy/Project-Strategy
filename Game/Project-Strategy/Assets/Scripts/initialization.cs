using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
//using JsonFX.Json;
using System;
using System.Text;
using System.Reflection;

//using Newtonsoft.Json.Linq;
public class initialization : MonoBehaviour {
	//public Text province;
	public string provinceName;
	string path;
	string jsonString;
	public TextMesh provinceNameText;
	public TextMesh provinceOwnerText;
	public Text provinceNameTextUI;
	public Text provinceOwnerTextUI;
	public GameObject camera;
	List<string> selection;
	List<int> provIds = new List<int>();
	int daInt = 1;
	//public int timeRunning = 1;
	string theText;
	public string jsonText;
	int theTextint;
	//public Aprovince[] provinces;
	// Use this for initialization
	void Start () {
		//StartCoroutine( HandleIt() );
		//Load();
		/*Provinces provinces = camera.GetComponent<Provinces>();
		foreach(Provinces str in Provinces.Instance.provinces)
		{
			Debug.Log(str.name);
		}*/
		provIds.Add(1);
		provIds.Add(2);
		provIds.Add(3);
		provIds.Add(4);
		provIds.Add(5);
		provIds.Add(6);
		provIds.Add(7);
		addtoArray("test");
		
		/*path = Application.streamingAssetsPath + "/Provinces/Provinces.json";
		jsonString = File.ReadAllText(path);
		Province IRELAND = JsonUtility.FromJson<Province>(jsonString);
		provinceNameText = provinceNameText.GetComponent<TextMesh>();
		provinceNameTextUI = provinceNameTextUI.GetComponent<Text>();
		provinceNameText.text = IRELAND.name;
		provinceNameTextUI.text = IRELAND.name;*/
		provincesList myprovinceStatsList = new provincesList();
		
		JsonUtility.FromJsonOverwrite (jsonText, myprovinceStatsList);
		Debug.Log(jsonText);
	}
	
	// Update is called once per frame
	void Update () {
		
		
			/*theText = province.text;
*/
		
		
	}
	/*void Load(int provID){
		path = Application.streamingAssetsPath + "/Provinces/Provinces.json";
		jsonString = File.ReadAllText(path);
		JArray a = JArray.Parse(jsonString);
		foreach (JObject o in a.Children<JObject>())
		{
			foreach (JProperty p in o.Properties())
			{
				string name = p.Name;
				string value = (string)p.Value;
				debug.log(name + " -- " + value);
			}
		}
		
		Province IRELAND = JsonUtility.FromJson<Province>(jsonString);
		provinceNameText = provinceNameText.GetComponent<TextMesh>();
		provinceNameTextUI = provinceNameTextUI.GetComponent<Text>();
		provinceNameText.text = IRELAND.name;
		provinceNameTextUI.text = IRELAND.name;
		
	}*/

	void addtoArray(string toAdd){
		selection.Add(toAdd);
	}

	/*private IEnumerator HandleIt(){
		
			theText = time.text;

			int.TryParse(theText, out theTextint);
			daInt = theTextint + 1;
			yield return new WaitForSeconds(2f);
			time.text = daInt.ToString();
			
		}
		
		
	}
	*/

	

	
}

 [System.Serializable]
public class provincesList{
	public List <provinces> province;
}


 [System.Serializable]
public class provinces{
	public int id;
	public string name;
	public string owner;
}
