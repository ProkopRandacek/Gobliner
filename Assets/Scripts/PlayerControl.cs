using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;

    private CharacterController2D controller;
    private Animator animator;
    private Rigidbody2D rb;
    private bool jump;
    private float Horizontal = 0f;
    private bool yeeted = false;
    private bool move = true;

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
        if (move)
            controller.Move(Horizontal * Time.fixedDeltaTime, jump);

        jump = false;
        if (yeeted && rb.velocity.y < 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, -3);
    }
    public void Die()
    {
        this.Yeet();
        move = false;
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
        controller.Move(0, true);
    }
}