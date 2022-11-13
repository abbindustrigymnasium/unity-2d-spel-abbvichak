using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private CircleCollider2D coll;
    private bossState state;
    public float radius = 0.4f;
    private int totalHits;

    [SerializeField] private AudioSource hitSoundEffect;

    private enum bossState { hit, angryIdle, coolDown, idle }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();

        state = bossState.idle;
        totalHits = 0;
    }

    void Update()
    {
        if (totalHits >= 3)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (state == bossState.idle && collision.gameObject.CompareTag("Player"))
        {
            state = bossState.hit;

            totalHits++;

            hitSoundEffect.Play();
        }
        else
        {
            collision.gameObject.GetComponent<PlayerLife>().Die();
        }
        anim.SetInteger("state", (int)state);
    }
    

    private void AngryIdle()
    {
        state = bossState.angryIdle;

        anim.SetInteger("state", (int)state);
    }

    private void CoolDown()
    {
        state = bossState.coolDown;

        anim.SetInteger("state", (int)state);
    }

    private void Idle()
    {
        state = bossState.idle;

        anim.SetInteger("state", (int)state);
    }
}
