using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementController : MonoBehaviour
{
	[SerializeField] private float m_Speed = 0.1f;
	[SerializeField] private float m_RunSpeed = 0.15f;
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private LockRotationRelative m_HandRotation;
	[SerializeField] private Transform m_Target;

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void Move(float move, bool sprint, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			float speed = sprint ? m_RunSpeed : m_Speed;

			Vector2 targetVelocity = transform.TransformDirection(new Vector2(move, 0) * speed);

			Vector2 velocity = transform.InverseTransformDirection(m_Rigidbody2D.velocity);
			velocity = transform.TransformDirection(velocity);
			Vector2 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -speed, speed);
			velocityChange.y = 0;
			velocityChange = transform.TransformDirection(velocityChange);

			m_Rigidbody2D.AddForce(velocityChange);

			var angleDir = getAngleDir(transform.forward, m_Target.position, transform.up);

			switch (angleDir)
            {
				case 1 when !m_FacingRight:
				case -1 when m_FacingRight:
					Flip();
					break;
            }
        }
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddRelativeForce(new Vector2(0f, m_JumpForce));
		}
	}

	int getAngleDir(Vector3 fwd, Vector3 target, Vector3 up)
    {
		Vector3 perp = Vector3.Cross(fwd, target);
		float dir = Vector3.Dot(perp, up);

		if (dir > 0f)
		{
			return 1;
		}
		else if (dir < 0f)
		{
			return -1;
		}
		else
		{
			return 0;
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		if (m_FacingRight)
			m_HandRotation.Offset = new Vector3(0, 0, -90);
		else
			m_HandRotation.Offset = new Vector3(0, 0, 90);

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
