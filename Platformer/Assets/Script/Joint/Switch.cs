using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] SliderJoint2D _elevatorJoint;
    [SerializeField] GameObject _up;
    [SerializeField] GameObject _down;
    private bool _Stay;
    private Elevator _elevator;

    private JointMotor2D _motor2D;
    private bool _dilaySwitch = false;
    void Start()
    {
        _elevator = GetComponent<Elevator>();
    }
    private void Update()
    {
        if(_Stay)
        {
            if (_dilaySwitch && Input.GetKeyDown(KeyCode.E))
            {
                _elevatorJoint.useMotor = false;
                _elevatorJoint.useMotor = true;
                _dilaySwitch = false;
                _up.SetActive(false);
                _down.SetActive(true);
                _elevator.FixedUpdate(false);
            }
            else
            if (!_dilaySwitch && Input.GetKeyDown(KeyCode.E))
            {
                _elevatorJoint.useMotor = false;
                _elevatorJoint.useMotor = true;
                _dilaySwitch = true;
                _up.SetActive(true);
                _down.SetActive(false);
                _elevator.FixedUpdate(true);
                StartCoroutine(Dilay());

            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "adventurer")
        {
            _Stay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "adventurer")
        {
            _Stay = false;
        }
    }
    private IEnumerator Dilay()
    {
        yield return new WaitForSeconds(10f);
        if(_dilaySwitch == true)
        {
            _elevatorJoint.useMotor = false;
            _elevatorJoint.useMotor = true;
            _dilaySwitch = false;
            _up.SetActive(false);
            _down.SetActive(true);
            _elevator.FixedUpdate(false);
        }

    }
}
