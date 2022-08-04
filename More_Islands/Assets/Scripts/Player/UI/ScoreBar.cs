using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBar : MonoBehaviour
{
    [SerializeField]private TMP_Text _goalScore;
    [SerializeField]private TMP_Text _currentScore;

    private void Awake()
    {
        Level.UpdateGoalScoreBar += updateGoalScore;
        Level.UpdateCurrnetScoreBar += updateCurrentScore;
    }
    private void Start() {
        updateGoalScore(Level._goalDyingScore);
    }
    private void OnDestroy() {
        Level.UpdateGoalScoreBar -= updateGoalScore;
        Level.UpdateCurrnetScoreBar -= updateCurrentScore;
    }

    private void updateGoalScore(int newGoalScore) 
    {
        Debug.Log(newGoalScore);
        _goalScore.text = newGoalScore.ToString();
    } 
    private void updateCurrentScore(int newscore) => _currentScore.text = newscore.ToString();
}
