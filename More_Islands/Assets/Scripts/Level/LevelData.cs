using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "More_Islands/LevelData", order = 0)]
public class LevelData : ScriptableObject 
{
    public List<int> _enemyToScore = new List<int>();
}
