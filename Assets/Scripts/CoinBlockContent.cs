using UnityEngine;

public class CoinBlockContent : MonoBehaviour
{
    private bool yeeted = false;
    private Rigidbody2D rb;
    private Transform CoinBlock;
    public Texture2D[] textures;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CoinBlock = GetComponentInParent<Transform>();
        rb.gravityScale = 0;
        Debug.Log(textures[0]);
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(textures[Random.Range(0, textures.Length - 1)], new Rect(0, 0, 150, 150), new Vector2(0.5f, 0.5f));
    }

    void Update()
    {
        if (!yeeted)
        {
            transform.position = CoinBlock.position;
        }
        if (rb.velocity.y < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }
    }

    public void Yeet()
    {
        rb.AddForce(new Vector2(Random.Range(-1, 1) * 10, Random.Range(3, 4) * 100));
        yeeted = true;
        rb.gravityScale = 1;
    }
}
