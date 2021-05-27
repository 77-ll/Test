using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager musicManager;

    private void Awake()
    {
        musicManager = this;
    }

    private MusicManager()
    {
        
    }
    /// <summary>
    /// 播放音效方法
    /// </summary>
    /// <param name="audioClip">音效</param>
    /// <param name="TargetPos">音效的位置</param>
    public void AudioPlay(AudioClip audioClip,Transform AudioClipPos)
    {
        AudioSource.PlayClipAtPoint(audioClip,AudioClipPos.position);   
    }
}
