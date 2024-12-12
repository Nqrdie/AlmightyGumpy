using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool screenLoaded = false;
    public GameObject screen;
    public AudioSource plopSound;
    public AudioClip plopSoundSFX;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !screenLoaded)
        {
            plopSound.PlayOneShot(plopSoundSFX);
            screen.SetActive(true);
            screenLoaded = true;
            Time.timeScale = 0;
        }
        else if (screenLoaded && Input.GetKeyDown(KeyCode.Escape))
        {
            plopSound.PlayOneShot(plopSoundSFX);
            screenLoaded = false;
            screen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void quitButton()
    {
        plopSound.PlayOneShot(plopSoundSFX);
        Application.Quit();
    }

    public void resumeButton()
    {
        plopSound.PlayOneShot(plopSoundSFX);
        screenLoaded = false;
        screen.SetActive(false);
        Time.timeScale = 1;
    }
}
