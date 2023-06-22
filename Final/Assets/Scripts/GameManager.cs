using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    // Gameplay
    private float _score;
    private int _level;
    private float _time;
    private int _points;
    
    private float  final_points;
    private Rank rank;

    public float getScore()
    {
        return _score; 
    }

    public int GetPoints()
    {
        return _points;
    }
    public int GetLevel()
    {
        return _level;
    }

    public float GetTime()
    {
        return _time;
    }

    public float GetFinalPoints()
    {
        return final_points;
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

    public void RetryLevel()
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
            HandleRanking();
        }
    }

    public void ContinueLevel()
    {
        GameEvents.OnLevelProgressEvent?.Invoke(_level);
        RetryLevel();
    }

    public void LevelCompletedScreen()
    {
        _time = Time.time - _time;
        HandlePassLevel();
    }

    private void HandlePassLevel()
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

    private void HandleMenu()
    {
        _points = 0;
        Debug.Log("Loading Menu...");
        StartCoroutine(LoadGameplayAsyncScene("MainMenu"));
        //AudioManager.Instance.PlayMusic(AudioMusicType.Menu);
    }

    private void HandleInstruction()
    {
        Debug.Log("Loading instruction...");
        StartCoroutine(LoadGameplayAsyncScene("instructions"));
    }

    private void HandleLevel1()
    {
        _time = Time.time;
        _points = 0;
        StartCoroutine(LoadGameplayAsyncScene("AlejoMapa2"));
    }

    private void HandleLevel2()
    {
        _time = Time.time;
        _points = 0;
        StartCoroutine(LoadGameplayAsyncScene("CaroMapa"));
    }

    private void HandleLevel3()
    {
        _time = Time.time;
        _points = 0;
        StartCoroutine(LoadGameplayAsyncScene("CataMapa"));
    }

    private void HandleLevel4()
    {
        _time = Time.time;
        _points = 0;
        StartCoroutine(LoadGameplayAsyncScene("TomasMapa2"));
    }

    private void HandleRanking()
    {
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

    private void OnLevelProgress(int level)
    {
        if (_level == 4)
        {
            _level = 1;
        }
        else
        {
            _level = level + 1;
        }
    }

    public void Scores(float levelPoints)
    {
        final_points += levelPoints;
    }

    public Rank GetRank()
    {
        return rank;
    }

    [ContextMenu("SaveRank")]
    public void SaveRank()
    {
        string rankData = JsonUtility.ToJson(rank, true);
        Debug.Log(rankData);
        PlayerPrefs.SetString("Rank", rankData);
    }
    
    [ContextMenu("LoadRank")]
    public void LoadRank(float score, string name)
    {
        string rankData = PlayerPrefs.GetString("Rank");
        rank = JsonUtility.FromJson<Rank>(rankData);
        if (rank == null)
        {
            rank = new Rank();
        }

        rank.AddUser(score, name);
        SaveRank();
    }

}

[Serializable]
public class Rank
{
    public List<RankUser> users;

    public Rank()
    {
        users = new List<RankUser>();
    }

    public void AddUser(float score, string name)
    {
        RankUser user = new RankUser(score, name);
        users.Add(user);
    }
}

[Serializable]
public class RankUser
{
    public float score;
    public string name;

    public RankUser(float score, string name)
    {
        this.score = score;
        this.name = name;
    }
}
