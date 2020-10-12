using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] PortalTriggeredEvent portalTriggeredEvent;

    public void MoveCameraTo(Vector2 location)
    {
        transform.position = new Vector3(location.x, location.y, transform.position.z);
    }

    private void MoveCameraTo(Vector2 location, bool isPath)
    {
        MoveCameraTo(location);
    }

    private void OnEnable()
    {
        portalTriggeredEvent?.Subscribe(MoveCameraTo);
    }

    private void OnDisable()
    {
        portalTriggeredEvent?.Unsubscribe(MoveCameraTo);
    }
}
