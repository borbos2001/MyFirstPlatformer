using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private AnimationScript _animationScript;
    private Rigidbody2D _rbPlayer;
    private bool _sit;
    private BoxCollider2D _boxColliderPlayer;

    
    [Header("Movement vars")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrouded = false;
    [SerializeField] private GameObject _colliderPlayer;
    
    [Header("Settings")]
    [SerializeField] private Transform _groundColliderPosistion;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _jumpOffset;
    [SerializeField] private LayerMask _jumplayerMask;


    private void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
        _animationScript = GetComponent<AnimationScript>();
        _boxColliderPlayer = GetComponentInChildren<BoxCollider2D>();

    }
    private void FixedUpdate()
    {

    }
    private void Update()
    { // проверка на движении - y
        Vector3 overlapCirclePosistion = _groundColliderPosistion.position;
        _isGrouded = Physics2D.OverlapCircle(overlapCirclePosistion, _jumpOffset, _jumplayerMask);
        _animationScript.FlyAnim(_rbPlayer.velocity.y);
        _animationScript.JampAnimation(_isGrouded);

    }
    public void Move(float direction,bool _jumpButtonPressed)
    {
        if (GlobalString._canMove == true)
        {
            if (_jumpButtonPressed)
                Jump();
            if (Mathf.Abs(direction) > 0.01f)
            {
                RotationPlayer(direction);
                HorizontalMovePlayer(direction);
            }
            _animationScript.RunAnimation(direction);


        }
    }
    private void Jump()
    {
        if (_isGrouded)
        {
            _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x, _jumpForce);
        }
    }    
    private void HorizontalMovePlayer(float direction)
    {
        if(_sit ==false)
            _rbPlayer.velocity = new Vector2(_curve.Evaluate(direction) ,_rbPlayer.velocity.y);
    }

    private void RotationPlayer(float directionCollider)
    {
        if(directionCollider < 0)
        {
            _colliderPlayer.transform.rotation = new Quaternion(0, -180, 0, directionCollider);
        }
        else
        {
            _colliderPlayer.transform.rotation = new Quaternion(0, 0, 0, directionCollider);
        }

    }
    public void SitDown(float _sitDown,float _speed)
    {
        if (GlobalString._canMove ==true)
        {
            if (_sitDown < -0.05)
            {
                _sit = true;
                _animationScript.SitAnimation(_sit, _speed);
                _rbPlayer.velocity = new Vector2(_curve.Evaluate(_speed) / 2, _rbPlayer.velocity.y);
                _boxColliderPlayer.offset = new Vector2(0.04858781f, 0.11f);
                _boxColliderPlayer.size = new Vector2(0.1276851f, 0.09f);
            }
            else
            {
                _sit = false;
                _animationScript.SitAnimation(_sit, _speed);
                _boxColliderPlayer.offset = new Vector2(0.0485878f, 0.18f);
                _boxColliderPlayer.size = new Vector2(0.1276851f, 0.2f);
            }
        }
    }

}
