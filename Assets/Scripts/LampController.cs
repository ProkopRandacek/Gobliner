using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        rb.gravityScale = 0;
    }

    void Update()
    {
        
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
            rb.gravityScale = 1;
            col.enabled = true;
        }
    }
}
