using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GlobalEventManager 
{
    public static event Action OnLevelStartPlaying;
    
    public static void SendLevelStartPlaying()
    {
        OnLevelStartPlaying?.Invoke();
    }
}
