﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Selectable : MonoBehaviour {
    public bool hi;
    public cakeslice.Outline booltest;
    public string name;
    
    void Start()
    {


        name = gameObject.name;
        

        //Sets a var "g" to the current game object
        GameObject g = gameObject;
        Debug.Log(g);
        //Gets bool from script: Outline.cs
        booltest = g.GetComponent<cakeslice.Outline>();
        booltest.eraseRenderer = true;
        Debug.Log(booltest);
        Debug.Log("This may work");
    }
    void Update()
    {
        //Checks if mouse clicks
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");
            //sets hitinfo variabble
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            //check if mouse hit something
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                //check if mouse hit object with tag "construction
                if (hitInfo.transform.gameObject.name == name)
                {
                    
                    Debug.Log("It's working!");

                    //GetComponent<cakeslice.Outline>().enabled = true;
                    booltest.eraseRenderer = false;
                    Debug.Log("This works two");
                }
                else
                {
                  Debug.Log("nopz");
                  booltest.eraseRenderer = true;
                }
            }
            else
            {
                Debug.Log("No hit");
                booltest.eraseRenderer = true;
            }
            Debug.Log("Mouse is down");
        }
    }
}