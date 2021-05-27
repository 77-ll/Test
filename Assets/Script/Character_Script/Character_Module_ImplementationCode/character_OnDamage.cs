using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class character_OnDamage : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// 处理受伤的方法
    /// </summary>
    /// <param name="damage">伤害值</param>
    /// <param name="collider2D">触发对象</param>
    public void OnDamage(int damage,Transform Enemiestransform)
    {
        //给状态类发送消息
        Gamemanager.GameManager.isHurt = true;
        character.Character.Hp -= damage;
        //向被撞方向击飞10像素
        var velocity = _rigidbody2D.velocity;
        velocity = transform.position.x < Enemiestransform.transform.position.x ? new Vector2(-10, velocity.y) : new Vector2(10, velocity.y);
        _rigidbody2D.velocity = velocity;
    }
}

