using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
            if (isPaused)
			{
                ResumeGame();
			} else
			{
                PauseGame();
			}
		}
    }

    public void ResumeGame()
	{
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
	}

    void PauseGame()
	{
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
	}

    public void OptionsMenu()
	{

	}

    public void QuitGame()
	{
        Debug.Log("QUIT");
        Application.Quit();
	}
}