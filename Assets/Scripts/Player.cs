using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    float zPos = -0.2f;

    void FixedUpdate()
    {
        float horizontalMoveSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float verticalMoveSpeed = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(new Vector3(horizontalMoveSpeed, verticalMoveSpeed, 0));
    }

    public void MoveToPosition(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, zPos);
    }
}
