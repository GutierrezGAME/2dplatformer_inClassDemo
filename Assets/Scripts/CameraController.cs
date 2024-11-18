using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;

    public float minX; // left
    public float maxX; // right
    public float minY; // down
    public float maxY; // up

    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;

        // clamp
        float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(targetPosition.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

    }
}
