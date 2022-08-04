using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteWindows : MonoBehaviour
{
    [SerializeField]private GameObject _levelCompleteWindow;
    [SerializeField]private GameObject _levelFailWindow;
    private void Awake() 
    {
        Level.LevelComplete += showCompleteWindow;
        Player.PlayerDying += showFaileWindow;
    }

    private void OnDestroy() 
    {
        Level.LevelComplete -= showCompleteWindow;
        Player.PlayerDying -= showFaileWindow;
    }
    private void showCompleteWindow()
    {
        StartCoroutine(IElevelComplete());
        
    }

    private void showFaileWindow()
    {       
        StartCoroutine(IElevelFailed());      
    }

    public void LeaveLevel(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("menu");
    }

    public void ReastartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Boot scene");
    }

    private IEnumerator IElevelComplete()
    {
        _levelCompleteWindow.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
    }

        private IEnumerator IElevelFailed()
    {
        _levelFailWindow.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
    }
}
