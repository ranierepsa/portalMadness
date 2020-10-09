using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] Portal portalUp, portalDown, portalLeft, portalRight;
    [SerializeField] Vector2 spawnLocation;
    int width = 7, height = 7;
    bool isRefenced = false;

    public int Id { get => id; set => id = value; }
    public Portal PortalUp { get => portalUp; set => portalUp = value; }
    public Portal PortalDown { get => portalDown; set => portalDown = value; }
    public Portal PortalLeft { get => portalLeft; set => portalLeft = value; }
    public Portal PortalRight { get => portalRight; set => portalRight = value; }
    public Vector2 SpawnLocation { get => spawnLocation; }
    public int Width { get => width; set => width = value; }
    public int Height { get => height; set => height = value; }
    public bool IsRefenced { get => isRefenced; set => isRefenced = value; }

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = transform.position;
    }
}
