using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	
	public float JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] public float MovementSmoothing = 0.05f;	// How much to smooth out the movement
	public LayerMask WhatIsGround;							// A mask determining what is ground to the character
	public Transform GroundCheck;					    	// A position marking where to check if the player is grounded.
	public GameObject HoldPos;

	const float GroundedRadius = 0.2f; // Radius of the overlap circle to determine if grounded
	private bool Grounded;             // Whether or not the player is grounded.
	private Rigidbody2D rb;
	private bool m_FacingRight = true; // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
    public float fallMultiplier = 1.5f;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = Grounded;
		Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        }
	}

	public void Move(float move, bool jump = false)
	{
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);

        if (move > 0 && !m_FacingRight)
            Flip();

        else if (move < 0 && m_FacingRight)
            Flip();

		if (Grounded && jump)
		{
			Grounded = false;
			rb.AddForce(new Vector2(0f, JumpForce));
		}
	}

	private void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		HoldPos.transform.position += new Vector3(theScale.x * 1, 0, 0);
	}
}