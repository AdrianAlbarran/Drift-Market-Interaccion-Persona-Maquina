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

    public float motorTorque = 400f;
    public float maxSteer = 40f;
    public bool isbrake = false;
    public float brakeTorque = 100f;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    void FixedUpdate()
    {
        if (SimpleInput.GetAxis("Vertical") > 0 | SimpleInput.GetAxis("Vertical") < 0) {
            wheelColliderLeftBack.motorTorque = SimpleInput.GetAxis("Vertical") * motorTorque;
            wheelColliderRightBack.motorTorque = SimpleInput.GetAxis("Vertical") * motorTorque;
            wheelColliderLeftFront.motorTorque = SimpleInput.GetAxis("Vertical") * motorTorque * 0.2f;
            wheelColliderRightFront.motorTorque = SimpleInput.GetAxis("Vertical") * motorTorque * 0.2f;
        } else if (SimpleInput.GetAxis("Acelerate") > 0 | SimpleInput.GetAxis("Acelerate") < 0){
            wheelColliderLeftBack.motorTorque = SimpleInput.GetAxis("Acelerate") * motorTorque;
            wheelColliderRightBack.motorTorque = SimpleInput.GetAxis("Acelerate") * motorTorque;
            wheelColliderLeftFront.motorTorque = SimpleInput.GetAxis("Acelerate") * motorTorque * 0.2f;
            wheelColliderRightFront.motorTorque = SimpleInput.GetAxis("Acelerate") * motorTorque * 0.2f;
        } else if (SimpleInput.GetAxis("Back") > 0 | SimpleInput.GetAxis("Back") < 0) {
            wheelColliderLeftBack.motorTorque = SimpleInput.GetAxis("Back") * -motorTorque;
            wheelColliderRightBack.motorTorque = SimpleInput.GetAxis("Back") * -motorTorque;
            wheelColliderLeftFront.motorTorque = SimpleInput.GetAxis("Back") * -motorTorque * 0.2f;
            wheelColliderRightFront.motorTorque = SimpleInput.GetAxis("Back") * -motorTorque * 0.2f;
        }

        wheelColliderLeftFront.steerAngle = SimpleInput.GetAxis("Horizontal") * maxSteer;
        wheelColliderRightFront.steerAngle = SimpleInput.GetAxis("Horizontal") * maxSteer;

        if (SimpleInput.GetAxis("Brake") > 0) {
            isbrake = true;
        } else {
            isbrake = false;
        }
        
        if (isbrake == true) {
            wheelColliderLeftBack.brakeTorque = brakeTorque;
            wheelColliderRightBack.brakeTorque = brakeTorque;
            maxSteer = 65f;
            maxSteer = 65f;
            wheelColliderLeftBack.forceAppPointDistance = 0.7f;
            wheelColliderRightBack.forceAppPointDistance = 0.7f;
        } else {
            wheelColliderLeftBack.brakeTorque = 0;
            wheelColliderRightBack.brakeTorque = 0;
            maxSteer = 40f;
            maxSteer = 40f;
            wheelColliderLeftBack.forceAppPointDistance = 0;
            wheelColliderRightBack.forceAppPointDistance = 0;
        }
    }
}