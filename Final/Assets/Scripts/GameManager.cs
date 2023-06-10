using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Gameplay
    private int _score = 0;
    private int _level = 0;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        MainMenu();
        GameEvents.OnLevelProgressEvent += OnLevelProgress;
    }

    public void StartGame()
    {
        HandleLevel1();

    }

    public void MainMenu()
    {
        HandleMenu();
    }

    public void retryLevel()
    {
        if (_level == 0)
        {
            HandleLevel1();
        }
        if (_level == 1)
        {
            HandleLevel2();
        }
        if (_level == 2)
        {
            HandleLevel3();
        }
        if (_level == 3)
        {
            HandleLevel4();
        }
    }

    public void continueLevel()
    {
        GameEvents.OnLevelProgressEvent?.Invoke(_level);
        retryLevel();
    }

    public void levelCompletedScreen()
    {
        GameEvents.LevelCompletedEvent?.Invoke(_score, _level);
        HandlePassLevel();
    }

    public void HandlePassLevel()
    {
        Debug.Log("Loading Level Completed...");
        SceneManager.LoadScene("LevelPassed");
    }
    public void GameOver()
    {
        Debug.Log("Game over");
        GameEvents.OnGameOverEvent?.Invoke(_score, _level);
        SceneManager.LoadScene("GameOver");
        //TODO: Music end
    }

    void HandleMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("MainMenu");
        //AudioManager.Instance.PlayMusic(AudioMusicType.Menu);
    }

    void HandleLevel1()
    {
        Debug.Log("Loading Gameplay...");

        _score = 0;

        StartCoroutine(LoadGameplayAsyncScene("AlejoMapa2"));
    }

    void HandleLevel2()
    {
        Debug.Log("Loading Gameplay...");

        _score = 0;

        StartCoroutine(LoadGameplayAsyncScene("CaroMapa"));
    }

    void HandleLevel3()
    {
        Debug.Log("Loading Gameplay...");

        _score = 0;

        StartCoroutine(LoadGameplayAsyncScene("CataMapa"));
    }

    void HandleLevel4()
    {
        Debug.Log("Loading Gameplay...");

        _score = 0;

        StartCoroutine(LoadGameplayAsyncScene("TomasMapa2"));
    }

    IEnumerator LoadGameplayAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        //_time = Time.time;
        // if(GameEvents.OnStartGameEvent != null)
        //     GameEvents.OnStartGameEvent.Invoke();
        GameEvents.OnStartGameEvent?.Invoke();
        //AudioManager.Instance.PlayMusic(AudioMusicType.Gameplay);
    }

    void OnLevelProgress(int level)
    {
        _level = level + 1;
    }

}
