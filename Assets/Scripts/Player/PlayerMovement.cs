using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;

    [SerializeField] private Transform _boyTransform;
    [SerializeField] private Transform _girlTransform;
    [SerializeField] private float _speedMovement;
    [SerializeField] private float _speedFollower;

    private SplineFollower _splineFollowerComponent;

    private Transform _splineFolower;

    private Vector3 _startPosition;

    private float _speedRotate;

    private bool moveFlag;
    private bool controlabeFlag;

    void Start()
    {
        GlobalEventManager.OnLevelStartPlaying += StartMove;
        GlobalEventManager.OnLevelFinish += LevelEnd;
        GlobalEventManager.OnGameRefresh += RefreshTransform;

        _speedRotate = 500f;

        _startPosition = transform.position;

        controlabeFlag = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (controlabeFlag)
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
        }
        if (moveFlag)
        {
            Move();
        }
    }
    public void SetSpline(SplineFollower Follower)
    {
        _splineFolower = Follower.transform;
        _splineFollowerComponent = Follower;
        _splineFollowerComponent.followSpeed = _speedFollower;
    }
    private void StartMove()
    {
        _splineFollowerComponent.follow = true;

        moveFlag = true;

        _playerAnimation.SetAnimationState(AnimationState.Run);
    }
    private void LevelEnd(bool Win)
    {
        controlabeFlag = false;//Disable Player Controll

        if (Win)
        {
            StopMove();
            _playerAnimation.SetAnimationState(AnimationState.Dance);
        }
        else
        {
            StopMove();
            _playerAnimation.SetAnimationState(AnimationState.Idle);
        }
    }
    private void StopMove()
    {
        _splineFollowerComponent.follow = false;

        moveFlag = false;
    }
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, _splineFolower.position, _speedMovement * Time.deltaTime);
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
        controlabeFlag = true;//Enabled Player Controll

        transform.position = _startPosition;//Teleport To startPos
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
