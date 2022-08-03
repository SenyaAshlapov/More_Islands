using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSpawner : MonoBehaviour
{


    [SerializeField]private GameObject _player;

    [SerializeField]private List<Transform> _spawnPoints = new List<Transform>();

    private void Start() {
        spawnPlayer();
    }
    private void spawnPlayer(){
        
        int count = _spawnPoints.Count;

        System.Random random = new System.Random();

        int randomSpawnPoint = random.Next(0, count );

        Debug.Log(randomSpawnPoint);

        Instantiate(_player, _spawnPoints[randomSpawnPoint]);
    }

}
