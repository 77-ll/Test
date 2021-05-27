using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gem_script : MonoBehaviour,IHandlingPicks
{
    
    public Text          gemText;                           //钻石数字的Text
    public GameObject    food_FxPrefab;                     //获得buff要克隆一个特效
    public AudioClip gemAudioClip;
    private void FixedUpdate()
    {
        gemText.text = UIGamemanager.UI_Gamemanager.gem +"/"+ "3";
    }
    
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
    
    public void HandlingPicks()
    {
        //If the collision is a gem, execute the following code
        Destroy(gameObject);
        UIGamemanager.UI_Gamemanager.gem += 1;
        SpecialEffects.specialEffects.CloneEffect(food_FxPrefab,transform);
        MusicManager.musicManager.AudioPlay(gemAudioClip,transform);
        
    }
}
