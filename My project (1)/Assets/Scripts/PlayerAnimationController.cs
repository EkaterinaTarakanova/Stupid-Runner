using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void MoveAnimation()
    {
        animator.SetBool("isRunning", true);
    }

    public void JumpAnimation(float speed)
    {
        animator.SetBool("isRunning", false);
        animator.SetFloat("velocityY", speed);
    }
}
