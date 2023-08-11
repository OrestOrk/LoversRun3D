using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;
    [SerializeField] private Transform TargetCameraPos;
    [SerializeField] private Transform _cameraPosWin;
    [SerializeField] private Transform Player;
    [SerializeField] private float _translateSpeed, _rotationSpeed;
    [Range(0, 50f)]
    [SerializeField] private float _speedWinFly;

    private bool rotateFlag;
    private Vector3 _startPosition;
    private Quaternion _startRotation;


    private void Start()
    {
        GlobalEventManager.OnLevelFinish += LevelEnd;
        GlobalEventManager.OnGameRefresh += StopRotate;

        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }
    private void LateUpdate()
    {
        if (rotateFlag)
        {
            RotateAroundPlayer();
            return;
        }
        HandleTranslation();
        //LookToPlayer();
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnLevelFinish -= LevelEnd;
        GlobalEventManager.OnGameRefresh -= StopRotate;
    }
    private void HandleTranslation()
    {
        //var TargetPosition = TargetCameraPos.TransformPoint(Offset);
        var TargetPosition = Player.transform.position;
        transform.position = Vector3.Lerp(transform.position, TargetPosition + Offset , _translateSpeed * Time.deltaTime);
    }
    private void LookToPlayer()
    {
        Quaternion OriginalRot = transform.rotation;
        transform.LookAt(Player, Player.up);
        Quaternion NewRot = transform.rotation;
        transform.rotation = OriginalRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, _rotationSpeed * Time.deltaTime);
    }
    private void RotateAroundPlayer()
    {
        transform.LookAt(Player, Player.up);
        //transform.position = _cameraPosWin.position;
        transform.RotateAround(Player.position, -Player.up, _speedWinFly * Time.deltaTime);
    }
    private void LevelEnd(bool Win) 
    {
        if (Win)
        {
            rotateFlag = true;
            //transform.position = _cameraPosWin.position;
        }
    }
    private void StopRotate()
    {
        rotateFlag = false;

        RefreshTransform();
    }
    private void RefreshTransform()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }
}