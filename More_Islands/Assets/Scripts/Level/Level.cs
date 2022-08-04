using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public delegate void LevelAction(int score);
    public static LevelAction UpdateGoalScoreBar;
    public static LevelAction UpdateCurrnetScoreBar;
    public delegate void LevelAction1();
    public static LevelAction1 LevelComplete;


    [SerializeField]private LevelData _levelData;
    private Saver _saver;
    public static int _goalDyingScore;
    private int _currentDyingScore = 0;

    private void Awake() 
    {
        Enemy.EnemyDying += addDyingScore;
        Player.PlayerDying += levelFailed;
    }

    private void Start() 
    {
        LoadLevel();
    }

    private void OnDestroy() 
    {
        Enemy.EnemyDying -= addDyingScore;
        Player.PlayerDying -= levelFailed;
    }

    private void LoadLevel()
    {
        _saver = new Saver();

        bool isFirst = _saver.LoadFirstGame();

        showGuide();
            
        

        int currentScore = _saver.LoadScore();
        _goalDyingScore = _levelData._enemyToScore[currentScore];
        UpdateGoalScoreBar?.Invoke(_goalDyingScore);

    }

    private void showGuide()
    {

    }

    private void addDyingScore()
    {
        _currentDyingScore = _currentDyingScore + 1;
        UpdateCurrnetScoreBar?.Invoke(_currentDyingScore);
        if(_currentDyingScore >= _goalDyingScore)
        {
            levelComplete();
        }

    }

    private void levelComplete()
    {
        LevelComplete?.Invoke();
        _saver.SaveIsFirst(false);

        int score = _saver.LoadScore() + 1;
        int bestScore = _saver.LoadBestScore();

        _saver.SaveScore(score);

        if(score > bestScore)
        {
            _saver.SaveBestScore(bestScore + 1);
        }

    }

    private void levelFailed(){
        _saver.SaveScore(0);
        _saver.SaveIsFirst(true);
    }
    
}
