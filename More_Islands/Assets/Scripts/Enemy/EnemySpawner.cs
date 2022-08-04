using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour 
{
    public delegate void enemySpawnerEvent();
    public static enemySpawnerEvent EnemySpawn;
    private Player _player;
    private Transform _playerTarget => _player.PlayerPosition;
    private float _distanceToPlayer;
    [SerializeField] private List<Enemy> _enemyPrefabs = new List<Enemy>();
    [SerializeField] private float _range;
    [SerializeField] private float _spawnRange;



    private void Awake() 
    {
        Player.playerInit += initPlayer;
        EnemyPool.SpawnEnemy += spawnEnemy;
        
        Debug.Log("enemy spawner");
        
    }

    private void Start() {
        int count = _enemyPrefabs.Count;
        int randomEnemy = Random.Range(0, count);

        Vector3 randomPosition = new Vector3(Random.Range(0, _spawnRange/2), 0, Random.Range(0, _spawnRange/2));
        EnemySpawn?.Invoke();
        var enemy = Instantiate(_enemyPrefabs[randomEnemy], transform.position + randomPosition, Quaternion.identity);
    }

    private void OnDestroy() 
    {
        Player.playerInit -= initPlayer;
        EnemyPool.SpawnEnemy -= spawnEnemy;
    }


    private void Update() 
    {       
        _distanceToPlayer = Vector3.Distance(transform.position, _playerTarget.position);
        
    }

    private void initPlayer(Player player) 
    {
        _player = player;
        
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _range);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _spawnRange);
    }

    private void spawnEnemy()
    {
        if(_distanceToPlayer >= _range)
        {      
            int count = _enemyPrefabs.Count;
            int randomEnemy = Random.Range(0, count);

            Vector3 randomPosition = new Vector3(Random.Range(0, _spawnRange/2), 0, Random.Range(0, _spawnRange/2));
            EnemySpawn?.Invoke();
            var enemy = Instantiate(_enemyPrefabs[randomEnemy], transform.position + randomPosition, Quaternion.identity);
        }
        
            
        
        
    }
/*     private IEnumerator IEspawn(){
        bool cicle = true;
        while(cicle == true){
            if(_playerInArea == false)
            {        
                
                yield return new WaitForSeconds(_spawnTimer);
            }
        }
        

        yield return null;
    } */

}
