using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private Transform _boyTransform;
    [SerializeField] private Transform _girlTransform;

    private float _speedMovement;
    private float _speedRotate;

    private bool moveFlag;

    void Start()
    {
        GlobalEventManager.OnLevelStartPlaying += StartMove;

        _speedMovement = 10f;
        _speedRotate = 500f;
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
    private void OnDestroy()
    {
        GlobalEventManager.OnLevelStartPlaying -= StartMove;
    }
}
