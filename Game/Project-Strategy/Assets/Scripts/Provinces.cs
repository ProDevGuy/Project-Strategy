using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class Provinces : MonoBehaviour {

	string path;
	string jsonString;
	public Text provinceNameText;
	public Text provinceOwnerText;


	void Start(){
		path = Application.streamingAssetsPath + "/Provinces/Ireland.json";
		jsonString = File.ReadAllText(path);
		Province IRELAND = JsonUtility.FromJson<Province>(jsonString);
		//Debug.Log(IRELAND.name);
		provinceNameText = provinceNameText.GetComponent<Text>();
		provinceNameText.text = IRELAND.name;
	}
}


 [System.Serializable]
public class Province{
	public int id;
	public string name;
	public string owner;
}