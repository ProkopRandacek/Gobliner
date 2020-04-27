using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
    public Transform Player;
    public float distance;
    public float wait;
	public int lvlNum;

    private bool content = true;
    private bool yeeted = false;
    private Rigidbody2D rb;
    private Transform Container;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Container = GetComponentInParent<Transform>();
        rb.gravityScale = 0;
		PlayerPrefs.SetInt("ScoreLvl" + lvlNum.ToString(), 0);
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, Player.position) < distance && content)
        {
            content = false;
            Yeet();
        }
        if (!yeeted)
            transform.position = Container.position;
        else
        {
            wait -= Time.fixedDeltaTime;
            if (wait < 0)
            {
				PlayerPrefs.SetInt("ScoreLvl" + lvlNum.ToString(), PlayerPrefs.GetInt("Score", 0));
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
                SceneManager.LoadScene("Scenes/Levels");
            }
        }

        if (rb.velocity.y < 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
    }

    public void Yeet()
    {
        rb.AddForce(new Vector2(Random.Range(-4, 4) * 10, Random.Range(3, 4) * 100));
        yeeted = true;
        rb.gravityScale = 1;
        Destroy(gameObject, 5);
    }
}
