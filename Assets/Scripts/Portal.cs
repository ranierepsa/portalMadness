using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] PortalTriggeredEvent portalTriggerEvent;

    public Minimap Destination { get; set; }
    public bool IsFinal { get; set; } = false;
    public bool IsPath { get; set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsFinal)
        {
            TeleportCollisorToDestination();
        } else
        {
            FindObjectOfType<SceneLoader>().LoadGameOver();
        }
    }

    private void TeleportCollisorToDestination()
    {
        portalTriggerEvent.Trigger(Destination.SpawnLocation, IsPath);
    }
}
