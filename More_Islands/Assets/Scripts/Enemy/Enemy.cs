using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

enum enemyType{
    meele,
    range
}

public class Enemy : MonoBehaviour
{
    #region  delegates
    private delegate void EnemyState();
    public delegate void EnemyAction();
    private EnemyState _enemyCurrnetState;

    public static EnemyAction EnemyDying;

    #endregion
    private Player _player;

    #region  move_options
    [Header("Move options")]
    [SerializeField]private float _lookRadius;
    [SerializeField]private NavMeshAgent _navMeshAgent;
    private Transform _playerTarget => _player.PlayerPosition;

    private float _distanceToPlayer;

    #endregion

    #region combat_options
    [Header("Combat options")]

    [SerializeField]private float _health;
    [SerializeField]private float _damage;
    [SerializeField]private float _coolDown;
    [SerializeField]private enemyType _type;
    private bool isAtack = false;
    private bool _isAlive = true;

    #endregion

    #region animation_options
    [Header("Animations otions")]
    [SerializeField]private Animator _enemyAnimator;
    private EnemyAnimate _enemyAnimation;

    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private AudioSource _punchSound;

    #endregion

    private void Awake() {
        Level.LevelComplete += levelComplete;
    }

    private void OnDestroy() 
    {
        Level.LevelComplete -= levelComplete;
    }
    private void Start()
    {
        GetPlayer(PlayerSpawner._playerSingoltone);
        
        _enemyCurrnetState = degenarateStateIdle;
        _enemyAnimation = new EnemyAnimate(_enemyAnimator);
    }
    private void Update() 
    {
        _enemyCurrnetState();
        if(_isAlive == true)
        {
            _distanceToPlayer = Vector3.Distance(transform.position, _playerTarget.position);
        
            if(_distanceToPlayer > _lookRadius)
            {
                _enemyCurrnetState = degenarateStateIdle;
            }

            if(_distanceToPlayer <= _lookRadius && _distanceToPlayer > _navMeshAgent.stoppingDistance)
            {
                _enemyCurrnetState = degenarateStateFollow;
            }

            if(_distanceToPlayer <= _navMeshAgent.stoppingDistance)
            {
                _enemyCurrnetState = degenarateStateAttack;
            }
        }
        else
        {
            _enemyCurrnetState = degenarateStateDying;
        }   
    }

    #region degenarate_state_machine
    private void degenarateStateIdle()
    {
        _enemyAnimation.ChangeAnimation(_enemyAnimation.IDLE_KEY);
    }

    private void degenarateStateFollow()
    {
        followPlayer();
        _enemyAnimation.ChangeAnimation(_enemyAnimation.RUN_KEY);
    }

    private void degenarateStateAttack()
    {
        transform.LookAt(_playerTarget, Vector3.up);

        if(isAtack == false)
        {
            StartCoroutine(IEattack());
        }
        
    }

    private void degenarateStateDying()
    {
        
        StartCoroutine(IEdying());
        
    }

    #endregion

    private void followPlayer(){
        _navMeshAgent.SetDestination(_playerTarget.position);
    }

    public void GetDamage(float damage){
        _health -= damage;
        if(_isAlive == true)
        {
            _punchSound.Play(0);
            if(_health <= 0)
            {
            _isAlive = false;
            EnemyDying?.Invoke();
            }
        }
        
    }
    public void GetPlayer(Player player) 
    {
        _player = player;
    } 

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);
    }


    private IEnumerator IEattack(){
        isAtack = true;
        _enemyAnimation.ChangeAnimation(_enemyAnimation.IDLE_KEY);
        yield return new WaitForSeconds(_coolDown/2);

        if(_type == enemyType.meele){
            _enemyAnimation.ChangeAnimation(_enemyAnimation.SLASH_KEY);
        }
        else{
            _enemyAnimation.ChangeAnimation(_enemyAnimation.SHOT_KEY);
            yield return new WaitForSeconds(0.3f);
            _shotSound.Play();
        }
        yield return new WaitForSeconds(0.8f);
        _enemyAnimation.ChangeAnimation(_enemyAnimation.IDLE_KEY);

        if(_isAlive == true)
            _player.GetDamage(_damage);
        
        yield return new WaitForSeconds(_coolDown/2);
        isAtack = false;

        yield return null;
    }

    private void levelComplete()
    {
        
        _enemyCurrnetState = degenarateStateDying;
    }
    private IEnumerator IEdying(){
        
        _enemyAnimation.ChangeAnimation(_enemyAnimation.DEAD_KEY);
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }



}

