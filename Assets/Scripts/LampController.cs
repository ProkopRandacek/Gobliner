using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public string color;

    private Rigidbody2D rb;
    private BoxCollider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        rb.gravityScale = 0;
    }
    void FixedUpdate()
    {
        if (rb.velocity.y == 0)
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public void Holding(bool isholding)
    {
        if (isholding)
        {
            rb.gravityScale = 0;
            col.enabled = false;
        }
        else
        {
            rb.gravityScale = 1.5f;
            col.enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
