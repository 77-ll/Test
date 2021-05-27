using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager GameManager;
    [Header("游戏人物状态")]
    public bool isGround;                   //是否在地面
    public bool isHurt;                     //是否是受伤状态
    public bool isfall;                     //是否是下落状态
    public bool isJumpPsDown;               //是否按下跳跃键

    private void Awake()
    {
        GameManager = this;
    }
    
}
