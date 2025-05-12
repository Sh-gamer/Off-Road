using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GeometryCar : MonoBehaviour
{
    //private const string HORIZONTAL = "Horizontal";
    //private const string VERTICAL = "Vertical";

    public float _VerticalInputs;
    public float _HorizontalInputs;
    public float _CurrentBreakPower;
    public bool _IsBreacking;
    public Vector3 _centerofmass;



    //public GameObject _BreackLight;
    //public GameObject _HeadLight;
    //public GameObject _Beam;

    [SerializeField] private float MotorForce;
    [SerializeField] private float _BreakPower;
    [SerializeField] private float _MaxStreeing;
    [SerializeField] private float _4WPW = 1.2f;


    public bool _4WD = false;

    [SerializeField] private WheelCollider RightFrontWheel;
    [SerializeField] private WheelCollider LeftFrontWheel;
    [SerializeField] private WheelCollider RightRearWheel;
    [SerializeField] private WheelCollider LeftRearWheel;

    [SerializeField] private Transform RightFrontWheelTransform;
    [SerializeField] private Transform LeftFrontWheelTransform;
    [SerializeField] private Transform RightrearWheelTransform;
    [SerializeField] private Transform LeftrearWheelTransform;

    public Rigidbody carRB;

    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        carRB.centerOfMass = _centerofmass;
    }



    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _4WD = true;
            RightFrontWheel.motorTorque = _VerticalInputs * MotorForce * _4WPW;

            LeftFrontWheel.motorTorque = _VerticalInputs * MotorForce * _4WPW;

        }

        MotorController();
        SteeringController();
        WheelsUpdets();
        // _Light();


    }
    void LateUpdate()
    {
        Inputs();
    }
    private void Inputs()
    {

        _HorizontalInputs = Input.GetAxis("Horizontal");
        //_HorizontalInputs = CrossPlatformInputManager.GetAxis("Horizontal");
        _VerticalInputs = Input.GetAxis("Vertical");
        //_VerticalInputs = CrossPlatformInputManager.GetAxis("Vertical");

        _4WD = Input.GetKey(KeyCode.E);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _IsBreacking = true;
            Debug.Log("on");

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("off");
            _IsBreacking = false;
        }


    }
    private void MotorController()
    {

        LeftRearWheel.motorTorque = _VerticalInputs * MotorForce;
        RightRearWheel.motorTorque = _VerticalInputs * MotorForce;
        _CurrentBreakPower = _IsBreacking ? _BreakPower : 0f;
        if (_IsBreacking)
        {
            ApplyinBreak();

        }



    }
    private void ApplyinBreak()
    {


        RightFrontWheel.brakeTorque = _CurrentBreakPower;
        LeftFrontWheel.brakeTorque = _CurrentBreakPower;
        RightRearWheel.brakeTorque = _CurrentBreakPower;
        LeftRearWheel.brakeTorque = _CurrentBreakPower;
        _IsBreacking = false;
        Debug.Log("off");
    }
    private void SteeringController()
    {
        float curentsteer = _MaxStreeing * _HorizontalInputs;
        LeftFrontWheel.steerAngle = curentsteer;
        RightFrontWheel.steerAngle = curentsteer;
    }

    private void WheelsUpdets()
    {
        UpdetsingleWHeel(LeftFrontWheel, LeftFrontWheelTransform);
        UpdetsingleWHeel(RightFrontWheel, RightFrontWheelTransform);
        UpdetsingleWHeel(LeftRearWheel, LeftrearWheelTransform);
        UpdetsingleWHeel(RightRearWheel, RightrearWheelTransform);
    }

    private void UpdetsingleWHeel(WheelCollider wheelCollider, Transform WheelTransform)
    {
        Vector3 pos;
        Quaternion qut;
        wheelCollider.GetWorldPose(out pos, out qut);
        WheelTransform.position = pos;
        WheelTransform.rotation = qut;
    }
    //private void _Light()
    //{
    //    if (_VerticalInputs < 0f)
    //    {
    //        _BreackLight.SetActive(true);
    //    }
    //    else
    //    {
    //        _BreackLight.SetActive(false);
    //    }

    //    if (Input.GetKey(KeyCode.H))
    //    {
    //        _HeadLight.SetActive(true);
    //    }
    //    if (Input.GetKey(KeyCode.J))
    //    {
    //        _HeadLight.SetActive(false);
    //        _Beam.SetActive(false);

    //    }
    //    if (Input.GetKey(KeyCode.K))
    //    {
    //        _Beam.SetActive(true);
    //    }

    //}
}