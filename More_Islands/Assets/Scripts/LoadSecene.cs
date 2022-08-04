using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSecene : MonoBehaviour
{
    [SerializeField]private List<string> _scenes = new List<string>();
    void Start()
    {
        loadRandomScene();
    }

    private void loadRandomScene(){
        int count = _scenes.Count;

        StartCoroutine(LoadAsyncScene(_scenes[Random.Range(0, count)]));
    }

    private IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    
}
