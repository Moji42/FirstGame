using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 100f;
    public float minAngle = -30f;
    public float maxAngle = 60f;
    public float height = 3f;

    public float distance = 8f; // Default distance (increased from 5)
    public float minDistance = 2f; // Closest you can scroll in
    public float maxDistance = 20f; // Furthest you can scroll out
    public float scrollSpeed = 2f; // How fast scrolling zooms

    private float xRotation = 10f;

    void LateUpdate()
    {
        // Scroll input for zooming
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * scrollSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Vertical mouse input for rotation
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

        // Position camera based on target + rotation + distance
        Vector3 dir = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(xRotation, target.eulerAngles.y, 0);
        transform.position = target.position + rotation * dir;

        // Always look at player
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}