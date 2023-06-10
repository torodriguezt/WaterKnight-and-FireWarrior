using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public static class GameEvents
{
    public static Action<int> OnLevelProgressEvent; //current level
}
