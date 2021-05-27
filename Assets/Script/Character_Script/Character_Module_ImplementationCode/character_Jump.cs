using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_Jump : MonoBehaviour,IJump
{
    public float jumpSpeed;
    [Space]
    public LayerMask groundLayerMask;
    public Transform groundTransform;
    
    private float _jumpConut;
    
    private bool _ispsDown,_isGround;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && _jumpConut>0)
        {
            _ispsDown = true;
            Gamemanager.GameManager.isJumpPsDown = _ispsDown;
        }
        _isGround = Physics2D.OverlapCircle(groundTransform.position, 0.1f, groundLayerMask);
        
        //Save to StatusManager 
        Gamemanager.GameManager.isGround = _isGround;
    }

    private void FixedUpdate()
    {
        // if (!Gamemanager.GameManager.isHurt)
        // {
            JumpCode();
        // }
    }

    public void JumpCode()
    {
        //If the number of jumps on the ground is Two
        if (_isGround)
        {
            _jumpConut = 2;
        }

        switch (_ispsDown)
        {
            //Handling the first jump.
            case true when _isGround:
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
                _jumpConut--;
                _ispsDown = false;
                break;
            
            //Handling the two jump.
            case true when _jumpConut>0:
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
                _jumpConut--;
                _ispsDown = false;
                break;
        }
    }
}
