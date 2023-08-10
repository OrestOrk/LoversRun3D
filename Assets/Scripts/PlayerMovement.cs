using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speedMovement;
    private bool moveFlag;

    void Start()
    {
        _speedMovement = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveFlag)
        {
            transform.Translate(Vector3.forward * _speedMovement * Time.deltaTime);
        }
    }
    private void StartMove()
    {
        moveFlag = true;
    }
}
