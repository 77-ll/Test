using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cherry_script : MonoBehaviour,IHandlingPicks
{
    public GameObject    food_FxPrefab;                              //获得buff要克隆一个特效
    
    /// <summary>
    /// 触发器
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HandlingPicks();
        }
    }

    /// <summary>
    /// 处理樱桃被拾取后的操作
    /// </summary>
    public void HandlingPicks()
    {
        //If the collision is a cherry, execute the following code
        Destroy(gameObject);
        character.Character.Hp += 1;
        SpecialEffects.specialEffects.CloneEffect(food_FxPrefab,transform);
    }
}
