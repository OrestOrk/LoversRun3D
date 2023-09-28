using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HandleAnalitycs : MonoBehaviour
{
    [Inject]private MoneySystem _moneySystem;

    private int _virtualLevel;

    private const string _savedLevelVirtual = "VirtualLevelComplette";

    private void Start()
    {
        if (PlayerPrefs.HasKey(_savedLevelVirtual))
        {
            _virtualLevel = PlayerPrefs.GetInt(_savedLevelVirtual) + 1;
        }
        else
        {
            _virtualLevel = 1;
        }
        GlobalEventManager.OnLevelStartPlaying += SendLelelStartAnalitycs;
        GlobalEventManager.OnLevelFinish += SendAnalitycsFinish;
    }
    private void SendAnalitycsFinish(bool LevelResult)
   {
        //TinySauce.OnGameFinished(LevelResult,_moneySystem.GetMoney() , _virtualLevel.ToString());
   }
    public void SendLelelStartAnalitycs()
    {
       // TinySauce.OnGameStarted(_virtualLevel.ToString());
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt(_savedLevelVirtual, _virtualLevel);
        _virtualLevel++;
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnLevelStartPlaying -= SendLelelStartAnalitycs;
        GlobalEventManager.OnLevelFinish -= SendAnalitycsFinish;
    }
}
