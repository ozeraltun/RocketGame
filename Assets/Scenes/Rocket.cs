﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space)){
            rigidBody.AddRelativeForce(Vector3.up);
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
