using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private float _speed, _timeToRevert;
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _body;

    private Rigidbody2D _rigidbody2D;

    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;


    private float _currentState, _curremtTimeToRevert;
    void Start()
    {
        _curremtTimeToRevert = 0;
        _currentState = WALK_STATE;
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        if (_curremtTimeToRevert >=_timeToRevert)
        {
            _curremtTimeToRevert = 0;
            _currentState = REVERT_STATE;

        }
        switch(_currentState)
        {
            case IDLE_STATE:
                _curremtTimeToRevert += Time.deltaTime;
                break;
            case WALK_STATE:
                _rigidbody2D.velocity = Vector2.right *_speed;
                break;
            case REVERT_STATE:
                if (_speed > 0)
                {
                    _body.transform.rotation = new Quaternion(0, 0, 0, _speed);
                }
                else
                {
                    _body.transform.rotation = new Quaternion(0, -180, 0, _speed);
                }
                _speed *= -1;
                _currentState = WALK_STATE;
                break ;

        }
        _anim.SetFloat("Velocity", _rigidbody2D.velocity.magnitude);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStop"))
            _currentState = IDLE_STATE;
    }
}
