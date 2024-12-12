using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public AudioSource buttonClick;


    private void Start()
    {
    }

    private int levelToLoad;
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

  
     public void FadeToLevel(int levelIndex)
     {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
     public void startButton()
     {
         buttonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

     public void quitButton()
     {
         buttonClick.Play();
         Application.Quit();
     }
}
