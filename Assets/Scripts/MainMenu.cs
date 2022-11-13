using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI textBox;

    //private void Start()
    //{
    //    textBox.text = "High Score level 1:" + FindObjectOfType<GameManager>().timeScore.ToString();
    //}
    public void newGame()
    {
        FindObjectOfType<GameManager>().NewGame();
    }
    public void loadGame()
    {
        FindObjectOfType<GameManager>().LoadGame();
    }
    public void quitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
