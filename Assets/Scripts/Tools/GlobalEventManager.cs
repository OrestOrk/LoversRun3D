using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GlobalEventManager 
{
    public static event Action OnLevelStartPlaying;

    public static event Action OnGameRefresh;//refresh Player Positions And UiPanels

    public static event Action<bool> OnLevelFinish;
    public static void SendLevelStartPlaying()
    {
        OnLevelStartPlaying?.Invoke();
    }
    public static void SendLevelFinsih(bool winFlag)
    {
        OnLevelFinish?.Invoke(winFlag);
    }
    public static void SendGameRefresh()
    {
        OnGameRefresh?.Invoke();
    }
}
