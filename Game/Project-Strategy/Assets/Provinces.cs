using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Provinces : MonoBehaviour {

	string path;
	string jsonString;


	void Start(){
		path = Application.streamingAssetsPath + "/Provinces/Province.json";
		jsonString = File.ReadAllText(path);
		Province IRELAND = jsonUtility.FromJson<Province>(jsonString);
		Debug.Log(IRELAND.name);
	}
}


 [System.Serializable]
public class Province{
	public int id;
	public string name;
}