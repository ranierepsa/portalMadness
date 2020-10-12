using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameMap : MonoBehaviour
{
    [SerializeField] int width = 3;
    [SerializeField] int height = 3;
    [SerializeField] GameObject minimapPrefab;
    [SerializeField] float offset = 1f;
    [SerializeField] Material pathPortalMaterial;
    [SerializeField] Material finalPortalMaterial;
    Game game;

    GameObject[,] minimaps;

    public GameObject StartMinimap { get; set; }

    void Start()
    {
        game = FindObjectOfType<Game>();
        width = game.MapSize;
        height = game.MapSize;
        minimaps = new GameObject[width, height];
        GenerateMap();
        StartMinimap = minimaps[Random.Range(0, width), Random.Range(0, height)];
        FindObjectOfType<Player>().MoveToPosition(StartMinimap.transform.position);
        Camera.main.transform.position = new Vector3(StartMinimap.transform.position.x, StartMinimap.transform.position.y, Camera.main.transform.position.z);
        LinkPortals();
    }

    private void GenerateMap()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Minimap minimap = minimapPrefab.GetComponent<Minimap>();
                minimaps[i, j] =  Instantiate(minimapPrefab, transform.position + new Vector3(i * (minimap.Height + offset), j * (minimap.Width + offset), 0f), Quaternion.identity);
            }
        }
    }

    private void LinkPortals()
    {
        SetAllPortalsDestinationToStart();
        CreateValidPath();
    }

    private void CreateValidPath()
    {
        Minimap minimap = StartMinimap.GetComponent<Minimap>();
        minimap.IsRefenced = true;
        Portal currPortal;
        for (int i = 0; i < (width * height) - 1; i++)
        {
            currPortal = GetARandomPortal(minimap);
            minimap = SetPortalDestination(currPortal);
            currPortal.IsPath = true;
            if (game.IsEasyMode)
                UpdatePortalMaterialToPath(currPortal);
        }
        ConfigFinalPortal(minimap);
    }

    private void ConfigFinalPortal(Minimap minimap)
    {
        Portal currPortal = GetARandomPortal(minimap);
        currPortal.IsFinal = true;
        UpdatePortalMaterialToFinal(currPortal);
    }

    private Portal GetARandomPortal(Minimap minimap)
    {
        Portal currPortal;
        switch (Random.Range(0, 4))
        {
            case 0: currPortal = minimap.PortalUp; break;
            case 1: currPortal = minimap.PortalDown; break;
            case 2: currPortal = minimap.PortalLeft; break;
            case 3: currPortal = minimap.PortalRight; break;
            default: currPortal = minimap.PortalRight; break;
        }
        return currPortal;
    }

    private Minimap SetPortalDestination(Portal portal)
    {
        do
        {
            portal.Destination = minimaps[Random.Range(0, width), Random.Range(0, height)].GetComponent<Minimap>();

        } while (portal.Destination.IsRefenced && HasNotReferencedMinimap());
        portal.Destination.IsRefenced = true;

        return portal.Destination;
    }

    private void UpdatePortalMaterialToPath(Portal portal)
    {
        portal.gameObject.GetComponent<Renderer>().material = pathPortalMaterial;
    }

    private void UpdatePortalMaterialToFinal(Portal portal)
    {
        portal.gameObject.GetComponent<Renderer>().material = finalPortalMaterial;
    }

    private bool HasNotReferencedMinimap()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Minimap minimap = minimaps[i, j].GetComponent<Minimap>();
                if (!minimap.IsRefenced)
                    return true;
            }
        }
        return false;
    }

    private void SetAllPortalsDestinationToStart()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Minimap minimap = minimaps[i, j].GetComponent<Minimap>();
                minimap.PortalUp.Destination = StartMinimap.GetComponent<Minimap>();
                minimap.PortalDown.Destination = StartMinimap.GetComponent<Minimap>();
                minimap.PortalLeft.Destination = StartMinimap.GetComponent<Minimap>();
                minimap.PortalRight.Destination = StartMinimap.GetComponent<Minimap>();
            }
        }
    }
}
