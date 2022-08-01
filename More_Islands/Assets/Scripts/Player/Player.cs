using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    #region move_options
    [Header("Move options")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask _layerMask;
    private Camera _mainCamera;
    private PlayerInput _playerInput;

    private Vector2 _moveDirection;
    private Vector2 _mousePosition;

    #endregion

    [Space(10)]
    #region  jump_options
    [Header("Jump options")]
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpDuration;

    #endregion

    [Space(10)]
    #region  combat_options

    [Header("Combat options")]
    private IWeapon _currentWeapon;
    [SerializeField] private MeleWeaponDATA _testWeapon;
    [SerializeField] private RangeWeaponDATA _testWeapon2;
    [SerializeField] private Transform _weaponPoint;

    #endregion

    #region animations_options

    [Header("Animations options")]
    [SerializeField]private Animator _animator;

    #endregion

    #region injects
    [Inject]
    private PlayerMovement _playerMovement;

    [Inject]
    private PlayerAttack _playerAttack;

    #endregion


    #region Unity_functions
    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Jump.performed += context => playerJump();
        _playerInput.Player.Attack.performed += context => playerAttack();

        _playerInput.Player.MousePosition.performed += context => playerMouseRotation();
    }

    private void Start()
    {
        _mainCamera = Camera.main;
        //_currentWeapon = _testWeapon;
        _currentWeapon = _testWeapon2;
        initWeapon(_currentWeapon);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        playerMove();
        playerMouseRotation();
    }

    #endregion

    #region Movement

    private void playerMove()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        _playerMovement.Moving(_playerTransform, _moveDirection, _moveSpeed, _animator);
    }

    private void playerMouseRotation()
    {
        if(_moveDirection.x + _moveDirection.y != 0){
            _mousePosition = _playerInput.Player.MousePosition.ReadValue<Vector2>();
            Ray ray = _mainCamera.ScreenPointToRay(_mousePosition);
            RaycastHit rayCastHit;
            if (Physics.Raycast(ray, out rayCastHit, _layerMask))
            {
                _playerMovement.Rotate(_playerTransform, rayCastHit);
            }
        }
        

    }
    private void playerJump() => _playerMovement.Jumping(_playerTransform, _jumpCurve, _jumpDuration, _jumpForce);

    #endregion

    #region Attack

    private void playerAttack()
    {
        _playerAttack.Attack(_currentWeapon);
    }
    private void initWeapon(IWeapon weapon)
    {
        weapon.InitWeapon(_weaponPoint);
    }

    #endregion
}
