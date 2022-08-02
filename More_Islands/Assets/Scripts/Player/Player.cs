using UnityEngine;
using Zenject;


public class Player : MonoBehaviour
{
    
    #region injects
    [Inject]
    private PlayerMovement _playerMovement;

    [Inject]
    private PlayerAttack _playerAttack;

    #endregion
    
    #region move_options
    [Header("Move options")]
    [SerializeField] private Transform _playerTransform;
    public Transform PlayerPosition => _playerTransform;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField]private bool _isCanMove = true;
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
    [SerializeField] private MeleWeaponDATA _testWeapon;
    [SerializeField] private RangeWeaponDATA _testWeapon2;
    [SerializeField] private Transform _weaponPoint;

    private IWeapon _currentWeapon;

    #endregion

    [Space(10)]
    #region animations_options
    [Header("Animations options")]
    [SerializeField]private Animator _playerAnimator;

    #endregion

    [SerializeField]private float HP = 100;
    #region unity_functions
    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Jump.performed += context => playerJump();
        _playerInput.Player.Attack.performed += context => playerAttack();

        _playerInput.Player.MousePosition.performed += context => playerMouseRotation();

        PlayerAttack.canMove += canMove;
        PlayerAttack.weaponVisible += weaponVisible;
    }

    private void Start()
    {
        _mainCamera = Camera.main;
        _currentWeapon = _testWeapon;
        //_currentWeapon = _testWeapon2;
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

    private void OnDestroy() {
        PlayerAttack.canMove -= canMove;
        PlayerAttack.weaponVisible -= weaponVisible;
    }

    #endregion

    #region Movement

    private void playerMove()
    {
        if(_isCanMove == true){
            _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
            _playerMovement.Moving(_playerTransform, _moveDirection, _moveSpeed, _playerAnimator);
        }
        
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

    #region Combat

    private void playerAttack()
    {
        _playerAttack.Attack(_currentWeapon, _playerAnimator);
    }
    private void initWeapon(IWeapon weapon)
    {
        _currentWeapon.InitWeapon(_weaponPoint);
    }

    public void GetDamage(float damage){
        HP -= damage;
        Debug.Log(HP);
    }

    private void canMove(bool isCanMove) => _isCanMove = isCanMove;
    private void weaponVisible(bool isVisible) => _weaponPoint.gameObject.SetActive(isVisible);

    #endregion
}
