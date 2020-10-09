using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Minimap destination;
    bool isPath = false;
    bool isFinal = false;

    public Minimap Destination { get => destination; set => destination = value; }
    public bool IsFinal { get => isFinal; set => isFinal = value; }
    public bool IsPath { get => isPath; set => isPath = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: Create an event
        if (!IsFinal)
        {
            collision.gameObject.GetComponent<Player>().MoveToPosition(destination.SpawnLocation);
            Camera.main.transform.position = new Vector3(destination.SpawnLocation.x, destination.SpawnLocation.y, -10);
            FindObjectOfType<AudioManager>().PlayPortalSound(IsPath || isFinal);
        } else
        {
            FindObjectOfType<SceneLoader>().LoadGameOver();
        }
    }
}
