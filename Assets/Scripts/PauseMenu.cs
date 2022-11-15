using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void quitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void restartGame()
    {
        FindObjectOfType<GameManager>().LevelFailed();
    }
    
    void Start()
    {
        Time.timeScale = 1;
        gameIsPaused = false; 
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                resume();
            } else
            {
                pause();
            }
        }
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            restartGame();
        }
    }
}
