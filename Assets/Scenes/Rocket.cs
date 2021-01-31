using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;
    
    bool projCreated = false;
    
    public Rigidbody projectile;
    public GameObject parent;

    [SerializeField] float thrust;

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
            if (projCreated==false){ //we create projectile only one time
                // //Where is the position to initiate
                // Vector3 initiateLoc;
                // Transform tempTransform;
                // Quaternion initiateRot;
                // initiateLoc = transform.position; //position must be incremented wit tempLoc
                // initiateRot = transform.rotation; //rotation is same

                // print(this.NoseCone.parent); 
                Vector3 bulletPos = parent.transform.GetChild(3).transform.position;
                Quaternion bulletRot = parent.transform.GetChild(3).transform.rotation;
                
                parent.transform.GetChild(3).gameObject.SetActive(false);
                clone = Instantiate(projectile, bulletPos, bulletRot);
                
                clone.AddRelativeForce(Vector3.up * thrust);
                projCreated = true;


            }



            
            //split Nose cone from RocketShip 
                //make Nose cone Not visible on the ship
                
                //create New Nose(bullet) cone 
                //add speed to this bullet
                
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
