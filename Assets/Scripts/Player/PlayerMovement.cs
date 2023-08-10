using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private Transform _boyTransform;
    [SerializeField] private Transform _girlTransform;

    private Vector3 _startPosition;

    private float _speedMovement;
    private float _speedRotate;

    private bool moveFlag;

    void Start()
    {
        GlobalEventManager.OnLevelStartPlaying += StartMove;
        GlobalEventManager.OnLevelFinish += LevelEnd;
        GlobalEventManager.OnGameRefresh += RefreshTransform;

        _speedMovement = 10f;
        _speedRotate = 500f;

        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (SwipeController.swipeLeft)
        {
            RotateLeft();

            RotateCharsForward();
        }
        else if (SwipeController.swipeRight)
        {
            RotateRight();

            RotateCharsForward();
        }
        if (moveFlag)
        {
            Move();
        }
    }

    private void StartMove()
    {
        moveFlag = true;

        _playerAnimation.SetAnimationState(AnimationState.Run);
    }
    private void LevelEnd(bool Win)
    {
        if (Win)
        {
            StopMove();
            _playerAnimation.SetAnimationState(AnimationState.Dance);
        }
    }
    private void StopMove()
    {
        moveFlag = false;
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * _speedMovement * Time.deltaTime, Space.World);
    }
    private void RotateLeft()
    {
        transform.Rotate(0f, _speedRotate * Time.deltaTime, 0f);
    }
    private void RotateRight()
    {
        transform.Rotate(0f, -_speedRotate * Time.deltaTime, 0f);
    }
    private void RotateCharsForward()
    {
        _boyTransform.transform.LookAt(_boyTransform.position + Vector3.forward);
        _girlTransform.transform.LookAt(_girlTransform.position + Vector3.forward);
    }
    private void RefreshTransform()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        _playerAnimation.SetAnimationState(AnimationState.Idle);
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnLevelStartPlaying -= StartMove;
        GlobalEventManager.OnLevelFinish -= LevelEnd;
        GlobalEventManager.OnGameRefresh -= RefreshTransform;
    }
}
