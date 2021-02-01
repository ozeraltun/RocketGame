using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rocket;
    AudioSource audioSource;
    
    bool projCreated = false;
    
    public Rigidbody projectile;
    public GameObject parent;

    [SerializeField] float thrust;

    Rigidbody clone;
    



    // Start is called before the first frame update
    void Start()
    {
        rocket = GetComponent<Rigidbody>();
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
            
            
            if (projCreated==false){ //we dont want to create multiple projectiles
                
                //Getting the position and rotation for the projectile
                Vector3 bulletPos = parent.transform.GetChild(3).transform.position;
                Quaternion bulletRot = parent.transform.GetChild(3).transform.rotation;
                
                parent.transform.GetChild(3).gameObject.SetActive(false); //Nose will disappear
                clone = Instantiate(projectile, bulletPos, bulletRot);  //projectile is instantiated
                
                clone.AddRelativeForce(Vector3.up * thrust);  //giving speed(force) to projectile
                
                projCreated = true; //Prohibits multiple projectiles
                Invoke("RecreateNose", 3f); //After 3 seconds we should create(make it visible) the NoseCone
            }
        }
    }
    void RecreateNose(){
        parent.transform.GetChild(3).gameObject.SetActive(true);
        Destroy(clone.gameObject);
        projCreated = false;

    }
    void Thrust()
    {
        if(Input.GetKey(KeyCode.Space)){
            rocket.AddRelativeForce(Vector3.up);
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
