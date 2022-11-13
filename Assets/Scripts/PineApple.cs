using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineApple : MonoBehaviour
{

    private Animator anim;

    [SerializeField] public AudioSource collectSoundEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collectSoundEffect.Play();
            anim.SetTrigger("pickup"); 
            collision.gameObject.GetComponent<PlayerMovement>().jumpBoost();
        }

    }

    void Destroy()
    {
        Destroy(gameObject);
    }

}
