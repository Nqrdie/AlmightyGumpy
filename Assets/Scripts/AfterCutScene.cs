using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterCutScene : MonoBehaviour
{

    private int seconds;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Animation");
        {
            seconds = 25;
        }

        if (SceneManager.GetActiveScene().name == "EndAnimation")
        {
            seconds = 22;
        }
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
