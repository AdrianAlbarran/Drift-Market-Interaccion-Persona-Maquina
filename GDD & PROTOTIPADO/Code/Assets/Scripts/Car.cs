using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;

    public WheelCollider wheelColliderLeftFront;
    public WheelCollider wheelColliderRightFront;
    public WheelCollider wheelColliderLeftBack;
    public WheelCollider wheelColliderRightBack;

    public Transform wheelLeftFront;
    public Transform wheelRightFront;
    public Transform wheelLeftBack;
    public Transform wheelRightBack;    

    public float motorTorque = 200f;
    public float maxSteer = 45f;
    public bool isbrake = false;
    public float brakeTorque = 5000f;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    void FixedUpdate()
    {
        wheelColliderLeftBack.motorTorque = Input.GetAxis("RT") * motorTorque;
        wheelColliderRightBack.motorTorque = Input.GetAxis("RT") * motorTorque;
        wheelColliderLeftFront.motorTorque = Input.GetAxis("RT") * motorTorque;
        wheelColliderRightFront.motorTorque = Input.GetAxis("RT") * motorTorque;

        wheelColliderLeftBack.motorTorque = Input.GetAxis("LT") * -motorTorque;
        wheelColliderRightBack.motorTorque = Input.GetAxis("LT") * -motorTorque;
        wheelColliderLeftFront.motorTorque = Input.GetAxis("LT") * -motorTorque;
        wheelColliderRightFront.motorTorque = Input.GetAxis("LT") * -motorTorque;

        wheelColliderLeftFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
        wheelColliderRightFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;

        if (Input.GetAxis("Brake") == 1) {
            isbrake = true;
        } else {
            isbrake = false;
        }
        
        if (isbrake == true) {
            wheelColliderLeftBack.brakeTorque = brakeTorque;
            wheelColliderRightBack.brakeTorque = brakeTorque;
        } else {
            wheelColliderLeftBack.brakeTorque = 0;
            wheelColliderRightBack.brakeTorque = 0;
        }
    }
}