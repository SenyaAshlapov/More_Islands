using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField]private Transform _playerTransform;
    [SerializeField]private float _moveSpeed;

    [SerializeField]private AnimationCurve _jumpCurve;
    [SerializeField]private float _jumpForce;
    [SerializeField]private float _jumpDuration;


    [Inject]
    private PlayerMovement _playerMovement;

    
    private PlayerInput _playerInput;
    private Vector2 _moveDirection;

    

    private void Awake() {
        _playerInput = new PlayerInput();

        _playerInput.Player.Jump.performed += context => playerJump();
    }

    private void OnEnable() {
        _playerInput.Enable();
    }

    private void OnDisable() {
        _playerInput.Disable();
    }

    private void Update() {
        playerMove();
    }
    private void playerJump() => _playerMovement.PlayerJumping(_playerTransform, _jumpCurve, _jumpDuration, _jumpForce);

    private void playerMove(){
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        _playerMovement.PlayerMoving(_playerTransform,_moveDirection,_moveSpeed);
    }
}
