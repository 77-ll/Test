using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Enemies_opossum : MonoBehaviour,Iopossum
{
    private Rigidbody2D _rigidbody2D;

    public Transform leftPos;
    public Transform rightPos;

    public int speen;
    public int AttackDamage;
    public GameObject enemies_FxPrefab;
    
    private bool _isLeft = true;
    private float _left;
    private float _right;

    #region Unity
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        RecordLocation();
    }

    //FixedUpdate is Called Once every 0.02s
    private void FixedUpdate()
    {
        MobileCode();
    }
    #endregion
    
    #region This All Method
    /// <summary>
    /// 触发器
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        if (Gamemanager.GameManager.isfall) return;
        if (other.GetComponent<character_OnDamage>())
        {
            other.GetComponent<character_OnDamage>().OnDamage(AttackDamage,transform);
        }
        else
        {
            Debug.Log("GameObject is not ”OnDamage” Script");
        }
    }

    /// <summary>
    /// This is Record location Code
    /// </summary>
    private void RecordLocation()
    {
        transform.DetachChildren();
        _left = leftPos.position.x;
        _right = rightPos.position.x;
        Destroy(leftPos.gameObject);
        Destroy(rightPos.gameObject);
    }
    
    public void Rebound()
    {
        Destroy(gameObject);
        SpecialEffects.specialEffects.CloneEffect(enemies_FxPrefab,transform);
    }
    /// <summary>
    /// Opossum left and right Mobile
    /// </summary>
    public void MobileCode()
    {
        if (_isLeft)
        {
            _rigidbody2D.velocity = new Vector2(-speen, _rigidbody2D.velocity.y);
            if (!(transform.position.x < _left)) return;
            transform.localScale = new Vector3(-1, 1, 1);
            _isLeft = false;
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(speen, _rigidbody2D.velocity.y);
            if (!(transform.position.x > _right)) return;
            transform.localScale = new Vector3(1, 1, 1);
            _isLeft = true;
        }
    }
    
    #endregion
}
