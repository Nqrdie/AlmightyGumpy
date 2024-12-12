using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public float rotationSpeed = 5f;
    private Transform playerTransform;
    public GameObject playerObject;
    void Start()
    {
        // Check if the player object was found
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the tag 'Player'.");
        }
    }

    void Update()
    {
        // Check if the player transform is set
        if (playerTransform != null && Vector3.Distance(gameObject.transform.position, playerObject.transform.position) <= 5 && gameObject.transform.position.z >= 50)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Use Quaternion to smoothly rotate towards the player plus 90 degrees
            Quaternion toRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up) * Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}