using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] private int _level;

    private UIController uIController;
    private bool levelStartPlayingFlag;

    [Inject]
    public void Construct (UIController _uIController)
    {
        uIController = _uIController;
        Debug.Log("ConstrucktLevel");
    }
    private void Start()
    {
        uIController.UpdateLevelText(_level);
        Debug.Log("StartLevel");
    }

    private void Update()
    {
        if (!levelStartPlayingFlag)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GlobalEventManager.SendLevelStartPlaying();

                levelStartPlayingFlag = true;
            }
        }
    }   
}
