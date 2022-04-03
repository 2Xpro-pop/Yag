using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Hidebox : Actionable
{
    public static Vector2 direction;
    [Inject] PlayerHideSystem hideSystem;
    public override void Action()
    {
        if(hideSystem.HideTime>3)
        {
            direction = Random.Range(0,2) == 0 ? Vector2.right : Vector2.left;
            hideSystem.IsHide = true;
        }
    }
}
