using System.Collections.Generic;
using UnityEngine;

public class IslandSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> _islands = new List<GameObject>();
    [SerializeField]private Transform _islandPoint;

    private void Awake() {
        spawnIsland();
    }
    private void spawnIsland()
    {
        int count = _islands.Count;

        int randomIslan = Random.Range(0, count);
        Instantiate(_islands[randomIslan], _islandPoint);

    }
}
