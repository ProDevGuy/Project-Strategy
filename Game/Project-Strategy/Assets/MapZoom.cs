using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZoom : MonoBehaviour {

    public GameObject provinceMap;
    public GameObject countryMap;
    
    CameraZoom ZoomeCamera;
    public GameObject Kamera;
    float zoom;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        ZoomeCamera = Kamera.GetComponent<CameraZoom>();
        zoom = ZoomeCamera.cameraCurrentZoom;
        Debug.Log(zoom);
		if (zoom < 2)
        {
            provinceMap.SetActive(true);
            countryMap.SetActive(false);
            Debug.Log("zoom <1");
        }
        if (zoom >= 2)
        {
            provinceMap.SetActive(false);
            countryMap.SetActive(true);
            Debug.Log("zoom >1");
        }
	}
}
