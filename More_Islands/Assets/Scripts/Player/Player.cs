using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Header("Move options")]    
    [SerializeField]private Transform _playerTransform;
    [SerializeField]private float _moveSpeed;
    [SerializeField] private LayerMask _layerMask;

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

    private Camera _mainCamera;
    private PlayerInput _playerInput;
    private Vector2 _moveDirection;
    private Vector2 _mousePosition;



    #region unity_functions
    private void Awake() {
        _playerInput = new PlayerInput();

        _playerInput.Player.Jump.performed += context => playerJump();
        _playerInput.Player.Attack.performed += context => playerAttack();

        _playerInput.Player.MousePosition.performed += context => playerMouseRotation();
    }

    private void Start() {
        _mainCamera = Camera.main;
    }

    private void OnEnable() {
        _playerInput.Enable();
    }

    private void OnDisable() {
        _playerInput.Disable();
    }

    private void Update() {
        playerMove();
        playerMouseRotation();
    }

    #endregion

    #region Movement

    private void playerMove(){
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();       
        _playerMovement.Moving(_playerTransform,_moveDirection,_moveSpeed);
    }

    private void playerMouseRotation(){
        _mousePosition = _playerInput.Player.MousePosition.ReadValue<Vector2>();
        Ray ray = _mainCamera.ScreenPointToRay(_mousePosition);
        RaycastHit rayCastHit;
        if(Physics.Raycast(ray, out rayCastHit, _layerMask))
        {
            _playerMovement.Rotate(_playerTransform, rayCastHit);
        }
       
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
