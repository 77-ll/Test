using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_SwitchAnimator : MonoBehaviour,ISwitchAnimator
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private static readonly int Run = Animator.StringToHash("run");
    private static readonly int Jump = Animator.StringToHash("jump");
    private static readonly int Fall = Animator.StringToHash("fall");


    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is Called Once every 0.02s
    private void FixedUpdate()
    {
        SwitchAnimator();
        Gamemanager.GameManager.isfall = _animator.GetBool("fall");
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void SwitchAnimator()
    {
        var isGround = Gamemanager.GameManager.isGround;
        var horizontals = Input.GetAxisRaw("Horizontal");
        //Handler Mobile Code.
        _animator.SetBool(Run, Mathf.Abs(horizontals) > 0.1);
        //-------------------------------------------------------------------
        //JumpAnimator and FallAnimator Code.
        if (isGround)
        { 
            _animator.SetBool(Fall,false);
            
            //If you are on the ground and in an injured state, you are judging whether your speed is less than 0.1,
            //and if it is, the injured state has ended.
            if (!Gamemanager.GameManager.isHurt) return; 
            if (Mathf.Abs(_rigidbody2D.velocity.x) < 0.1f) 
            { 
                Gamemanager.GameManager.isHurt = false;
            }
        }
                
        //Execute this code if it is not on the ground
        else if (_rigidbody2D.velocity.y > 0 && Gamemanager.GameManager.isJumpPsDown)
        {
            _animator.SetBool(Jump,true);
        }
        //Execute this code if you are not in the air
        else if (_rigidbody2D.velocity.y < 0)
        {
            _animator.SetBool(Fall,true);
            _animator.SetBool(Jump,false);
        }
    }
}
