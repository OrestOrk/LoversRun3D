using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _boyAnimator;
    [SerializeField] private Animator _girlAnimator;
    
    public void SetAnimationState(AnimationState state)
    {
        switch (state)
        {
            case AnimationState.Idle:
                _boyAnimator.SetTrigger("Idle");
                _girlAnimator.SetTrigger("Idle");
                break;
            case AnimationState.Run:
                _boyAnimator.SetTrigger("Run");
                _girlAnimator.SetTrigger("Run");
                break;
            case AnimationState.Dance:
                _boyAnimator.SetTrigger("Dance");
                _girlAnimator.SetTrigger("Dance");
                break;
            default:
                break;
        }
    }
}
