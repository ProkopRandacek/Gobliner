using UnityEngine;

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

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
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
            if (time > 3.5f)
            {
                time = 0;
                Respawn();
            }
        }
        if (transform.position.y < -9) dead = true;

        jump = false;

        if (yeeted && rb.velocity.y < 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, -3);
    }
    public void Die()
    {
        this.Yeet();
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
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(-4, 1, 1);
        dead = false;
        yeeted = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        Camera.main.GetComponent<CameraMovement>().StartPos();
        //TODO: kamera prejede na zacatek?
    }
}