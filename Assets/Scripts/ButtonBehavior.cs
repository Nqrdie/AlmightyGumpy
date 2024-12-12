using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public static bool fadeScene;
    public void startButton()
    {
        SceneManager.LoadScene("Animation");
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
