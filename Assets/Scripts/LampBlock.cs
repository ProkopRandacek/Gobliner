using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlock : MonoBehaviour
{
    public string color;

    private GameObject[] lampy;
    private BoxCollider2D col;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    void Start()
    {
        lampy = GameObject.FindGameObjectsWithTag("Holdable");
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Switch(false);
    }

    void FixedUpdate()
    {
        bool on = false;
        foreach (GameObject lampa in lampy)
        {
            if (lampa.GetComponent<LampController>() == null || lampa.GetComponent<LampController>().color != this.color)
                continue;
            if (Vector2.Distance(lampa.transform.position, transform.position) < 7)
            {
                on = true;
                break;
            }
        }
        Switch(on);
    }
    private void Switch(bool on)
    {
        col.enabled = on;
        float a;
        if (on) { a = 1.0f; }
        else    { a = 0.5f; }
        sr.color = new Color(1, 1, 1, a);
    }
}
