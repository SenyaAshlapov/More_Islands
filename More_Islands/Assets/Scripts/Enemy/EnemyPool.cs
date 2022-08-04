using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public delegate void enemyPoolEvent();
    public static enemyPoolEvent SpawnEnemy;
    [SerializeField]private int _maxEnemy;
    [SerializeField]private int _minEnemy;

    [SerializeField]private int CurrentEnemyPool = 0;
    

    private void Awake() {
        Enemy.EnemyDying += removeEnemy;
        EnemySpawner.EnemySpawn += addEnemy;
    }

    private void OnDestroy() {
        Enemy.EnemyDying -= removeEnemy;
        EnemySpawner.EnemySpawn -= addEnemy;
    }

    private void removeEnemy() 
    {
        CurrentEnemyPool = CurrentEnemyPool - 1;
        if(CurrentEnemyPool <= _minEnemy)
        {
            SpawnEnemy?.Invoke();
        }
    } 
    private void addEnemy() {
        CurrentEnemyPool = CurrentEnemyPool + 1;
    }
    
}
