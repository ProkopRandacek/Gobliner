using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;

    private CharacterController2D controller;
    private Animator animator;
    private Rigidbody2D rb;
    private bool Jump;
    private float Horizontal = 0f;

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
            Jump = true;
            animator.SetTrigger("jump");
        }

        animator.SetFloat("fall", rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(Horizontal));
    }
    public void OnLanding()
    {
        animator.SetBool("jump", false);
    }

    private void FixedUpdate()
    {
        controller.Move(Horizontal * Time.fixedDeltaTime, Jump);
        Jump = false;
    }
}
