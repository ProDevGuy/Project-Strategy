using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class clicker : MonoBehaviour {
    public Texture2D colorMapTex;
    public Camera cam;
    
	// Use this for initialization
	void Start () {
		
	}
    public Camera maincamera;
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            print("hit");
            //We select province with Raycast

            /*float mousex = (Input.mousePosition.x * 550);
            float mousey = (Input.mousePosition.y * 400);
            float mousexb = (Input.mousePosition.x);
            float mouseyb = (Input.mousePosition.y);
            Vector2 mouseposition = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 0));
            Vector2 mousepositionb = Camera.main.ScreenToWorldPoint(new Vector3(mousexb, mouseyb, 0));
            print(mouseposition);
            print(mousepositionb);
            Vector2 cordV2 = new Vector2(mouseposition.x, mouseposition.y);
            

            int cordX = (int)(Mathf.FloorToInt(cordV2.x));
            int cordY = (int)(Mathf.FloorToInt(cordV2.y));
            /*
            Color32 clickedProvinceColor = colorMapTex.GetPixel (cordX, cordY);
            print("Province Color: " + clickedProvinceColor + "Stats: " + cordX + " " + cordY);*/
            var mouseyb = Input.mousePosition;
            mouseyb = Camera.main.ScreenToWorldPoint(mouseyb);
            CameraZoom ZoomeCamera = GameObject.Find("Main Camera").GetComponent<CameraZoom>();
            float zoom = ZoomeCamera.cameraCurrentZoom;
            //Vector3 mousepos = new Vector3(mouseyb, mouseyb);
            // print(mousepos);
            print(mouseyb.x * 200);
            print((mouseyb.y * 42)*4.8);
            float locx = mouseyb.x * 200;
            float locy = (mouseyb.y * 42) * 4.8f;
            int cordX = (int)(Mathf.FloorToInt(locx));
            int cordY = (int)(Mathf.FloorToInt(locy));
            //Color32 clickedProvinceColor = colorMapTex.GetPixelBilinear(locx, locy);
            Color32 clickedProvinceColor = colorMapTex.GetPixel(cordX, cordY);
            print(clickedProvinceColor);


        }
        
        
    }
}
