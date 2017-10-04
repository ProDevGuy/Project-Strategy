using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{

    public float cameraCurrentZoom = 8;
    public float cameraZoomMax = 20;
    public float cameraZoomMin = 5;
    public float cameraZoomAmount = 0.5f;
    void Start()
    {
        Camera.main.orthographicSize = cameraCurrentZoom;
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            if (cameraCurrentZoom < cameraZoomMax)
            {
                cameraCurrentZoom += cameraZoomAmount;
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize + cameraZoomAmount);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            if (cameraCurrentZoom > cameraZoomMin)
            {
                cameraCurrentZoom -= cameraZoomAmount;
                Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize - cameraZoomAmount);
            }
        }
    }
}