using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Level[] Levels = new Level[0];

    private GameObject levelObject;

    private int _curentLevel;
    [Inject] private DiContainer diContainer;
    private void Start()
    {
        PlayerPrefs.DeleteAll();
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
        //_instiatedLevel = Instantiate(Levels[_curentLevel - 1].gameObject, Vector3.zero, Quaternion.identity);
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
    }
    private void ReloadLevel()
    {
        Destroy(levelObject);

        CreateLevel();

        GlobalEventManager.SendGameRefresh();
    }
}
