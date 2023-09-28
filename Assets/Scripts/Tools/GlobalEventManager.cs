using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GlobalEventManager 
{
    public static event Action OnLevelStartPlaying;

    public static event Action OnGameRefresh;//refresh Player Positions And UiPanels

    public static event Action<bool> OnLevelFinish;

    public static event Action OnCoinPickUp;

    private static bool LevelEnd;
    public static void SendLevelStartPlaying()
    {
        OnLevelStartPlaying?.Invoke();
    }
    public static void SendLevelFinsih(bool winFlag)
    {
        if(LevelEnd == false)
        {
            OnLevelFinish?.Invoke(winFlag);
            LevelEnd = true;
        }
    }
    public static void SendGameRefresh()
    {
        LevelEnd = false;
        OnGameRefresh?.Invoke();
    }
    public static  void SendCoinPickUp()
    {
        OnCoinPickUp?.Invoke();
    }
}
