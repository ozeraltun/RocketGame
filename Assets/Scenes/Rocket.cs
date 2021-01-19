﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space)){
            print("Thrusting...");
        }
        
        //We should be able to thrust and rotate at the same time, therefore different if
        if(Input.GetKey(KeyCode.A)){
            print("Rotating Left...");
        }
        else if(Input.GetKey(KeyCode.D)){
            print("Rotating Right...");
        }
        else{
            //Nothing
        }

    }
}
