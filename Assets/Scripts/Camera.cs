using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;  // Reference to the player object
    public float rotationSpeed = 5f;  // Speed of camera rotation around the player
    public float smoothSpeed = 5f;    // Speed of smoothing for camera rotation
    public float distance = 5f;  // Distance between the player and the camera

    private float mouseX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Rotate the camera around the player based on mouse input
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;

        // Directly set the rotation without interpolation
        Quaternion targetRotation = Quaternion.Euler(0, mouseX, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);

        // Calculate the camera's position based on the player's rotation and distance
        Vector3 desiredPosition = player.position - transform.forward * distance;
        desiredPosition.y = player.position.y + distance / 2f;  // Keep the camera at a fixed height

        // Set the camera position directly without interpolation
        transform.position = new Vector3(desiredPosition.x, transform.position.y, desiredPosition.z);
    }
}