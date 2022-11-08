using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    private AudioSource finishSound;
    private Animator anim;
    public bool lastLevel;
    

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        lastLevel = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("finish");
            finishSound.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        
    }
    private void EndLevel()
    {
        if (lastLevel)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.GetActiveScene().buildIndex + 1;
        }
    }
}
