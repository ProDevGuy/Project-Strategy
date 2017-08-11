function Update () {
    if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
    {
        Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize-1, 1);


    }
    if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
    {
        Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize-1, 6);
    }
}