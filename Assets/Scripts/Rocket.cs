using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // TODO: 
    // recheck audio for collusions
    // recheck particles of the booster, rocket and collusions
    // recheck second gun
    // fuel box prefab added but it has a lot of missing parts

    // add health bar
    // add fuel bar
    // fuel-ammunition-health boxes
    // add menus
    // add ai  
    // make it multiplayer


    
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] float rocketMainThrust = 100f;
    [SerializeField] float bulletthrust = 500f;
    [SerializeField] AudioClip mainEngineSound;
    [SerializeField] AudioClip bulletFireSound;
    

    public Rigidbody projectile;
    public GameObject parent;

    Rigidbody rocket;
    Rigidbody clone;
    AudioSource audioSource;
    
    enum State {Alive, Dead, Firing};
    enum Gun {Biggun, SmallGun};

    State state = State.Alive;
    Gun gun = Gun.Biggun;
    
    bool projCreated = false;
    bool firesoundenable = false;

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive ){ return;} //ignore collusions when not alive
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                break;
            case "GroundTag":
                //print("Grounded");
                break;
            case "BarrierTag":
                //print("BarrierHit");
                break;
            case "LaunchPadTag":
                //print("LaunchPadHit");
                break;
            default:
                break;
        }
    }

    void Start()
    {
        rocket = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        parent.transform.GetChild(4).gameObject.SetActive(false); //second gun will not be visible
    }

    void Update()
    {
        if (state == State.Alive){
            Thrust();
            Rotate();
            ChangeGun();
            Fire();
        }
    }
    void ChangeGun(){
        if(Input.GetKey(KeyCode.Alpha1)){
            if(gun == Gun.Biggun){
                //If already selected dont change anything (Because of the NoseCone Enabling I need this)
            } 
            else{
                parent.transform.GetChild(4).gameObject.SetActive(false);
                parent.transform.GetChild(3).gameObject.SetActive(true);
                print("Biggun selected");
                gun = Gun.Biggun;
            }
            
        }
        else if(Input.GetKey(KeyCode.Alpha2)){
            if(gun == Gun.SmallGun){
                //If already selected dont change anything (Because of the NoseCone Enabling I need this)
                parent.transform.GetChild(3).gameObject.SetActive(false); //(Nose cone disabled)
                parent.transform.GetChild(4).gameObject.SetActive(true);
            }
            else{
                gun = Gun.SmallGun;
                print("Smallgun selected");
            }
            
        }
        else{
            //Empty (Additional guns will be implemented here)
        }
    }
    
    void Fire()
    {
        if(Input.GetKey(KeyCode.Q)){
            if(gun == Gun.Biggun){
                if (projCreated==false){ //we dont want to create multiple projectiles
                projCreated = true; //Prohibits multiple projectiles
                firesoundenable = true; //I want firesound to finish even if there is no thrusting 
                //Getting the position and rotation for the projectile
                Vector3 bulletPos = parent.transform.GetChild(3).transform.position;
                Quaternion bulletRot = parent.transform.GetChild(3).transform.rotation;
                
                parent.transform.GetChild(3).gameObject.SetActive(false); //Nose will disappear
                
                audioSource.PlayOneShot(bulletFireSound);
                //not-thrusting kills this sound


                
                
                clone = Instantiate(projectile, bulletPos, bulletRot);  //projectile is instantiated
                
                clone.AddRelativeForce(Vector3.up * bulletthrust);  //giving speed(force) to projectile
                
                
                Invoke("RecreateNose", 3f); //After 3 seconds we should create(make it visible) the NoseCone
                Invoke("FireSoundEnable", 0.4f);
                }
            }
            else if(gun == Gun.SmallGun){
                //Pass
            }
            else{
                //Empty for now
            }
        }
    }
    void FireSoundEnable(){
        firesoundenable = false;
    }
    void RecreateNose(){
        if(gun == Gun.SmallGun){

        }
        else{
            parent.transform.GetChild(3).gameObject.SetActive(true);
        }
        
        Destroy(clone.gameObject);
        projCreated = false;

    }
    void Thrust()
    {
        float thrustSpeed = rocketMainThrust * Time.deltaTime;
        if(Input.GetKey(KeyCode.Space)){
            rocket.AddRelativeForce(Vector3.up * thrustSpeed);
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(mainEngineSound);
            }
        }
        else{
            if(firesoundenable == false){
                audioSource.Stop();
            }
        }
    }
    
    void Rotate(){
        rocket.freezeRotation = true;
        float rotationSpeed = rotationThrust * Time.deltaTime;

        if(Input.GetKey(KeyCode.A)){
            
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        else{
            //Nothing
        }
        rocket.freezeRotation = false;
    }
}
