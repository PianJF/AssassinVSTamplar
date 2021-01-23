using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{   
    [SerializeField] float sceneLoadDelay = 4;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            LoadSceneByNameWithDelay("StartScreen", sceneLoadDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadSceneByNameWithDelay(string sceneName, float timeDelay)
    {
        StartCoroutine(WaitThenLoadSceneByName(sceneName, timeDelay));
    }

    IEnumerator WaitThenLoadSceneByName(string sceneName, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        if (sceneName == "nextScene")
        {
            LoadNextScene();
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    public void LoadCurrentScene()
    {   
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptionScreen()
    {
        SceneManager.LoadScene("OptionScreen");
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

}
