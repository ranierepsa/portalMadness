using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PortalTriggeredEvent", menuName = "Portal Triggered Event")]
public class PortalTriggeredEvent : ScriptableObject
{
    public delegate void OnPortalTriggered(Vector2 destLocation, bool isPath);
    private OnPortalTriggered onPortalTriggered;

    public void Trigger(Vector2 destLocation, bool isPath)
    {
        onPortalTriggered?.Invoke(destLocation, isPath);
    }

    public void Subscribe(OnPortalTriggered func)
    {
        onPortalTriggered += func;
    }

    public void Unsubscribe(OnPortalTriggered func)
    {
        onPortalTriggered -= func;
    }
}
