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
    private float score;
    private int nextLevel;
    private float time;
    private int points;
    private string userName;

    private float  finalPoints;
    private Rank rank;

    public float GetScore()
    {
        return score; 
    }

    public int GetPoints()
    {
        return points;
    }
    public int GetNextLevel()
    {
        return nextLevel;
    }

    public float GetTime()
    {
        return time;
    }
    public string GetUserName()
    {
        return userName;
    }
    public float GetFinalPoints()
    {
        return finalPoints;
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
        points++;
    }

    public void SetName(string userName)
    {
        this.userName = userName;
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
        Debug.Log($"A jugar nivel {nextLevel}");
        if (nextLevel == 0)
        {
            HandleLevel1();
        }
        if (nextLevel == 1)
        {
            HandleLevel2();
        }
        if (nextLevel == 2)
        {
            HandleLevel3();
        }
        if (nextLevel == 3)
        {
            HandleLevel4();
        }
        if (nextLevel == 4)
        {
            HandleRanking();
        }
    }
    
    public void ContinueLevel()
    {
        GameEvents.OnLevelProgressEvent?.Invoke(nextLevel);
        RetryLevel();
    }

    public void LevelCompletedScreen()
    {
        time = Time.time - time;
        time = (float)Math.Round(time, 3);
        HandlePassLevel();
    }

    private void HandlePassLevel()
    {
        Debug.Log("Loading Level Completed...");
        StartCoroutine(LoadGameplayAsyncScene("LevelPassed"));
    }
    public void GameOver()
    {
        time = Time.time - time;
        Debug.Log("Game over");
        StartCoroutine(LoadGameplayAsyncScene("GameOver"));
        //TODO: Music end
    }

    private void HandleMenu()
    {
        points = 0;
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
        time = Time.time;
        points = 0;
        StartCoroutine(LoadGameplayAsyncScene("Level1"));
    }

    private void HandleLevel2()
    {
        time = Time.time;
        points = 0;
        StartCoroutine(LoadGameplayAsyncScene("Level2"));
    }

    private void HandleLevel3()
    {
        time = Time.time;
        points = 0;
        StartCoroutine(LoadGameplayAsyncScene("Level3"));
    }

    private void HandleLevel4()
    {
        time = Time.time;
        points = 0;
        StartCoroutine(LoadGameplayAsyncScene("Level4"));
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
        if (level == 4)
        {
            nextLevel = 1;
        }
        else
        {
            nextLevel += 1;
        }
    }

    public void Scores(float levelPoints)
    {
        finalPoints += levelPoints;
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
