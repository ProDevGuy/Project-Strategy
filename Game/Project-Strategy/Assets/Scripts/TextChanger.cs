using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour {
	//public Text province;
	public string provinceName;
	string path;
	string jsonString;
	public TextMesh provinceNameText;
	public TextMesh provinceOwnerText;
	public Text provinceNameTextUI;
	public Text provinceOwnerTextUI;
	int daInt = 1;
	//public int timeRunning = 1;
	string theText;
	int theTextint;
	// Use this for initialization
	void Start () {
		//StartCoroutine( HandleIt() );
	}
	
	// Update is called once per frame
	void Update () {
		
		
			//theText = province.text;
			if(provinceName == "Ireland"){
				path = Application.streamingAssetsPath + "/Provinces/Ireland.json";
			}
			if(provinceName == "Wales"){
				path = Application.streamingAssetsPath + "/Provinces/Wales.json";
			}
			jsonString = File.ReadAllText(path);
			Province IRELAND = JsonUtility.FromJson<Province>(jsonString);
			provinceNameText = provinceNameText.GetComponent<TextMesh>();
			provinceNameTextUI = provinceNameTextUI.GetComponent<Text>();
			provinceNameText.text = IRELAND.name;
			provinceNameTextUI.text = IRELAND.name;
		
		
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
 /*[System.Serializable]
public class Aprovince{
	public int id;
	public string name;
	public string owner;
}*/

