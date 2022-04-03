using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIActions : MonoBehaviour
{
    [SerializeField] EventTrigger left;
    [SerializeField] EventTrigger right;
    [SerializeField] Button action;

    public event Action LeftButtonPressed;
    public event Action RightButtonPressed;
    public Button ActionButton { get => action; }

    private bool leftPressed;
    private bool rightPressed;

    void Start()
    {
        left.triggers.Add(LeftDown());
        left.triggers.Add(LeftUp());
        right.triggers.Add(RightDown());
        right.triggers.Add(RightUp());
    }

    void Update()
    {
        if(leftPressed)
        {
            LeftButtonPressed?.Invoke();
        }
        else if(rightPressed)
        {
            RightButtonPressed?.Invoke();
        }
    }

    EventTrigger.Entry LeftDown()
    {
        var down = new EventTrigger.Entry();
        down.eventID = EventTriggerType.PointerDown;
        down.callback.AddListener((_) => leftPressed = true);
        return down;
    }

    EventTrigger.Entry LeftUp()
    {
        var up = new EventTrigger.Entry();
        up.eventID = EventTriggerType.PointerUp;
        up.callback.AddListener((_) => leftPressed = false);
        return up;
    }

    EventTrigger.Entry RightDown()
    {
        var down = new EventTrigger.Entry();
        down.eventID = EventTriggerType.PointerDown;
        down.callback.AddListener((_) => rightPressed = true);
        return down;
    }

    EventTrigger.Entry RightUp()
    {
        var up = new EventTrigger.Entry();
        up.eventID = EventTriggerType.PointerUp;
        up.callback.AddListener((_) => rightPressed = false);
        return up;
    }
}
