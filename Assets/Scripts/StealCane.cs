using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class StealCane : MonoBehaviour
{

    public GameObject player;
    private bool stoleCane;
    public static bool fallDownStick;
    public float speed;
    public OldManStates currentState;
    public Animator anim;
    private Transform playerTransform;
    public float rotationSpeed;
    public GameObject marker;
    public GameObject E;
    public GameObject cane;
    public AudioSource fallSound;

    //used for gameloop DONT EDIT
    public GameManager gameManager;

    public AudioClip fallSoundSFX;
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

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        var transformPosition = position;
        if (Input.GetKeyDown(KeyCode.E))
            {
                cane.tag = "Aquired";
                if (Vector3.Distance(player.transform.position, transformPosition) < 5)
                {
                    StartCoroutine(caneStolen());
                }
            }

        if (!stoleCane)
        {
            currentState = OldManStates.idle;
        }
            if (stoleCane)
            {
                marker.SetActive(false);
                E.SetActive(false);
                cane.SetActive(true);
                if (Vector3.Distance(transformPosition, player.transform.position) >= 2f && !fallDownStick)
                {
                    currentState = OldManStates.shock;
                    transform.position = Vector3.MoveTowards(transformPosition, player.transform.position, Time.deltaTime * speed);
                    currentState = OldManStates.chasing;
                }
            }
    
            if (fallDownStick)
            {
                currentState = OldManStates.fallDown;
                position.y -= 1 * Time.deltaTime;
            }
            
            anim.SetFloat("State", (float)(currentState));
            
            {
                // Check if the player transform is set
                if (playerTransform != null && Vector3.Distance(gameObject.transform.position, player.transform.position) <= 5 && gameObject.transform.position.z >= 50 && !fallDownStick)
                {
                    // Calculate the direction to the player
                    Vector3 directionToPlayer = playerTransform.position - transform.position;

                    // Use Quaternion to smoothly rotate towards the player plus 90 degrees
                    Quaternion toRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up) * Quaternion.Euler(0, 90, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                }
            }
        }
    
    
    IEnumerator caneStolen()
    {
        stoleCane = true;
       yield return new WaitForSeconds(2);
       stoleCane = false;
       fallDownStick = true;
       fallSound.PlayOneShot(fallSoundSFX);

       Destroy(gameObject, 2f);

        //used for gameloop DONT EDIT
        gameManager.hasCane = true;
        
    }
}
