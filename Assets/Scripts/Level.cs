using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private Transform _finishObject;

    private UIController _uIController;
    private ProgressBar _progressBar;

    private bool levelStartPlayingFlag;

    [Inject]
    public void Construct (UIController uIController,ProgressBar progressBar)
    {
        _uIController = uIController;
        _progressBar = progressBar;

        _progressBar.ReloadProgressBar(_finishObject.position);

        Debug.Log("Zenjectwork");

    }
    private void Start()
    {
        Debug.Log("UIContr" + _uIController);
        _uIController.UpdateLevelText(_level);
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
