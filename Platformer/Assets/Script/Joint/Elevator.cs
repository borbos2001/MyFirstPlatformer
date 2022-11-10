
using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private SliderJoint2D _joint2D;
    private JointMotor2D _motor2D;
    void Start()
    {
        _joint2D = GetComponent<SliderJoint2D>();
        _motor2D.maxMotorTorque = 10000;
    }

    public void FixedUpdate(bool _onOff)
    {
        if (_onOff) 
        {
            _motor2D.motorSpeed = 0.34f *(-1);
            _joint2D.motor = _motor2D;

            
        }
        else
        {
            _motor2D.motorSpeed = 0.34f;
            _joint2D.motor = _motor2D;
        }
    }

}
