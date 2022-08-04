using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private readonly string SCROE_KEY = "score";
    private readonly string BEST_SCROE_KEY = "best score";
    private readonly string FIRS_GAME_KEY = "first game";


    public void LoadSaves()
    {
        if(!PlayerPrefs.HasKey(FIRS_GAME_KEY))
        {
            PlayerPrefs.SetInt(SCROE_KEY,0);
            PlayerPrefs.SetInt(BEST_SCROE_KEY,0);
            PlayerPrefs.SetInt(FIRS_GAME_KEY,1);
        }
    }

    public int LoadScore()
    {
        int score = PlayerPrefs.GetInt(SCROE_KEY);
        return score;
    }

    public void SaveScore(int newScore)
    {
        PlayerPrefs.SetInt(SCROE_KEY,newScore);
    }

    public int LoadBestScore()
    {
        int bestScore = PlayerPrefs.GetInt(BEST_SCROE_KEY);
        return bestScore;
    }

    public void SaveBestScore(int newBestScore)
    {
        PlayerPrefs.SetInt(BEST_SCROE_KEY,newBestScore);
    }

    public bool LoadFirstGame()
    {
        int isFirst = PlayerPrefs.GetInt(FIRS_GAME_KEY);
        if(isFirst == 1) return true;
        else return false;
    }

    public void SaveIsFirst(bool newIsFirst)
    {
        if(newIsFirst == true) PlayerPrefs.SetInt(FIRS_GAME_KEY,1);
        else PlayerPrefs.SetInt(FIRS_GAME_KEY,0);       
    }

    public void RemoveSaves()
    {
        PlayerPrefs.SetInt(SCROE_KEY,0);
        PlayerPrefs.SetInt(FIRS_GAME_KEY,1);
    }

    public void RemoveAllSaves()
    {
        PlayerPrefs.SetInt(SCROE_KEY,0);
        PlayerPrefs.SetInt(FIRS_GAME_KEY,1);
        PlayerPrefs.SetInt(BEST_SCROE_KEY,0);

    }
    

}
