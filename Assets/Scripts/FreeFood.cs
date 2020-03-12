using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFood : MonoBehaviour
{
    public Transform Player;
    public float distance;

    private CoinBlockContent food;
    private bool content = true;
    
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
        food = GetComponentInChildren<CoinBlockContent>();
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, Player.position) < distance && content)
        {
            content = false;
            food.Yeet();
        }
    }
}
