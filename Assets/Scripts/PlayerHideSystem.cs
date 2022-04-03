using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHideSystem
{
    const float MaxHideTime = 30f;
    const float HideTimeReturnFactor = 0.2f;
    public bool IsHide { get; set; } = false;
    public float HideTime { get; private set; } = MaxHideTime;

    public void Update()
    {
        if(IsHide && HideTime >0)
        {
            HideTime -= Time.deltaTime;
        }
        else if(HideTime < MaxHideTime)
        {
            IsHide = false; 
            HideTime += Time.deltaTime*HideTimeReturnFactor;
        }

        if( HideTime < 0)
        {
            IsHide = true;
        }

        if(HideTime > MaxHideTime)
        {
            HideTime = MaxHideTime;
        }
    }
}
