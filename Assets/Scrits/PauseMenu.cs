using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    private bool inOptions = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
            if (inOptions)
			{
                OptionsMenuClose();
			} else if (isPaused)
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
	}

    void PauseGame()
	{
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPaused = true;
	}

    public void OptionsMenuOpen()
	{
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        inOptions = true;
	}

    public void OptionsMenuClose()
	{
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        inOptions = false;
	}

    public void QuitGame()
	{
        Debug.Log("QUIT");
        Application.Quit();
	}
}
