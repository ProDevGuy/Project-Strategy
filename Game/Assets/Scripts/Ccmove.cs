using UnityEngine; 
using System.Collections;

public class CameraManager : MonoBehaviour {

	public int cameraCurrentZoom = 8;
	public int cameraZoomMax = 20;
	public int cameraZoomMin = 5;
	void Start ()
	{
		Camera.main.orthographicSize = cameraCurrentZoom;
	}
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			if (cameraCurrentZoom < cameraZoomMax)
			{
				cameraCurrentZoom += 1;
				Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize + 1);
			} 
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			if (cameraCurrentZoom > cameraZoomMin)
			{
				cameraCurrentZoom -= 1;
				Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize - 1);
			}   
		}
	}
}