using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool hasCane;
    public bool hasHelmet;
    public bool hasShield;

    public bool gameDone;

    public GateKeeperText gateKeeperText;

    private void Start()
    {
        gateKeeperText = FindObjectOfType<GateKeeperText>();
    }

    private void Update()
    {
        if (hasCane && hasHelmet && hasShield)
        {
            gateKeeperText.objectsGathered = true;
        }

        if (gameDone)
        {
            StartCoroutine(FinishGame());
            gameDone = false;
        }
    }

    private IEnumerator FinishGame()
    {

        print("balls");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
