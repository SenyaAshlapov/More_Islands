using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;



public class PlayerSpawner : MonoInstaller
{

    private void Awake() {
        Player.playerInit += initPlayer;
    }

    private void OnDestroy() {
        Player.playerInit -= initPlayer;
    }

    public static Player _playerSingoltone;
    [SerializeField]private GameObject _player;

    [SerializeField]private List<Transform> _spawnPoints = new List<Transform>();

    private void Start() {
        spawnPlayer();
    }
    private void spawnPlayer(){
        
        int count = _spawnPoints.Count;
        int randomSpawnPoint = UnityEngine.Random.Range(0, count);

        Debug.Log("player spawner");
        GameObject player = Instantiate(_player, _spawnPoints[randomSpawnPoint]);



    }

    private void initPlayer(Player player) 
    {
        _playerSingoltone = player;
        
    }

}
