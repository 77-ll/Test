using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour
{
    public static SpecialEffects specialEffects;
    private void Awake()
    {
        specialEffects = this;
    }
    /// <summary>
    /// 克隆特效的方法
    /// </summary>
    /// <param name="fx_Prefab"></param>
    public void CloneEffect(GameObject fx_Prefab,Transform Objecttransform)
    {
        var cloneeffect = Instantiate(fx_Prefab, Objecttransform.position, Quaternion.identity.normalized);
        Destroy(cloneeffect,0.4f);
    }

}
