using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Dreamteck.Splines;

public class Level : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private Transform _finishObject;
    [SerializeField] private Transform _splineFollower;

    private UIController _uIController;
    private ProgressBar _progressBar;
    private PlayerMovement _playerMovement;
    private CameraMovement _cameraMovement;

    private bool levelStartPlayingFlag;

    [Inject]
    public void Construct (UIController uIController,ProgressBar progressBar,PlayerMovement playerMovement,CameraMovement cameraMovement)
    {
        _uIController = uIController;
        _progressBar = progressBar;
        _playerMovement = playerMovement;
        _cameraMovement = cameraMovement;

        _progressBar.ReloadProgressBar(_finishObject.position);
        _playerMovement.SetSpline(_splineFollower.GetComponent<SplineFollower>());
        _cameraMovement.SetTarget(_splineFollower);

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
