using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // The target object for the camera to follow
    public float smoothTime = 0.5f;  // The time it takes for the camera to reach the target position
    public float height = 10f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target != null)
        {
            // Calculate the new position with smooth interpolation
            Vector3 targetPosition = new Vector3(target.position.x, (target.position.y + height), target.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime * Time.deltaTime);
        }
    }
}
 