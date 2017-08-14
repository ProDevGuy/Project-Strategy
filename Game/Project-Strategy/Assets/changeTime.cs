using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTime : MonoBehaviour {
	public Text time;
	int daInt = 1;
	// Use this for initialization
	void Start () {
		StartCoroutine( HandleIt() );
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}


	private IEnumerator HandleIt(){
		yield return new WaitForSeconds(2f);
		time.text += daInt.ToString();
		StartCoroutine( HandleIt() );
	}
}
