using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private CharacterController2D controller;
    private Animator animator;
    private Rigidbody2D rb;
    private bool jump;
    private float Horizontal = 0f;
    private bool yeeted = false;
    private bool dead = false;
    private float time = 0;
    private AudioManager am;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<AudioManager>();
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            am.Play("jump");
            animator.SetTrigger("jump");
        }

        animator.SetFloat("fall", rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(Horizontal));
    }
    public void OnLanding()
    {
        animator.SetBool("jump", false);
    }
    void FixedUpdate()
    {
        if (!dead)
            controller.Move(Horizontal * Time.fixedDeltaTime, jump);
        else
        {
            time += Time.fixedDeltaTime;
            if (time > 2.5f)
            {
                time = 0;
                Respawn();
            }
        }
        if (transform.position.y < -9)
        {
            Respawn();
        }

        jump = false;

        if (yeeted && rb.velocity.y < 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, -3);
    }
    public void Die()
    {
        this.Yeet();
        am.Play("die");
        PlayerPrefs.SetInt("Score", 0);
        dead = true;
    }
    void Yeet()
    {
        rb.AddForce(new Vector2(Random.Range(-4, 4) * 10, Random.Range(3, 4) * 50));
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yeeted = true;
    }
    public void Jump()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector2(0f, 200));
    }
    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives", 0) - 1);
        Debug.Log("dede");
        if (PlayerPrefs.GetInt("Lives", 0) < 1)
        {
            Debug.Log("ded");
            //TODO
        }
    }
}
