using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemies_frog : MonoBehaviour,Ifrog
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    public Transform leftPos;
    public Transform rightPos;
    public LayerMask groundLayerMask;
    public Transform groundTransform;
    
    public float speen,jump;
    
    private bool isGround;
    private bool isLeft = true;
    private float left;
    private float right;
    
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        recordLocation();
    }

    //FixedUpdate is Called Once every 0.02s
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundTransform.position, 0.1f, groundLayerMask);
        SwitchAnimator();
    }

    public void MobileCode()
    {
        //If the direction is on the left at this time, execute the following code
        if (isLeft)
        {
            if(isGround)
            {
                _rigidbody2D.velocity = new Vector2(-speen, jump);
                if (transform.position.x < left)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    isLeft = false;
                }
            }
        }
        
        //Otherwise the direction is on the right at this time, execute the following code
        else
        {
            if(isGround)
            {
                _rigidbody2D.velocity = new Vector2(speen, jump);
                if (transform.position.x > right)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    isLeft = true;
                }
            }
        }
    }

    public virtual void SwitchAnimator()
    {
        if (isGround)
        {
            _animator.SetBool("Enemies_fall",false);
            
        }
        else if (_rigidbody2D.velocity.y > 0 && !isGround)
        {
            _animator.SetBool("Enemies_jump", true);
            
        }else if (_rigidbody2D.velocity.y < 0)
        {
            _animator.SetBool("Enemies_jump", false);
            _animator.SetBool("Enemies_fall",true);
        }
    }

    /// <summary>
    /// This is Record location Code
    /// </summary>
    private void recordLocation()
    {
        left = leftPos.position.x;
        right = rightPos.position.x;
        Destroy(leftPos.gameObject);
        Destroy(rightPos.gameObject);
    }
}
