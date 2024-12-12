using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private Quaternion initialRotation;

    private void Start()
    {
        // Store the initial rotation of the child object
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        // Counteract the parent's rotation
        transform.rotation = initialRotation;
    }
}
