using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
	public GameObject PauseScreenCanvas;

	private bool gamePaused;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gamePaused == false)
			{
				Pause();
			}
			else
			{
				Continue();
				Debug.Log("test");
			}
		}

	}

	public void Pause()
	{
		PauseScreenCanvas.SetActive(true);
		Time.timeScale = 0;
		gamePaused = true;
	}

	public void Continue()
	{
		PauseScreenCanvas.SetActive(false);
		Time.timeScale = 1;
		gamePaused = false;
	}

	public void Quit()
	{
		SceneManager.LoadScene(0);
	}
}
