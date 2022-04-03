using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Door : Actionable
{
    [Inject] Player player;
    [SerializeField] Door door;

    public override void Action()
    {
        player.transform.position = door.transform.position;
    }
}
