using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Dreamteck.Splines;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Level[] Levels = new Level[0];

    public HandleAnalitycs _handleAnalitycs;

    private GameObject levelObject;

    private int _curentLevel;
    [Inject] private DiContainer diContainer;
    private void Start()
    {
        if (PlayerPrefs.HasKey("LevelComplette"))
        {
            _curentLevel = PlayerPrefs.GetInt("LevelComplette") + 1;
        }
        else
        {
            _curentLevel = 1;
        }
        CreateLevel();
    }
    public void NextLevelButtonClick()
    {
        Invoke(nameof(NextLevel), 1.5f);
    }
    public void ReloadLevelButtonClick()
    {
        Invoke(nameof(ReloadLevel), 1.5f);
    }
    private void CreateLevel()
    {
        if(_curentLevel > Levels.Length)///POVTOR RIVNIV Cykle
        {
            _curentLevel = 1;
        }
        Debug.Log(_curentLevel);
        levelObject = diContainer.InstantiatePrefab(Levels[_curentLevel - 1].gameObject);
        Level level = levelObject.GetComponent<Level>();
    }
  
    private void NextLevel()
    {
        Destroy(levelObject);

        PlayerPrefs.SetInt("LevelComplette", _curentLevel);
        _curentLevel++;
        CreateLevel();

        GlobalEventManager.SendGameRefresh();

        _handleAnalitycs.NextLevel(); ///ANAlitik level+;
    }
    private void ReloadLevel()
    {
        Destroy(levelObject);

        CreateLevel();

        GlobalEventManager.SendGameRefresh();
    }
}
