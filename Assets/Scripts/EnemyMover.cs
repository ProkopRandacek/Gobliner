using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject player;

    private int i = 0;
    private Vector3[] smer = new Vector3[2] { Vector3.left, Vector3.right };
    private Rigidbody2D rb;
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

	void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + smer[i], moveSpeed * Time.fixedDeltaTime);
	}
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == player)
        {
            Debug.Log("collision");
            if (player.transform.position.y - 1.1f < gameObject.transform.position.y)
                player.GetComponent<PlayerController>().Die();
            else
            {
                player.GetComponent<PlayerController>().Jump();
                this.Die();
            }
        }
        i = new int[]{1, 0}[i];
    }

    public void Die()
    {
        this.Yeet();
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + 1);
    }

    private void Yeet()
    {
        rb.AddForce(new Vector2(Random.Range(-4, 4) * 10, Random.Range(3, 4) * 100));
        rb.gravityScale = 1;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 5);
    }
}
