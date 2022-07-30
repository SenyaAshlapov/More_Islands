using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Header("Move options")]    
    [SerializeField]private Transform _playerTransform;
    [SerializeField]private float _moveSpeed;

    [Header("Jump options")]
    [SerializeField]private AnimationCurve _jumpCurve;
    [SerializeField]private float _jumpForce;
    [SerializeField]private float _jumpDuration;

    [Header("Attack options")]
    [SerializeField]private IWeapon _currentWeapon;
    [SerializeField]private MeleWeapon _meleWeapon;


    [Inject]
    private PlayerMovement _playerMovement;

    [Inject]
    private PlayerAttack _playerAttack;

    
    private PlayerInput _playerInput;
    private Vector2 _moveDirection;



    #region unity_functions
    private void Awake() {
        _playerInput = new PlayerInput();

        _playerInput.Player.Jump.performed += context => playerJump();
        _playerInput.Player.Attack.performed += context => playerAttack();
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

    #endregion

    #region Movement

    private void playerMove(){
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        _playerMovement.Moving(_playerTransform,_moveDirection,_moveSpeed);
    }
    private void playerJump() => _playerMovement.Jumping(_playerTransform, _jumpCurve, _jumpDuration, _jumpForce);

    #endregion

    #region Attack
    
    private void playerAttack(){
        _currentWeapon = _meleWeapon;
        _playerAttack.Attacking(_currentWeapon);
    }

    #endregion
}
