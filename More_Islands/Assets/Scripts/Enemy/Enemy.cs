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
    private EnemyState _enemyCurrnetState;

    #endregion

    #region injects
    [Inject]
    private Player _player;

    #endregion

    #region  move_options
    [Header("Move options")]
    [SerializeField]private float _lookRadius;
    [SerializeField]private NavMeshAgent _navMeshAgent;
    private Transform _playerTarget => _player.PlayerPosition;

    private float _distanceToPlayer;

    #endregion

    #region combat_options
    [Header("Combat options")]
    [SerializeField]private float _damage;
    [SerializeField]private float _coolDown;
    [SerializeField]private enemyType _type;
    private bool isAtack = false;
    private IEnemyAttack _enemyAttack;

    #endregion

    #region animation_options
    [Header("Animations otions")]
    [SerializeField]private Animator _enemyAnimator;
    private EnemyAnimate _enemyAnimation;

    #endregion


    private void Start()
    {
        _enemyCurrnetState = degenarateStateIdle;
        _enemyAnimation = new EnemyAnimate(_enemyAnimator);


        if(_type == enemyType.meele){
            _enemyAttack = new MeeleEnemyAttack();
        }
        else
        {
            _enemyAttack = new RangeEnemyAttack();
        }
    }
    private void FixedUpdate() 
    {
        _enemyCurrnetState();
        _distanceToPlayer = Vector3.Distance(transform.position, _playerTarget.position);
        
        if(_distanceToPlayer > _lookRadius){
            _enemyCurrnetState = degenarateStateIdle;
        }

        if(_distanceToPlayer <= _lookRadius && _distanceToPlayer > _navMeshAgent.stoppingDistance){
            _enemyCurrnetState = degenarateStateFollow;
        }

        if(_distanceToPlayer < _navMeshAgent.stoppingDistance){
            _enemyCurrnetState = degenarateStateAttack;
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

        if(isAtack == false)
        {
            StartCoroutine(attack());
        }
        
    }

    private void degenarateStateDying()
    {
        _enemyAnimation.ChangeAnimation(_enemyAnimation.DEAD_KEY);
    }

    #endregion

    private void followPlayer(){
        _navMeshAgent.SetDestination(_playerTarget.position);
    }

    public void GetDamage(float damage, float coolDown){
        Debug.Log(damage);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);
    }

    private IEnumerator attack(){
        isAtack = true;
        yield return new WaitForSeconds(_coolDown);

        if(_type == enemyType.meele){
            _enemyAnimation.ChangeAnimation(_enemyAnimation.SLASH_KEY);
        }
        else{
            _enemyAnimation.ChangeAnimation(_enemyAnimation.SHOT_KEY);
        }
        yield return new WaitForSeconds(0.2f);
        _enemyAnimation.ChangeAnimation(_enemyAnimation.IDLE_KEY);


        _player.GetDamage(_damage);
        
        yield return new WaitForSeconds(_coolDown);
        isAtack = false;

        yield return null;
    }
}
