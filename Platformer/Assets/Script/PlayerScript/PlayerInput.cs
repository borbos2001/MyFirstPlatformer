
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerHit))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMove _playerMove;
    private PlayerHit _playerHit;
    private bool _control= true;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerHit = GetComponent<PlayerHit>();
    }
    private void Update()
    {
        float _horizontalDirection = Input.GetAxis(GlobalString._Horizontal_Axis);
        bool _horizontalPressed = Input.GetButtonDown(GlobalString._Horizontal_Axis);
        bool _jumpButtonPressed = Input.GetButtonDown(GlobalString._Jump_Axis);
        bool _impactTriggering = Input.GetButtonDown(GlobalString._Hit_Axis);
        float _sitDown = Input.GetAxis(GlobalString._Sit_Axis);
        _playerMove.Move(_horizontalDirection, _jumpButtonPressed);
        _playerHit.SwordStrike(_impactTriggering);
        _playerMove.SitDown(_sitDown, _horizontalDirection);
    }
}
