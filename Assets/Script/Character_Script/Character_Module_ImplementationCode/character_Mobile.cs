using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_Mobile :MonoBehaviour,IMobile
{
    private Rigidbody2D _rigidbody2D;
    public int mobileSpeen;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is Called Once every 0.02s
    private void FixedUpdate()
    {
        if(!Gamemanager.GameManager.isHurt)
        {
            MobileCode();
        }
    }
    public void MobileCode()
    {
        
        //Handler Mobile
        var horizontals = Input.GetAxisRaw("Horizontal");
        
        _rigidbody2D.velocity = new Vector2(horizontals * mobileSpeen, _rigidbody2D.velocity.y);
                
        //Handler Direction
        if (horizontals != 0)
        {
            transform.localScale = new Vector3(horizontals, 1, 1);
        }
    }
}
