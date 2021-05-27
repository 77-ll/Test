using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamemanager : MonoBehaviour
{
    
    public int gem;                                         //钻石计数器

    public static UIGamemanager UI_Gamemanager;
    
    private void Awake()
    {
        UI_Gamemanager = this;
    }
}
