using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwompType : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private float jumpPush = 14f;
    [SerializeField] private LayerMask layerGround;
    private enum movementState { idle, jumping, falling }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPush);
            animationUpdate();
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, layerGround);
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
