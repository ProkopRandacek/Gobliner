using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolding : MonoBehaviour
{
    public GameObject HoldPos;

    private GameObject holding;
    private GameObject[] Holdable;
    private Rigidbody2D rb;

    void Start()
    {
        Holdable = GameObject.FindGameObjectsWithTag("Holdable");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (holding != null)
            {
                holding.GetComponent<Rigidbody2D>().velocity = rb.velocity;
                holding.GetComponent<LampController>().Holding(false);
                holding = null;
                return;
            } 
            foreach (GameObject hold in Holdable)
            {
                if (Vector2.Distance(hold.transform.position, transform.position) < 1.5f)
                {
                    holding = hold;
                    holding.GetComponent<LampController>().Holding(true);
                    break;
                }
            }
        }
        if (holding != null)
        {
            holding.transform.position = transform.position + new Vector3(transform.localScale.x * 0.8f, 0, 0);
        }
    }
}