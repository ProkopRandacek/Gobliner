using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    public Collider2D player;

    private CoinBlockContent food;
    private Collider2D collider;
    private bool content = true;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        food = GetComponentInChildren<CoinBlockContent>();
    }

    private void FixedUpdate()
    {
        if (player.IsTouching(collider) && player.transform.position.y < transform.position.y && content)
        {
            Debug.Log("touched");
            content = false;
            food.Yeet();
        }
    }
}
