using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwompType : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D collb;
    private CircleCollider2D collc;

    [SerializeField] private float jumpPush = 14f;
    [SerializeField] private LayerMask layerGround;
    private enum movementState { idle, jumping, falling }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collb = GetComponent<BoxCollider2D>();
        collc = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collc)
    {
        if (collc.gameObject.CompareTag("Player") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPush);
            animationUpdate();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collb.bounds.center, collb.bounds.size, 0f, Vector2.down, .1f, layerGround);
    }

    private void animationUpdate()
    {
        movementState state;
        if (rb.velocity.y > .1f)
        {
            state = movementState.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = movementState.falling;
        }

        else
        {
            state = movementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }
}
