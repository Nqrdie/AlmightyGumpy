using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PopupText : MonoBehaviour
{

    public int letterPerSecond;

    public TextMeshProUGUI dialogText;
    
    public String[] randomdialogText;

    public string Text;

    public GameObject bar;

    public bool randomizeText;

    private int rng;

    private String randomText;

    public MonoBehaviour thisScript;

    private bool textBoxActive = false;

    private bool dialogFinished = false;

    public bool extraAction = false;

    public MonoBehaviour scriptToActivate;

    private bool dialogGone;

    private void Start()
    {
        
    }


    private void Update()
    {
        if (!textBoxActive)
        {
            textBoxActive = true;
            rng = Random.Range(0, randomdialogText.Length);
            if (randomizeText)
            {
                randomText = randomdialogText[rng];
            }

            StartCoroutine(TypeDialog(Text, randomText));
        }
        
        if (dialogFinished)
        {
            if (extraAction == false)
            {
                StartCoroutine(DeActivate());
            }
        }

        if (dialogFinished == true && extraAction == false)
        {
            StartCoroutine(DeActivate());
        }

        if(extraAction == true && dialogFinished == true)
        {
            StartCoroutine(Activate());
            StartCoroutine(DeActivate());
        }
    }

    public IEnumerator TypeDialog(string dialog, string randomDialog)
    {
        dialogText.text = "";
        if (randomizeText && !dialogFinished)
        {
            foreach (var letter in randomText.ToCharArray())
            {
                bar.SetActive(true);
                    dialogText.text += letter;
                    yield return new WaitForSeconds(1f / letterPerSecond);
            }
        }
        else
        {
            if (!dialogFinished)
            {
                foreach (var letter in Text.ToCharArray())
                {
                    bar.SetActive(true);
                    dialogText.text += letter;
                    yield return new WaitForSeconds(1f / letterPerSecond);
                }
            }
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
    }

   IEnumerator Activate()
    {
        yield return new WaitForSeconds(2);
        ActivateScript();
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
        thisScript.enabled = false;
    } 
}
