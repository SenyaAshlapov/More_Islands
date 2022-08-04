using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField]private GameObject _menu;
    [SerializeField]private GameObject _openMenuButton;

    [SerializeField]private GameObject _gamePlayUI;

    [SerializeField]private GameObject _options;
    private bool _isOptionsShow = false;
    public void MenuEnable()
    {
        Time.timeScale = 0f;

        _menu.SetActive(true);
        _openMenuButton.SetActive(false);
        _gamePlayUI.SetActive(false);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1.0f;

        _menu.SetActive(false);
        _openMenuButton.SetActive(true);
        _gamePlayUI.SetActive(true);
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
    public void ShowOptions()
    {
        _isOptionsShow = !_isOptionsShow;
        _options.SetActive(_isOptionsShow);
    }


}
