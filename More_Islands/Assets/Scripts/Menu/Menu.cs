using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    private Saver _saver;
    [SerializeField]private TMP_Text _bastScore;
    [SerializeField]private TMP_Text _currentScore;
    [SerializeField]private GameObject _options;
    private bool _isOptionsShow = false;

    private void Start() {
        _saver = new Saver();
        _saver.LoadSaves();
        loadScoreUI();
        
    }

    public void ContinueGame(){
        bool isFirst = _saver.LoadFirstGame();
        if(isFirst == false)
        {
            SceneManager.LoadScene("Boot scene");
        }
        
    }

    public void NewGame()
    {
        _saver.RemoveSaves();
        SceneManager.LoadScene("Boot scene");
    }

    ///deleta on build
    public void RemoveAll(){
        _saver.RemoveAllSaves();
    }

    public void ShowOptions()
    {
        _isOptionsShow = !_isOptionsShow;
        _options.SetActive(_isOptionsShow);
    }

    public void ExitGame()
    {

    }

    private void loadScoreUI(){
        
        int bestScore = _saver.LoadBestScore();
        int score = _saver.LoadScore();

        _bastScore.text = bestScore.ToString();
        _currentScore.text = score.ToString();
    }
}
