using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移动接口
/// </summary>
    interface IMobile
    {
        /// <summary>
        /// 游戏物体移动的方法
        /// </summary>
        void MobileCode();
    }
/// <summary>
/// 跳跃接口
/// </summary>
    interface IJump
    {
        /// <summary>
        /// 游戏物体跳跃的方法
        /// </summary>
        void JumpCode();
    }
/// <summary>
/// 蹲下接口
/// </summary>
    interface ISquat
    {
        /// <summary>
        /// 游戏物体蹲下的方法
        /// </summary>
        void SquatCode();
    }

    /// <summary>
    /// 切换动画接口
    /// </summary>
    interface ISwitchAnimator
    {
    /// <summary>
    /// 游戏物体切换动画的方法
    /// </summary>
    void SwitchAnimator();
    }
    
    /// <summary>
    /// 拾取接口
    /// </summary>
    interface ICollect
    {
        /// <summary>
        /// 拾取物品的方法
        /// </summary>
        void Collect();
    }


    interface IHandlingPicks
    {
        /// <summary>
        /// 处理拾取物
        /// </summary>
        void HandlingPicks();
    }
    
