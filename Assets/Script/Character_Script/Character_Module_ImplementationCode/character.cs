using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public int Hp;
    public static character Character;
    
    private void Awake()
    {
        Character = this;
    }

    /// <summary>
    /// 触发器
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemies"))
        {
            if (Gamemanager.GameManager.isfall)
            {
                other.GetComponent<Enemies_opossum>().Rebound();
            }
        }
    }
}
