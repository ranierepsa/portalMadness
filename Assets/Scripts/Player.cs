using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PortalTriggeredEvent portalTriggeredEvent;
    [SerializeField] float moveSpeed = 10f;

    void FixedUpdate()
    {
        float horizontalMoveSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float verticalMoveSpeed = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(new Vector3(horizontalMoveSpeed, verticalMoveSpeed, 0));
    }

    public void MoveToPosition(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

    public void MoveToPosition(Vector2 position, bool isPath)
    {
        MoveToPosition(position);
    }

    public void OnEnable()
    {
        portalTriggeredEvent.Subscribe(MoveToPosition);
    }

    public void OnDisable()
    {
        portalTriggeredEvent.Unsubscribe(MoveToPosition);
    }
}
