using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateKeeperText : MonoBehaviour
{

    public int letterPerSecond;

    public TextMeshProUGUI dialogText;

    public string Text;
    public string TextAfterCollecting;

    public GameObject bar;

    public MonoBehaviour thisScript;

    private bool textBoxActive = false;

    [SerializeField] private bool dialogFinished = false;

    public bool objectsGathered = false;

    public Movement movement;
    public GameManager gameManager;

    private void Start()
    {
        movement = FindObjectOfType<Movement>();
        gameManager = FindObjectOfType<GameManager>();
    }


    private void Update()
    {
        if (textBoxActive == true)
        {
            movement.movePossible = false;
        }

        if (!textBoxActive)
        {
            textBoxActive = true;

            if (objectsGathered == false)
            {
                
                StartCoroutine(TypeDialog(Text));
            }
            if (objectsGathered == true)
            {
                StartCoroutine(TypeDialog(TextAfterCollecting));
                
            }

        }

        if (dialogFinished)
        {
            StartCoroutine(DeActivate());
            StartCoroutine(Reset());
        }
    }

    public IEnumerator TypeDialog(string dialog)
    {
        //dialogText.text = "";


        if (!dialogFinished)
        {
            print(dialog);
            foreach (var letter in dialog.ToCharArray())
            {
                bar.SetActive(true);
                dialogText.text += letter;
                yield return new WaitForSeconds(1f / letterPerSecond);
            }
        }

        if (objectsGathered == true)
        {
            gameManager.gameDone = true;
        }
 

        dialogFinished = true;
    }

    IEnumerator DeActivate()
    {
        yield return new WaitForSeconds(1);
        bar.SetActive(false);
        dialogText.text = "";
        textBoxActive = false;
        thisScript.enabled = false;
        movement.movePossible = true;
        
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(3f);
        dialogFinished = false;
    }
}
