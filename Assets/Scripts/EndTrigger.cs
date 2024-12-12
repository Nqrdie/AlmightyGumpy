using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{

    public GameObject bucket;
    public GameObject cane;
    public GameObject shield;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ending"))
        {
            if (shield.CompareTag("Aquired") && bucket.CompareTag("Aquired") && cane.CompareTag("Aquired"))
            {
                SceneManager.LoadScene("EndAnimation");
            }
        }
    }
}
