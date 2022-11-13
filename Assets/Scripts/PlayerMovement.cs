using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    
    private float dirX = 0f;

    private enum movementState { idle, running, jumping, falling }
    
    [SerializeField] private float moveSpeed = 350f;
    [SerializeField] public float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }

        animationUpdate();
    }

    private void animationUpdate()
    {
        movementState state;
        if (dirX > 0f)
        {
            state = movementState.running;
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = movementState.running;
            sprite.flipX = true;
        }

        else
        {
            state = movementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = movementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void jumpBoost()
    {
        jumpForce = 21f;
    }
}
