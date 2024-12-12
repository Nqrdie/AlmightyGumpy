using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public float rotationSpeed = 5f;
    private Transform cameraTransform;
    public Camera mainCamera;

    void Start()
    {
        // Find the main camera

        // Check if the main camera is found
        if (mainCamera != null)
        {
            cameraTransform = mainCamera.transform;
        }
        else
        {
            Debug.LogError("Main camera not found! Make sure your scene has a main camera.");
        }
    }

    void Update()
    {
        // Check if the camera transform is set
        if (cameraTransform != null)
        {
            // Calculate the direction to the camera
            Vector3 directionToCamera = cameraTransform.position - transform.position;

            // Use Quaternion to smoothly rotate towards the camera
            Quaternion toRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}