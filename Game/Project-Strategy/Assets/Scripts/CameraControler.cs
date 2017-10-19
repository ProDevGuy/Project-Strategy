
using UnityEngine;

public class CameraControler : MonoBehaviour {
    
    private Vector3 ResetCamera; //the location the camera resets to
    private Vector3 Origin; //orign point of the camera
    private Vector3 Diference; //difference between mouse pos and camera pos
    private bool Drag = false; //wether the camera is being dragged
    
    void Start()
    {
        ResetCamera = Camera.main.transform.position; //Sets the reset location of the camera
    }


    void LateUpdate()
    {
      

        //If button 2 is pressed
        if (Input.GetMouseButton(2))
        {
            Diference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position; //Sets difference var to the difference between mouse pos and camera
            if (Drag == false) //if not dragging
            {
                Drag = true; 
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Set origin point of camera
            }
        }
        else
        {
            Drag = false; 
        }
        if (Drag == true)//if dragging
        {
            Camera.main.transform.position = Origin - Diference; //moves the camera by the amount in the difference var
        }
        //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
        if (Input.GetMouseButton(1))
        {
            Camera.main.transform.position = ResetCamera;
        }

       


        
    }

}
