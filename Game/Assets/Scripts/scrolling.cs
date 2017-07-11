function Update () 
{
    const int orthographicSizeMin = 1;
    const int orthographicSizeMax = 6;


 if (Input.GetAxis("Mouse ScrollWheel") &gt; 0) // forward
 {
     Camera.main.orthographicSize++;
 }
 if (Input.GetAxis("Mouse ScrollWheel") &lt; 0) // back
 {
     Camera.main.orthographicSize--;
 }
 Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax );

}