using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;

    public Rigidbody projectile;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
        Fire();
    }
    void Fire(){
        if(Input.GetKey(KeyCode.Q)){
            Rigidbody clone;
            
            //Get the rotation and position of the ship(which is also same with the cone)
            clone = Instantiate(projectile, transform.position, transform.rotation);
            //split Nose cone from RocketShip 
                //make Nose cone Not visible on the ship
                
                //create New Nose(bullet) cone 
                //add speed to this bullet
                clone.velocity = transform.TransformDirection(Vector3.forward * 10);
            //create 
        }
    }
    void Thrust()
    {
        if(Input.GetKey(KeyCode.Space)){
            rigidBody.AddRelativeForce(Vector3.up);
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
        }
        else{
            audioSource.Stop();
        }
    }
        //We should be able to thrust and rotate at the same time, therefore different if
    void Rotate(){
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.forward);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward);
        }
        else{
            //Nothing
        }
    }

    
}
