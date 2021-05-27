using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar_script : MonoBehaviour
{
    public Image BufferBloodVolume;                          //缓冲血量图片 
    public Image BloodVolume;                                //血量图片
    public Text healthBarNumber;                             //血量值
    public int number;
    
    //FixedUpdate is Called Once every 0.02s
    private void FixedUpdate()
    {
        ProcessBloodVolume();   
    }

    /// <summary>
    /// 处理血量和缓冲血量的方法
    /// </summary>
    private void ProcessBloodVolume()
    {
        if (BufferBloodVolume.fillAmount > BloodVolume.fillAmount)
        {
            BufferBloodVolume.fillAmount -= 0.003f;
        }
        else
        {
            BufferBloodVolume.fillAmount = BloodVolume.fillAmount;
        }
        
        healthBarNumber.text = character.Character.Hp + "/" + number;
        BloodVolume.fillAmount =character.Character.Hp/(float)number;
    }
}
