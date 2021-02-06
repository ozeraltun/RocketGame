using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletc : MonoBehaviour
{
    [SerializeField] AudioClip explosionSound;
    [SerializeField] ParticleSystem explotionParticle;
    AudioSource audioSource;
    enum State {Alive, Dead};
    State state = State.Alive;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Alive;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
                state = State.Dead;
                audioSource.PlayOneShot(explosionSound);
                explotionParticle.Play();
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
}
