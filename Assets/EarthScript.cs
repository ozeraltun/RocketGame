using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EarthScript : MonoBehaviour
{
    public Rigidbody fuelObject;
    [SerializeField] float lifeCycle;

    //Following values are the constraints of randomly created object's coordinates 
    int minXValue = -30;
    int maxXValue = 30;
    int minYValue = 2;
    int maxYValue = 20;

    Rigidbody clone;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1f, lifeCycle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn(){
        int xValue = Random.Range(minXValue,maxXValue);
        int yValue = Random.Range(minYValue,maxYValue);    
        // print(xValue);
        // print(yValue);
        Vector3 objPos = new Vector3(xValue, yValue, 0);
        Quaternion objRot = Quaternion.Euler(0, 0, 0);
        clone = Instantiate(fuelObject, objPos, objRot);
        Invoke("FuelObjectDisappear", lifeCycle);
    }
    public void FuelObjectDisappear(){
        Destroy(clone.gameObject);
    }

}
