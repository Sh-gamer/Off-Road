
using UnityEngine;
using System;
using System.Collections.Generic;

public class PCarController : MonoBehaviour
{
    public enum Axel
    {
        front,
        rear
    }
    [Serializable]
    public struct Wheel
    {
        public GameObject modelWheel;
        public WheelCollider wheelCollider;
        public Axel axel;

    }
    public float maxAcceleration = 30f;
    public float breakAcceleration = 50f;

    public float trunSens = 1f;
    public float maxTurn = 30.0f;

    public List<Wheel> wheels;
    float moveInput;
    float steerInput;
    private Rigidbody rbcar;
    private void Start()
    {
        rbcar = GetComponent<Rigidbody>();
    }
    void getInput()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }
    void Update()
    {
        getInput();   
    }
    void LateUpdate()
    {
        Move();   
    }
    void Move()
    {
       foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * maxAcceleration * 600 * Time.deltaTime;
        }
    }

   void steer()
    {
        foreach(var wheel in wheels)
        {
            if (wheel.axel == Axel.front)
            {
               var _steerAngle = maxTurn * trunSens * steerInput;

            }
        }
    }
}
