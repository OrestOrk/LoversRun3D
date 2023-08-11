using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _progressImage;

    [Inject] private PlayerMovement _playerMovement;

    private float _startZPos = 0;

    private Vector3 _finishPosition;

    private void Update()
    {
        UpdateLevelProgress();
    }
    public void ReloadProgressBar(Vector3 EndPosition)
    {
        _finishPosition = EndPosition;
    }

    private float CalculateProgress()
    {
        float PlayerZPos = _playerMovement.transform.position.z;
        float Progress = Mathf.InverseLerp(_startZPos, _finishPosition.z, PlayerZPos);
        return Progress;
    }
    private void UpdateLevelProgress()
    {
        _progressImage.fillAmount = CalculateProgress();
        Debug.Log("progres" + CalculateProgress());
    }
}
