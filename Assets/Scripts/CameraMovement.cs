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

    private bool _win;


    private void Start()
    {
        GlobalEventManager.OnLevelFinish += LevelEnd;
    }
    private void LateUpdate()
    {
        if (_win)
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
            _win = true;
            //transform.position = _cameraPosWin.position;
        }
    }
}