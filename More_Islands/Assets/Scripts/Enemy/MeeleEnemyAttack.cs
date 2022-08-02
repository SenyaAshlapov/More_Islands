using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MeeleEnemyAttack : MonoBehaviour, IEnemyAttack
{
    public  void EnemyAttack(float damage){
        Debug.Log(damage);
    }
}
