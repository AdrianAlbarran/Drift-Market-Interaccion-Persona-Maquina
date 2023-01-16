using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSounds : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    private Rigidbody carRb;

    private AudioSource carAudio;
    public AudioClip carHit;

    void Start()
    {
        carAudio = GetComponent<AudioSource>();
        carAudio.loop = true;
        carAudio.mute = true;
        carRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        EngineSound();
    }

    void EngineSound()
    {
        currentSpeed = carRb.velocity.magnitude;

        if(currentSpeed < minSpeed)
        {
            carAudio.mute = true;
        }

        if(currentSpeed > minSpeed)
        {
            carAudio.volume = (currentSpeed / maxSpeed);
            carAudio.mute = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player" && currentSpeed > minSpeed)
        {
            carAudio.PlayOneShot(carHit, 2f);
        } else if (collision.gameObject.tag != "Player" && currentSpeed > minSpeed * 10)
        {
            carAudio.PlayOneShot(carHit, 4f);
        } else if (collision.gameObject.tag != "Player" && currentSpeed > minSpeed * 20)
        {
            carAudio.PlayOneShot(carHit, 6f);
        }
    }
}