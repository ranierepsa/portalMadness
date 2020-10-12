using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] Portal portalUp, portalDown, portalLeft, portalRight;
    [SerializeField] Vector2 spawnLocation;

    public int Id { get => id; set => id = value; }
    public Portal PortalUp { get => portalUp; set => portalUp = value; }
    public Portal PortalDown { get => portalDown; set => portalDown = value; }
    public Portal PortalLeft { get => portalLeft; set => portalLeft = value; }
    public Portal PortalRight { get => portalRight; set => portalRight = value; }
    public Vector2 SpawnLocation { get => spawnLocation; }
    public int Width { get; set; } = 7;
    public int Height { get; set; } = 7;
    public bool IsRefenced { get; set; } = false;

    void Start()
    {
        spawnLocation = transform.position;
    }
}
