using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;
    
    public int lives;
    public int totalMelons;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartGame();
    }

    private void StartGame()
    {
        LoadLevel(1);
    }
    public void NewGame()
    {
        lives = 5;
        totalMelons = 0;

        LoadLevel(2);
    }

    private void LoadLevel(int index)
    {
        level = index;

        Camera camera = Camera.main;

        if (camera != null)
        {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);

    }
    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    public void LevelComplete()
    {
        totalMelons += FindObjectOfType<ItemCollector>().melons;

        int nextLevel = level + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextLevel);
        }
        else
        {
            LoadLevel(1);
        }
    }    
    public void LevelFailed()
    {
        lives--;

        Debug.Log(lives);
        
        if (lives == 0)
        {
            NewGame();
        }
        else
        {
            LoadLevel(level);
        }
    }
}
