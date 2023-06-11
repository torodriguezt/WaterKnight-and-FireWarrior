using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Gameplay
    private float _score = 0;
    private int _level = 0;
    private float _time = 0;
    private int _points = 0;
    private float _total=0;

    public float getScore()
    {
        return _score; 
    }

    public int getPoints()
    {
        return _points;
    }
    public int getLevel()
    {
        return _level;
    }

    public float getTime()
    {
        return _time;
    }

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

    public void AddPoints()
    {
        _points++;
    }

    public void increaseScore()
    {
        _score += _points;
        _time = _time - 30;
        _total += _time;
    }

    public void finalScore()
    {
        _score=(_score*10) - _total;
    }
    public void StartGame()
    {
        HandleLevel1();

    }

    public void Instruction()
    {
        HandleInstruction();
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
        if (_level == 4)
        {
            finalScore();
            HandleRanking();
        }
    }

    public void continueLevel()
    {
        GameEvents.OnLevelProgressEvent?.Invoke(_level);
        retryLevel();
    }

    public void levelCompletedScreen()
    {
        _time = Time.time - _time;
        HandlePassLevel();
    }

    public void HandlePassLevel()
    {
        Debug.Log("Loading Level Completed...");
        StartCoroutine(LoadGameplayAsyncScene("LevelPassed"));
    }
    public void GameOver()
    {
        _time = Time.time - _time;
        Debug.Log("Game over");
        StartCoroutine(LoadGameplayAsyncScene("GameOver"));
        //TODO: Music end
    }

    void HandleMenu()
    {
        _points = 0;
        Debug.Log("Loading Menu...");
        StartCoroutine(LoadGameplayAsyncScene("MainMenu"));
        //AudioManager.Instance.PlayMusic(AudioMusicType.Menu);
    }

    void HandleInstruction()
    {
        Debug.Log("Loading instruction...");
        StartCoroutine(LoadGameplayAsyncScene("instructions"));
    }

    void HandleLevel1()
    {
        _time = Time.time;
        _points = 0;
        StartCoroutine(LoadGameplayAsyncScene("AlejoMapa2"));
    }

    void HandleLevel2()
    {
        increaseScore();
        _time = Time.time;
        _points = 0;
        StartCoroutine(LoadGameplayAsyncScene("CaroMapa"));
    }

    void HandleLevel3()
    {
        increaseScore();
        _time = Time.time;
        _points = 0;
        StartCoroutine(LoadGameplayAsyncScene("CataMapa"));
    }

    void HandleLevel4()
    {
        increaseScore();
        _time = Time.time;
        _points = 0;
        StartCoroutine(LoadGameplayAsyncScene("TomasMapa2"));
    }

    void HandleRanking()
    { 
        increaseScore();
        StartCoroutine(LoadGameplayAsyncScene("GameCompleted"));
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
        //AudioManager.Instance.PlayMusic(AudioMusicType.Gameplay);
    }

    void OnLevelProgress(int level)
    {
        _level = level + 1;
    }

}
