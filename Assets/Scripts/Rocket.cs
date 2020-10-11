using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rotation = 10f;
    [SerializeField] float thrust = 5f;
    Rigidbody rigidBody;
    AudioSource audioSource;
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        Thrust();
        Rotate();
    }
    void Thrust(){
        if( Input.GetKey(KeyCode.Space)){
            var thrustSpeed = thrust * Time.deltaTime;

            rigidBody.AddRelativeForce(Vector3.up * thrustSpeed);
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }

    void Rotate(){
        rigidBody.freezeRotation = true;
        var rotationSpeed = rotation * Time.deltaTime;
        if( Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.forward * rotationSpeed);
        } else if( Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }

        rigidBody.freezeRotation = false;
    }
}
