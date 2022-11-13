using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    //void start () 
    //{
    //    
    //}

    public void loadLevel1()
    {
        FindObjectOfType<GameManager>().LoadLevel(3);
    }
    public void loadLevel2()
    {
        FindObjectOfType<GameManager>().LoadLevel(4);
    }
    public void loadLevel3()
    {
        FindObjectOfType<GameManager>().LoadLevel(5);
    }
    public void loadLevel4()
    {
        FindObjectOfType<GameManager>().LoadLevel(6);
    }
}
