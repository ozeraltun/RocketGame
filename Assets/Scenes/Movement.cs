using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    Vector3 startingPos;

    [Range(0,10)][SerializeField] float sineFactor;
    void Start()
    {
        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, startingPos.y + sineFactor * Mathf.Sin(Time.time), 0);
    }  
}
