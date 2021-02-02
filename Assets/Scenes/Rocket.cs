using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // TODO: 
    // add audio for collusions
    // add particles to the booster of rocket and collusions
    // add different guns
    // add health bar
    // add fuel bar
    // fuel-ammunition-health boxes
    // add ai 
    // add menus 
    // make it multiplayer

    [SerializeField] float thrust;
    [SerializeField] AudioClip mainEngineSound;
    [SerializeField] AudioClip bulletFireSound;
    public Rigidbody projectile;
    public GameObject parent;

    Rigidbody rocket;
    Rigidbody clone;
    AudioSource audioSource;
    
    enum State {Alive, Dead, Firing};
    State state = State.Alive;

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
    }

    void Update()
    {
        if (state == State.Alive){
            Thrust();
            Rotate();
            Fire();
        }
        
    }
    void Fire()
    {
        if(Input.GetKey(KeyCode.Q)){
            
            
            if (projCreated==false){ //we dont want to create multiple projectiles
                projCreated = true; //Prohibits multiple projectiles
                firesoundenable = true; //I want firesound to finish even if there is no thrusting 
                //Getting the position and rotation for the projectile
                Vector3 bulletPos = parent.transform.GetChild(3).transform.position;
                Quaternion bulletRot = parent.transform.GetChild(3).transform.rotation;
                
                parent.transform.GetChild(3).gameObject.SetActive(false); //Nose will disappear
                
                audioSource.PlayOneShot(bulletFireSound);
                //not thrusting kills this sound




                clone = Instantiate(projectile, bulletPos, bulletRot);  //projectile is instantiated
                
                clone.AddRelativeForce(Vector3.up * thrust);  //giving speed(force) to projectile
                
                
                Invoke("RecreateNose", 3f); //After 3 seconds we should create(make it visible) the NoseCone
                Invoke("FireSoundEnable", 0.4f);
            }
        }
    }
    void FireSoundEnable(){
        firesoundenable = false;
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
