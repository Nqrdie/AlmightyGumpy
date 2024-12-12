using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public float interactionDistance = 2f; // Adjust this value based on how close the player needs to be
    public KeyCode interactionKey = KeyCode.E;

    public GameObject player; // Reference to the player object

    public MonoBehaviour scriptToActivate;

    void Update()
    {
        // Check if the player is within interaction distance and presses the interaction key
        if (player != null && IsPlayerInRange() && Input.GetKeyDown(interactionKey))
        {
            ActivateScript();
        }
    }

    bool IsPlayerInRange()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance <= interactionDistance;
        }

        return false;
    }

    void ActivateScript()
    {
        // Check if the script to activate is not null
        if (scriptToActivate != null)
        {
            // Activate the script
            scriptToActivate.enabled = true;
            Debug.Log("Activated script: " + scriptToActivate.GetType().Name);
        }
        else
        {
            Debug.Log("No script assigned to activate.");
        }

        // Implement any other interaction logic here
        Debug.Log("Interaction with " + scriptToActivate.gameObject.name);
    }
}