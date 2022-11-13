using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;

    public int currentLevel;
    public float timeScore;
    public int lives;
    public int totalMelons;
    public string playerName;

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

        LoadLevel(3);
    }

    public void LoadGame() 
    {
        LoadLevel(2);
    }

    public void LoadLevel(int index)
    {
        currentLevel = level -1;

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
        timeScore = FindObjectOfType<StopWatch>().timeStart;

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
        
        if (lives == 0)
        {
            NewGame();
        }
        else
        {
            LoadLevel(level);
        }
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
