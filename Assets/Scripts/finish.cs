using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public Rigidbody2D rb;
    private AudioSource finishSound;
    private Animator anim;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("finish");
            finishSound.Play();
        }
    }

    private void nextLevel()
    {
        FindObjectOfType<GameManager>().LevelComplete();
    }
}
