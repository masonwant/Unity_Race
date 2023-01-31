using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRightWheel;
    [SerializeField] WheelCollider frontLeftWheel;
    [SerializeField] WheelCollider backRightWheel;
    [SerializeField] WheelCollider backLeftWheel;

    [SerializeField] Transform frontRightWheelTransform;
    [SerializeField] Transform frontLeftWheelTransform;
    [SerializeField] Transform backRightWheelTransform;
    [SerializeField] Transform backLeftWheelTransform;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maximumTurning = 30f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurning = 0f;

    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;

        backLeftWheel.motorTorque = currentAcceleration;
        backRightWheel.motorTorque = currentAcceleration;

        frontLeftWheel.brakeTorque = currentBreakForce;
        frontRightWheel.brakeTorque = currentBreakForce;
        backLeftWheel.brakeTorque = currentBreakForce;
        backRightWheel.brakeTorque = currentBreakForce;

        currentTurning = maximumTurning * Input.GetAxis("Horizontal");
        frontLeftWheel.steerAngle = currentTurning;
        frontRightWheel.steerAngle = currentTurning;

        UpdateWheel(frontLeftWheel, frontLeftWheelTransform);
        UpdateWheel(frontRightWheel, frontRightWheelTransform);
        UpdateWheel(backLeftWheel, backLeftWheelTransform);
        UpdateWheel(backRightWheel, backRightWheelTransform);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        col.GetWorldPose(out Vector3 position, out Quaternion rotation);
        trans.SetPositionAndRotation(position, rotation);
    }


}
