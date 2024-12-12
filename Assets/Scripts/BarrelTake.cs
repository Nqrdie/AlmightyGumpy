using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTake : MonoBehaviour
{
    public GameObject player;
    public GameObject barrel;
    public GameObject oldman;
    private bool stoleCane;
    public static bool fallDownBarrel;
    public float speed;
    public OldManStates currentState;
    public Animator anim;
    private Transform playerTransform;
    public float rotationSpeed;
    public GameObject E;
    public GameObject marker;
    public GameObject shield;

    //for gameloop dont remove
    public GameManager gameManager;

    public enum OldManStates
    {
        chasing,
        shock,
        fallDown,
        idle
    }
    
    private void Start()
    {
        //used for gameloop DONT EDIT
        gameManager = FindObjectOfType<GameManager>();

        barrel.SetActive(false);
        oldman.SetActive(true);
        
        // Check if the player object was found
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the tag 'Player'.");
        }
    }

    void Update()
    {
        if (Vector3.Distance(oldman.transform.position, player.transform.position) >= 2f && !fallDownBarrel)
        {
            marker.SetActive(false);
            E.SetActive(false);
            shield.tag = "Aquired";
            shield.SetActive(true);

            //used for gameloop DONT EDIT
            gameManager.hasShield = true;

            currentState = OldManStates.shock;
            oldman.transform.position = Vector3.MoveTowards(oldman.transform.position, player.transform.position, Time.deltaTime * speed);
            currentState = OldManStates.chasing;
            StartCoroutine(Falling());
        }
        anim.SetFloat("State", (float)(currentState));

        if (fallDownBarrel)
        {
            currentState = OldManStates.fallDown;
        }
        
        
        {
            // Check if the player transform is set
            if (playerTransform != null && Vector3.Distance(oldman.transform.position, player.transform.position) <= 5 && oldman.transform.position.z >= 50 && !fallDownBarrel)
            {
                // Calculate the direction to the player
                Vector3 directionToPlayer = playerTransform.position - oldman.transform.position;

                // Use Quaternion to smoothly rotate towards the player plus 90 degrees
                Quaternion toRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up) * Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    private IEnumerator Falling()
    {
        yield return new WaitForSeconds(2);
        fallDownBarrel = true;
        Destroy(oldman, 1.5f);
    }
}