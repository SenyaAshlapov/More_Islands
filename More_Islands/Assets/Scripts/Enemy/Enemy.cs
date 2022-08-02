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
    [Inject]
    private RangeEnemyAttack _rangeAttack;
    [Inject]
    private MeeleEnemyAttack _meeleAttack;

    #endregion

    [SerializeField]private float _lookRadius;
    [SerializeField]private enemyType _type;
    [SerializeField]private NavMeshAgent _navMeshAgent;

    private Transform _playerTarget => _player.PlayerPosition;


    private void Start()
    {
       _navMeshAgent = GetComponent<NavMeshAgent>();
       _enemyCurrnetState = degenarateStateIdle;
    }

    #region degenarate_state_machine
    private void degenarateStateIdle()
    {
        Debug.Log("idle");
    }

    private void degenarateStateFollow()
    {
        followPlayer();
        Debug.Log("follow");
    }

    private void degenarateStateAttack()
    {
        Debug.Log("attack");
        if(_type == enemyType.meele)
        {
            _meeleAttack.EnemyAttack(10);
        }
        else
        {
            _rangeAttack.EnemyAttack(12);
        }
    }

    private void degenarateStateDying()
    {

    }

    #endregion
    private void Update() 
    {
        _enemyCurrnetState();
        float distanceToPlayer = Vector3.Distance(transform.position, _playerTarget.position);

        if(distanceToPlayer <= _lookRadius && distanceToPlayer > _navMeshAgent.stoppingDistance){
            _enemyCurrnetState = degenarateStateFollow;
        }

        if(distanceToPlayer <= _navMeshAgent.stoppingDistance)
        {
            _enemyCurrnetState = degenarateStateAttack;
        }
        
    }

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
}
