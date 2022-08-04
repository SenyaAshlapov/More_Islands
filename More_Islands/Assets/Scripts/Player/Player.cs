using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class Player : MonoBehaviour
{
    public delegate void playerSpawnerEvent(Player player);
    public static playerSpawnerEvent playerInit;

    public delegate void playerEvent();
    public static playerEvent PlayerDying;


    #region injects
    [Inject]
    private PlayerMovement _playerMovement;

    [Inject]
    private PlayerAttack _playerAttack;
        
    [Inject]
    private PlayerAnimations _playerAnimations;

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

    [SerializeField] private float _health;
    [SerializeField] private MeleWeaponDATA _testWeapon;
    [SerializeField] private RangeWeaponDATA _testWeapon2;
    [SerializeField] private Transform _weaponPoint;
    private IWeapon _currentWeapon;
    private bool _isAlive = true;

    #endregion

    [Space(10)]
    #region animations_options
    [Header("Animations options")]
    [SerializeField]private Animator _playerAnimator;

    #endregion

    [Header("UI Options")]
    [SerializeField]private Health _healthBar;


    #region unity_functions
    private void Awake()
    {
        Debug.Log("player Awake");
        playerInit?.Invoke(this);

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
        if(_isAlive == true)
        {
            playerMove();
            playerMouseRotation();
        }
        else
        {
            playerDead();
        }

    }

    private void OnDestroy() {
        PlayerAttack.canMove -= canMove;
        PlayerAttack.weaponVisible -= weaponVisible;
    }

    #endregion

    #region Movement

    private void playerMove()
    {
        if(_isCanMove == true)
        {
            _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
            _playerMovement.Moving(_playerTransform, _moveDirection, _moveSpeed, _playerAnimator);
        }
        
    }

    private void playerMouseRotation()
    {
        if(_moveDirection.x + _moveDirection.y != 0)
        {
            _mousePosition = _playerInput.Player.MousePosition.ReadValue<Vector2>();

            Ray ray = _mainCamera.ScreenPointToRay(_mousePosition);
            RaycastHit[] rayCastHits = Physics.RaycastAll(ray, _layerMask);
            foreach(RaycastHit hit in rayCastHits)
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")){
                    _playerMovement.Rotate(_playerTransform, hit);
                }
                
            }

        }
        

    }
    private void playerJump() 
    {
        if(_isAlive == true)
            _playerMovement.Jumping(_playerTransform, _jumpCurve, _jumpDuration, _jumpForce);
    }
   
    #endregion

    #region Combat

    private void playerAttack()
    {
        if(_isAlive == true)
            _playerAttack.Attack(_currentWeapon, _playerAnimator);
    }
    private void initWeapon(IWeapon weapon)
    {
        _currentWeapon.InitWeapon(_weaponPoint);
    }

    public void GetDamage(float damage){
        _health -= damage;
        _healthBar.UpdateHealthBar(_health);
        if(_health <= 0 )
        {
            _isAlive = false;
            PlayerDying?.Invoke();
        }
    }

    private void canMove(bool isCanMove) => _isCanMove = isCanMove;
    private void weaponVisible(bool isVisible) => _weaponPoint.gameObject.SetActive(isVisible);

    #endregion

    #region Dying

    public void UpdateWeapon(IWeapon newWeapon)
    {
        _currentWeapon = newWeapon;
    }
    private void playerDead(){
        StartCoroutine(IEdying());
    }

    private IEnumerator IEdying(){
        _playerAnimations.PlayerDeadAnnimate(_playerAnimator);


        yield return null;   
    }
    #endregion
}
