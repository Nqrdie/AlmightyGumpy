using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBucket : MonoBehaviour
{
    public GameObject bucket;
    public GameObject handle;
    public GameObject marker;
    public GameObject E;

    public GameManager gameManager;
    void Start()
    {
        //used for gameloop DONT EDIT
        gameManager = FindObjectOfType<GameManager>();
        
        bucket.tag = "Aquired";
        Destroy(gameObject);
        bucket.SetActive(true);
        handle.SetActive(true);
        Destroy(marker);
        Destroy(E);

        //used for gameloop DONT EDIT
        gameManager.hasHelmet = true;
    }
}