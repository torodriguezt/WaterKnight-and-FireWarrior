using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public static class GameEvents
{
    public static Action OnStartGameEvent;

    public static Action<int, int> OnGameOverEvent; //total score, is max score?, time, level
    public static Action<int> OnPlayerScoreChangeEvent; //current score
    public static Action<int, int> LevelCompletedEvent; // current health
    public static Action<int> OnLevelProgressEvent; //current level
}