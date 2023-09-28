using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;
    [SerializeField] private Transform _cameraPosWin;
    [SerializeField] private Transform _cameraLookPos;
    [SerializeField] private Transform _cameraPositionHelper;
    [SerializeField] private Transform Target;
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
        LookToPlayer();
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnLevelFinish -= LevelEnd;
        GlobalEventManager.OnGameRefresh -= StopRotate;
    }
    public void SetTarget(Transform target)//TESTTTTTTTTTTTTTTT{
    {
        Target = target;
    }
    private void HandleTranslation()
    {
        Vector3 lookDirection = -Target.forward;

        // Оновлюємо позицію цього об'єкта відповідно до напрямку
        Vector3 newPosition = Target.position + lookDirection * Offset.z; // Замість someDistance введіть потрібну вам відстань
        newPosition.y = Offset.y;

        // Застосовуємо інтерполяцію для зменшення різниці між поточною позицією і новою позицією
        _cameraPositionHelper.transform.position = Vector3.Lerp(_cameraPositionHelper.transform.position, newPosition, _translateSpeed * Time.deltaTime);

        //Vector3 Rotation;
        //Rotation.y = Target.rotation.y;
        //transform.rotation = Quaternion.Euler(transform.rotation.x, Rotation.y, transform.rotation.z);
        transform.position = _cameraPositionHelper.position;
        
        //var TargetPosition = Player.transform.position;
        //TargetPosition = Player.transform.forward * -2f;
        //transform.position = Vector3.Lerp(transform.position, TargetPosition + Offset , _translateSpeed * Time.deltaTime);
    }
    private void LookToPlayer()
    {
        Quaternion OriginalRot = transform.rotation;
        transform.LookAt(_cameraLookPos,_cameraLookPos.up);
        Quaternion NewRot = transform.rotation;
        transform.rotation = OriginalRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, _rotationSpeed * Time.deltaTime);
    }
    private void RotateAroundPlayer()
    {
        transform.LookAt(Target, Target.up);
        //transform.position = _cameraPosWin.position;
        transform.RotateAround(Target.position, -Target.up, _speedWinFly * Time.deltaTime);
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