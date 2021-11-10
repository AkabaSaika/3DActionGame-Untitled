using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public static PlayerAnimationController _instance;

    private Animator anim;
    private int walkState;
    private int runState;
    private int attackState;
    private bool isWalking = false;
    private bool isRunning = false;


    private void Awake()
    {
        _instance = this;
        walkState = Animator.StringToHash("isWalking");
        runState = Animator.StringToHash("isRunning");
        attackState = Animator.StringToHash("isAttacking");
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        AnimationController();
    }

    void AnimationController()
    {
        if (isRunning)
        {
            anim.SetBool(runState, true);
            anim.SetBool(walkState, false);
        }
        else if (isWalking)
        {
            anim.SetBool(walkState, true);
            anim.SetBool(runState, false);
        }
        else
        {
            anim.SetBool(walkState, false);
            anim.SetBool(runState, false);
        }

    }

    public void SetWalkState(bool walkState)
    {
        isWalking = walkState;
    }

    public void SetRunState(bool runState)
    {
        isRunning = runState;
    }
}
