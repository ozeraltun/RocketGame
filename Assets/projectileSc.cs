using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Death", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Death(){
        Destroy(GetComponent<Rigidbody>());
    }
}
